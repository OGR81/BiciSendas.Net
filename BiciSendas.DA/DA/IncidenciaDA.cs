using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using BiciSendas.DA.Entities;
using BiciSendas.DA.Repository;
using Microsoft.EntityFrameworkCore;

namespace BiciSendas.DA
{ 
    public class IncidenciaDA : BaseRepository<Incidencia>
    {
        private readonly BicisendasContext context;

        public IncidenciaDA(BicisendasContext context) : base(context) 
        {
            this.context = context;   
        }

        public List<Incidencia> ObtenerIncidencias()
        {
            return context
                .Incidencias
                .Include(x=>x.TipoIncidencia)
                .Include(x=>x.Estado)
                .OrderBy(x=>x.Fecha)
                .ToList();
        }
    }
}
