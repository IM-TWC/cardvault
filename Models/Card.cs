using System.ComponentModel.DataAnnotations;

namespace CardVault.Models;

public class Card
{
    public int Id { get; set; }

    [Required, MaxLength(200)]
    public string Name { get; set; } = "";

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public List<SetCard> Sets { get; set; } = new();
}
