using Microsoft.EntityFrameworkCore;
using CreationdesModel.ModelView;

namespace CreationdesModel.Models
{
    public class Mycontext : DbContext
    {
        public DbSet<Assurance> assurances { get; set; }
        public DbSet<Client> clients { get; set; }
        public DbSet<Location> locations { get; set; }
        public DbSet<Marque> marques { get; set; }
        public DbSet<Voiture> Voitures { get; set; }
        public Mycontext(DbContextOptions<Mycontext> opt) : base(opt)
        {

        }
        public DbSet<CreationdesModel.ModelView.LocationAddModelview>? LocationAddModelview { get; set; }
        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Marque>().HasData(
                new Marque { Id = 1, Libelle = "Renaut" },
                new Marque { Id = 2, Libelle = "Dacia" }
            );
        }*/
    }
}
