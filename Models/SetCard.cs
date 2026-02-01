using System.ComponentModel.DataAnnotations;

namespace CardVault.Models;

public class SetCard
{
    public int Id { get; set; }

    public int CardSetId { get; set; }
    public CardSet CardSet { get; set; } = default!;

    public int CardId { get; set; }
    public Card Card { get; set; } = default!;

    [MaxLength(50)]
    public string? SetNumber { get; set; }

    public int SortOrder { get; set; }
}
