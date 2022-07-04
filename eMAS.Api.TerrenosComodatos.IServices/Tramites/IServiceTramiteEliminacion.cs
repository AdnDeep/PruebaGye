using eMAS.Api.TerrenosComodatos.ViewModel;
using System.Collections.Generic;

namespace eMAS.Api.TerrenosComodatos.IServices
{
    public interface IServiceTramiteEliminacion
    {
        ResultadoDTO<int> Eliminar(short idTramite, string usuario, string controlador, string pcclient);
        ResultadoDTO<int> EliminarAnexo(short idAnexoTramite, string usuario, string controlador, string pcclient);
        ResultadoDTO<int> EliminarOficio(short idAnexoTramite, string usuario, string controlador, string pcclient);
        ResultadoDTO<int> EliminarObservacion(short idAnexoTramite, string usuario, string controlador, string pcclient);
        ResultadoDTO<int> EliminarTopografia(short idAnexoTramite, string usuario, string controlador, string pcclient);
    }
}
