using System.ComponentModel.DataAnnotations;

namespace CardVault.Models;

public class CardSet
{
    public int Id { get; set; }

    [Required, MaxLength(50)]
    public string Code { get; set; } = "";

    [Required, MaxLength(200)]
    public string Name { get; set; } = "";

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public List<SetCard> Cards { get; set; } = new();
}
