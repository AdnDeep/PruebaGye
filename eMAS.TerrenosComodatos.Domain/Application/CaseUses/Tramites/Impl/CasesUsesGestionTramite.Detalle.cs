using eMAS.TerrenosComodatos.Domain.Constantes;
using eMAS.TerrenosComodatos.Domain.DTOs;

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
            if (entidad == AppConst.EntidadAnexo)
            {
                respuesta = LeerAnexoTodos(idtramite);
            } else if (entidad == AppConst.EntidadObservacion)
            {
                respuesta = LeerObservacionTodos(idtramite);
            }
            else if (entidad == AppConst.EntidadOficio)
            {
            }
            else if (entidad == AppConst.EntidadTopografia)
            {
            }
            return respuesta;
        }
        
    }
}
