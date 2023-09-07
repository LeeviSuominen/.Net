using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harjoitus2
{
    public class Pelitietokanta : DbContext
    {
        public DbSet<Login> Logins { get; set; }

        // Connection string eli yhteys tietokantaan

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection = "Data Source = .;Initial Catalog = Pelitietokanta; User Id=sa;" +
                "Password = WinterSoldier890;MultipleActiveResultSets = true;" +
                "TrustServerCertificate = true";
            optionsBuilder.UseSqlServer(connection => connection.EnableRetryOnFailure());
        }
    }
}
