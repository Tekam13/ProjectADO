using Microsoft.EntityFrameworkCore;
using TP_final.Models;

namespace TP_final.Datas
{
    public class AddDbContext:DbContext
    {
        public AddDbContext(DbContextOptions<AddDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Acteur>().Property(a => a.Photo).IsRequired();
            //modelBuilder.Entity<Acteur>().Property(a => a.Nom).IsRequired().HasMaxLength(50);
            //modelBuilder.Entity<Acteur>().Property(a => a.bibloigraphie).IsRequired();

            //modelBuilder.Entity<films>().Property(f => f.Nom).IsRequired().HasMaxLength(50);
            //modelBuilder.Entity<films>().Property(f => f.Description).IsRequired();
            //modelBuilder.Entity<films>().Property(f => f.debut).IsRequired();
            //modelBuilder.Entity<films>().Property(f => f.Fin).IsRequired();
            //modelBuilder.Entity<films>().Property(f => f.prix).IsRequired();
            //modelBuilder.Entity<films>().Property(f => f.categorie).IsRequired();

            //modelBuilder.Entity<films>().HasOne<ActeurFilms>(f => f.acteurFilms)
            //                                  .WithMany(af => af.films)
            //                                  .HasForeignKey(f => f.Id);

            //modelBuilder.Entity<Acteur>().HasOne<ActeurFilms>(a => a.acteurFilms)
            //                                  .WithMany(af => af.Acteur)
            //                                  .HasForeignKey(a => a.Id);


            //modelBuilder.Entity<ActeurFilms>().HasOne(f => f.films)
            //                                  .WithMany(af => af.ActeurFilms)
            //                                  .HasForeignKey(af => af.FilmId);

            //modelBuilder.Entity<ActeurFilms>().HasOne(a => a.Acteur)
            //                                  .WithMany(af => af.ActeurFilms)
            //                                  .HasForeignKey(af => af.ActeurId);


            modelBuilder.Entity<ActeurFilms>().HasKey(af => new
            {
                af.ActeurId,
                af.FilmId,
            });

            modelBuilder.Entity<ActeurFilms>().HasOne(f => f.films)
                                              .WithMany(af => af.ActeurFilms)
                                              .HasForeignKey(af => af.FilmId);
            //.HasForeignKey(f => f.FilmId);

            modelBuilder.Entity<ActeurFilms>().HasOne(a => a.Acteur)
                                              .WithMany(af => af.ActeurFilms)
                                              .HasForeignKey(af => af.ActeurId);
            //.HasForeignKey(f => f.FilmId);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Acteur> Acteurs { get; set; }
        public DbSet<films> Films { get; set; }
        public DbSet<ActeurFilms> Acteurs_Films { get; set; }
    }
}
