using eMAS.TerrenosComodatos.Domain.DTOs;
using eMAS.TerrenosComodatos.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace eMAS.TerrenosComodatos.Domain.Application
{
    public partial class CasesUsesGestionTramite : ICasesUsesGestionTramite
    {
        public object EliminarDetalle(string model, string usuario, string controlador, string pcclient, string entidad)
        {
            throw new System.NotImplementedException();
        }

        public object GrabarDetalle(string model, string usuario, string controlador, string pcclient, string entidad)
        {
            throw new System.NotImplementedException();
        }

        public object LeerDetalleListaTodos(short idtramite, string entidad)
        {
            object respuesta = null;
            if (entidad == EntidadAnexo)
            {
                respuesta = LeerAnexoTodos(idtramite);
            } else if (entidad == EntidadObservacion)
            {
                respuesta = LeerObservacionTodos(idtramite);
            }
            else if (entidad == EntidadOficio)
            {
            }
            else if (entidad == EntidadTopografia)
            {
            }
            return respuesta;
        }

        public object LeerDetallePorId(short identidad, string entidad)
        {
            throw new System.NotImplementedException();
        }
    }
}
