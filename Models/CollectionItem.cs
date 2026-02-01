using System;
using System.ComponentModel.DataAnnotations;

namespace CardVault.Models;

public class CollectionItem
{
    public int Id { get; set; }

    [Required]
    public string CardName { get; set; } = "";

    public string? SetCode { get; set; }
    public string? Rarity { get; set; }

    [Required]
    public string Condition { get; set; } = "NM"; // NM, EX, GD, PL, PO

    public int Quantity { get; set; } = 1;

    [Required]
    public string UserId { get; set; } = "";

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public int CollectionId { get; set; }
    
    public Collection? Collection { get; set; }

}
