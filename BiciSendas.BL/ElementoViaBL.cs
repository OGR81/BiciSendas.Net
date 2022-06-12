using BiciSendas.DA;
using BiciSendas.DA.Entities;
using BiciSendas.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiciSendas.BL
{
    public class ElementoViaBL
    {
        public readonly ElementoViaDA DA;
        public ElementoViaBL(ElementoViaDA da)
        {
            DA = da;
        }

        public async Task<List<ElementoVia>> ObtenerElementosVia()
        {
            return await DA.GetAllAsync();
        }

        public async Task Grabar(ElementoVia elementoVia)
        {
            await DA.Add(elementoVia);
        }

        public async Task Eliminar(int idElementoVia)
        {
            ElementoVia? elementoVia = await DA.GetById(idElementoVia);

            if (elementoVia is null)
                throw new Exception($"No se ha encontrado {typeof(ElementoVia)}");

            await DA.Delete(elementoVia);
        }

        public List<string> Validar(ElementoVia elementoVia)
        {
            List<string> errores = new();

            if (YaExisteNombre(elementoVia))
                errores.Add(ElementoViaStrings.ErrorNombreYaExiste);

            if (YaExisteIdentificador(elementoVia))
                errores.Add(ElementoViaStrings.ErrorIdentificadorYaExiste);

            if (string.IsNullOrEmpty(elementoVia.Nombre))
                errores.Add(ElementoViaStrings.NombreObligatorio);
            else if (elementoVia.Nombre!.Length > 50)
                errores.Add(ElementoViaStrings.ErrorLongitudNombre);

            if (string.IsNullOrEmpty(elementoVia.TipoElemento))
                errores.Add(ElementoViaStrings.TipoElementoObligatorio);
            else if (elementoVia.TipoElemento!.Length > 50)
                errores.Add(ElementoViaStrings.ErrorLongitudTipoElemento);

            if (string.IsNullOrEmpty(elementoVia.Identificador))
                errores.Add(ElementoViaStrings.IdentificadorObligatorio);
            else if (elementoVia.Identificador!.Length > 50)
                errores.Add(ElementoViaStrings.ErrorLongitudIdentificador);

            return errores;
        }

        private bool YaExisteNombre(ElementoVia elementoVia)
        {
            return DA.YaExisteNombre(elementoVia);
        }

        private bool YaExisteIdentificador(ElementoVia elementoVia)
        {
            return DA.YaExisteIdentificador(elementoVia);
        }
    }
}
