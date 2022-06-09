using BiciSendas.DA.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiciSendas.DA
{
    public class BicisendasContext : DbContext
    {
        public BicisendasContext(DbContextOptions<BicisendasContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Incidencia>().HasKey(i => i.IdIncidencia);
            modelBuilder.Entity<Estado>().HasKey(e => e.IdEstado);
            modelBuilder.Entity<TipoIncidencia>().HasKey(ti => ti.IdTipoIncidencia);
            modelBuilder.Entity<ElementoVia>().HasKey(ev => ev.IdElementoVia);
            modelBuilder.Entity<Faq>().HasKey(f => f.IdFaq);
        }

        public DbSet<Incidencia> Incidencias { get; set; } = null!;
        public DbSet<Estado> Estados { get; set; } = null!;
        public DbSet<TipoIncidencia> TiposIncidencias { get; set; } = null!;
        public DbSet<ElementoVia> ElementosVias { get; set; } = null!;
        public DbSet<Faq> Faqs { get; set; } = null!;
        public DbSet<Actuador> Actuadores { get; set; } = null!;
        public DbSet<Sensor> Sensores { get; set; } = null!;
    }
}
