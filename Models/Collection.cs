using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CardVault.Models;

public class Collection
{
    public int Id { get; set; }

    [Required]
    public string UserId { get; set; } = "";

    [Required]
    [MaxLength(80)]
    public string Name { get; set; } = "Main_Default";

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Navigation (optional, aber nice)
    public List<CollectionItem> Items { get; set; } = new();
}
