using eMAS.TerrenosComodatos.Domain.Constantes;
using eMAS.TerrenosComodatos.Domain.DTOs;

namespace eMAS.TerrenosComodatos.Domain.Application
{
    public partial class CasesUsesGestionTramite : ICasesUsesGestionTramite
    {
        public object EliminarDetalle(short id, string usuario, string controlador, string pcclient, string entidad)
        {
            object respuesta = null;
            if (entidad == AppConst.EntidadAnexo)
            {
                respuesta = EliminarAnexo(id,usuario, controlador, pcclient);
            }
            else if (entidad == AppConst.EntidadObservacion)
            {
                respuesta = EliminarObservacion(id, usuario, controlador, pcclient);
            }
            else if (entidad == AppConst.EntidadOficio)
            {
            }
            else if (entidad == AppConst.EntidadTopografia)
            {
            }
            return respuesta;
        }

        public object GrabarDetalle(string model, string usuario, string controlador, string pcclient, string entidad)
        {
            object respuesta = null;
            if (entidad == AppConst.EntidadAnexo)
            {
                respuesta = GrabarAnexo(model, usuario, controlador, pcclient);
            }
            if (entidad == AppConst.EntidadObservacion)
            {
                respuesta = GrabarObservacion(model, usuario, controlador, pcclient);
            }
            return respuesta;
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
