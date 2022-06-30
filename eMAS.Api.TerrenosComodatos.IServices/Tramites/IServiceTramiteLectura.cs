using eMAS.Api.TerrenosComodatos.ViewModel;
using System.Collections.Generic;

namespace eMAS.Api.TerrenosComodatos.IServices
{
    public interface IServiceTramiteLectura
    {
        ResultadoDTO<DataPagineada<TramitesListViewModel>> ConsultarTramitesTodosPaginado(string panelFilter
            , string resultContainer, int numeroPagina, int numeroFila);
        ResultadoDTO<TramiteEditViewModel> ConsultarPorId(short id);
        ResultadoDTO<List<AnexoTramiteListViewModel>> ConsultarAnexosPorIdTramite(short idTramite);
        ResultadoDTO<AnexoTramiteEditViewModel> ConsultarAnexoPorId(short id);
        ResultadoDTO<List<ObservacionTramiteListViewModel>> ConsultarObservacionesPorIdTramite(short idTramite);
        ResultadoDTO<ObservacionTramiteEditViewModel> ConsultarObservacionPorId(short id);
        ResultadoDTO<List<TopografiaTerrenoListViewMoel>> ConsultarTopografiasPorIdTramite(short idTramite);
        ResultadoDTO<TopografiaTerrenoEditViewMoel> ConsultarTopografiaPorId(short id);
        ResultadoDTO<List<OficioTramiteListViewModel>> ConsultarOficiosPorIdTramite(short idTramite);
        ResultadoDTO<OficioTramiteEditViewModel> ConsultarOficioPorId(short id);
    }
}
