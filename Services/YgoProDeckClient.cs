using System.Net.Http.Json;
using CardVault.Dtos;

namespace CardVault.Services;

public sealed class YgoProDeckClient
{
    private readonly HttpClient _http;

    public YgoProDeckClient(HttpClient http)
    {
        _http = http;
        _http.BaseAddress = new Uri("https://db.ygoprodeck.com/api/v7/");
    }

    public async Task<List<YgoCardSetDto>> GetAllSetsAsync(CancellationToken ct = default)
    {
        var sets = await _http.GetFromJsonAsync<List<YgoCardSetDto>>("cardsets.php", ct);
        return sets ?? new List<YgoCardSetDto>();
    }

    public async Task<YgoCardInfoResponseDto?> GetCardsBySetNameAsync(string setName, CancellationToken ct = default)
    {
        // cardset Parameter erwartet den Set-Namen, z.B. "Retro Pack 2"
        var url = $"cardinfo.php?cardset={Uri.EscapeDataString(setName)}";
        return await _http.GetFromJsonAsync<YgoCardInfoResponseDto>(url, ct);
    }
}
