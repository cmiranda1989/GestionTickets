using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTickets.Domain
{
    using System.Data.Entity;

    public class DataContext: DbContext
    {
        public DataContext(): base("DefaultConnection")
        {

        }
        public DbSet<Ciudad> Ciudads { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<CajaDepto> CajaDeptoes { get; set; }

        public DbSet<Estado> Estadoes { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Equipo> Equipoes { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Cadena> Cadenas { get; set; }

        public DbSet<Ticket> Tickets { get; set; }
    }
}
