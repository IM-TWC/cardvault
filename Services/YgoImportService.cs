using CardVault.Data;
using CardVault.Models;
using Microsoft.EntityFrameworkCore;

namespace CardVault.Services;

public sealed class YgoImportService
{
    private readonly ApplicationDbContext _db;
    private readonly YgoProDeckClient _api;

    public YgoImportService(ApplicationDbContext db, YgoProDeckClient api)
    {
        _db = db;
        _api = api;
    }

    // 1) Nur Sets importieren (schnell, safe)
    public async Task<int> ImportSetsAsync(CancellationToken ct = default)
    {
        var sets = await _api.GetAllSetsAsync(ct);

        int added = 0;

        foreach (var s in sets)
        {
            if (string.IsNullOrWhiteSpace(s.set_code) || string.IsNullOrWhiteSpace(s.set_name))
                continue;

            var code = s.set_code.Trim();
            var name = s.set_name.Trim();

            var exists = await _db.CardSets.AnyAsync(x => x.Code == code, ct);
            if (exists) continue;

            _db.CardSets.Add(new CardSet
            {
                Code = code,
                Name = name
            });

            added++;

            // alle 200 speichern (Performance)
            if (added % 200 == 0)
                await _db.SaveChangesAsync(ct);
        }

        await _db.SaveChangesAsync(ct);
        return added;
    }

    // 2) Karten für ein Set importieren (langsamer)
    public async Task<int> ImportCardsForSetAsync(string setCode, CancellationToken ct = default)
    {
        var set = await _db.CardSets.FirstOrDefaultAsync(x => x.Code == setCode, ct);
        if (set is null) return 0;

        var resp = await _api.GetCardsBySetNameAsync(set.Name, ct);
        if (resp?.data is null || resp.data.Count == 0) return 0;

        int linksAdded = 0;

        foreach (var cardDto in resp.data)
        {
            var cardName = cardDto.name.Trim();
            if (string.IsNullOrWhiteSpace(cardName))
                continue;

            // Card upsert by name
            var card = await _db.Cards.FirstOrDefaultAsync(c => c.Name == cardName, ct);
            if (card is null)
            {
                card = new Card { Name = cardName };
                _db.Cards.Add(card);
                await _db.SaveChangesAsync(ct); // damit card.Id verfügbar ist
            }

            // passende Set-Entry für dieses Set finden
            var entry = cardDto.card_sets?
                .FirstOrDefault(x => string.Equals(x.set_code?.Trim(), setCode, StringComparison.OrdinalIgnoreCase));

            // SetNumber bestmöglich setzen
            var setNumber = entry?.set_rarity_code?.Trim(); // oft "RP02-EN089"
            if (string.IsNullOrWhiteSpace(setNumber))
                setNumber = null; // lieber null als Müll

            var exists = await _db.SetCards.AnyAsync(sc => sc.CardSetId == set.Id && sc.CardId == card.Id, ct);
            if (exists) continue;

            _db.SetCards.Add(new SetCard
            {
                CardSetId = set.Id,
                CardId = card.Id,
                SetNumber = setNumber,
                SortOrder = 0 // optional später aus setNumber parsen
            });

            linksAdded++;

            if (linksAdded % 200 == 0)
                await _db.SaveChangesAsync(ct);
        }

        await _db.SaveChangesAsync(ct);
        return linksAdded;
    }
}
