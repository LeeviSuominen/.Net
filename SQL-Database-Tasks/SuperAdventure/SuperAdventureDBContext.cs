global using Microsoft.EntityFrameworkCore;

namespace SuperAdventure
{
    public class SuperAdventureDBContext : DbContext
    {
        //Tietokantayhteyttä
        public SuperAdventureDBContext(DbContextOptions options) : base(options) {}

        // Ominaisuuden avulla keskustellaan tietokantataulun kanssa
        public DbSet<Stat> Stats { get; set; }
    }
}
