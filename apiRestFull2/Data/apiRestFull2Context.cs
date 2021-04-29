using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using apiRestFull2.Models;

namespace apiRestFull2.Data
{
    public class apiRestFull2Context : DbContext
    {
        public apiRestFull2Context (DbContextOptions<apiRestFull2Context> options)
            : base(options)
        {
        }

        public DbSet<apiRestFull2.Models.Cargo> Cargos { get; set; }

        public DbSet<apiRestFull2.Models.Nominas> Nominas { get; set; }

        public DbSet<apiRestFull2.Models.Sueldopro> Sueldopro { get; set; }

        public DbSet<apiRestFull2.Models.Mayorpago> Mayorpago { get; set; }

        public DbSet<apiRestFull2.Models.Puntajes> Puntaje { get; set; }

        public DbSet<apiRestFull2.Models.publicacion> publicacion { get; set; }

        public DbSet<apiRestFull2.Models.Usuario> Usuarios { get; set; }

        public DbSet<apiRestFull2.Models.Amigo> amigo { get; set; }

        public DbSet<apiRestFull2.Models.ModelLike> UserLike { get; set; }

        public DbSet<apiRestFull2.Models.Solicitud> solicitudamistad { get; set; }
    }
}
