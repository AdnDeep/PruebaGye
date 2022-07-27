using eMAS.Api.TerrenosComodatos.ViewModel;
using System.Collections.Generic;

namespace eMAS.Api.TerrenosComodatos.IServices
{
    public interface IServiceTramiteEscritura
    {
        ResultadoDTO<int> Agregar(TramiteEditViewModel model, string usuario, string controlador, string pcclient);
        ResultadoDTO<int> Actualizar(TramiteEditViewModel model, string usuario, string controlador, string pcclient);
        ResultadoDTO<int> AgregarAnexo(AnexoTramiteEditViewModel model, string usuario, string controlador, string pcclient);
        ResultadoDTO<int> ActualizarAnexo(AnexoTramiteEditViewModel model, string usuario, string controlador, string pcclient);
        ResultadoDTO<int> AgregarOficio(OficioTramiteEditViewModel model, string usuario, string controlador, string pcclient);
        ResultadoDTO<int> ActualizarOficio(OficioTramiteEditViewModel model, string usuario, string controlador, string pcclient);
        ResultadoDTO<int> AgregarObservacion(ObservacionTramiteEditViewModel model, string usuario, string controlador, string pcclient);
        ResultadoDTO<int> ActualizarObservacion(ObservacionTramiteEditViewModel model, string usuario, string controlador, string pcclient);
        ResultadoDTO<int> AgregarTopografia(TopografiaTerrenoEditViewMoel model, string usuario, string controlador, string pcclient);
        ResultadoDTO<int> ActualizarTopografia(TopografiaTerrenoEditViewMoel model, string usuario, string controlador, string pcclient);
    }
}
