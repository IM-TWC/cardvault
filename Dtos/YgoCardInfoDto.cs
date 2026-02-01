namespace CardVault.Dtos;

public sealed class YgoCardInfoResponseDto
{
    public List<YgoCardDto> data { get; set; } = new();
}

public sealed class YgoCardDto
{
    public string name { get; set; } = "";
    public List<YgoCardSetEntryDto>? card_sets { get; set; }
}

public sealed class YgoCardSetEntryDto
{
    public string set_name { get; set; } = "";
    public string set_code { get; set; } = "";
    public string set_rarity { get; set; } = "";
    public string? set_rarity_code { get; set; } // oft sowas wie "RP02-EN089"
}
