using Microsoft.EntityFrameworkCore;

namespace CardVault.Data;

public static class SeedData
{
    public static async Task EnsureSeededAsync(ApplicationDbContext db)
    {
        // Nur Migrationen anwenden, keine Daten mehr seeden
        await db.Database.MigrateAsync();
    }
}
