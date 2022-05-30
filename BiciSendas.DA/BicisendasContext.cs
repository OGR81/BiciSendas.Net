using BiciSendas.DA.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiciSendas.DA
{
    public class BicisendasContext: DbContext
    {
        public BicisendasContext(DbContextOptions<BicisendasContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Incidencia>().HasKey(i => i.IdIncidencia);
        }

        public DbSet<Incidencia> Incidencias { get; set; } = null!;
    }
}
