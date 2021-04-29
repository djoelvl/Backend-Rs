using Microsoft.EntityFrameworkCore;
using RedSocial.Services.Entities;

namespace RedSocial.Services.Db
{
    public class RsDbContext : DbContext
    {
        public RsDbContext(DbContextOptions<RsDbContext> options)
            : base(options)
        {
        }


        public DbSet<Publicacion> Publicacion { get; set; }

        public DbSet<User> User { get; set; }

        public DbSet<Amigo> Amigo { get; set; }

        public DbSet<Like> Like { get; set; }

        public DbSet<Solicitud> Solicitud { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(p => p.UserName).IsUnique();
                entity.Property(p => p.UserName).HasMaxLength(25).IsRequired();
                entity.Property(p => p.FirstName).HasMaxLength(25).IsRequired();
                entity.Property(p => p.LastName).HasMaxLength(25).IsRequired();
                entity.Property(p => p.Password).HasMaxLength(255).IsRequired();
            });


            builder.Entity<SolicitudEstado>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(p => p.Descripcion).HasMaxLength(30).IsRequired();
            });


            builder.Entity<Solicitud>(entity =>
            {
                entity.HasKey(e => e.Id);

                
                entity.HasOne<SolicitudEstado>()
                .WithMany()
                .HasPrincipalKey(k => k.Id)
                .HasForeignKey(f => f.EstadoId);

            });


            builder.Entity<Publicacion>(entity =>
            {
                entity.HasKey(e => e.Id);


            });

            builder.Entity<Like>(entity =>
            {
                entity.HasKey(e => e.Id);


            });

            builder.Entity<Amigo>(entity =>
            {
                entity.HasKey(e => e.Id);


            });

        }
    }
}
