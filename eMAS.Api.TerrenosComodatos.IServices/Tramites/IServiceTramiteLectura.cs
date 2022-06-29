using eMAS.Api.TerrenosComodatos.ViewModel;

namespace eMAS.Api.TerrenosComodatos.IServices
{
    public interface IServiceTramiteLectura
    {
        ResultadoDTO<DataPagineada<TramitesListViewModel>> ConsultarTramitesTodosPaginado(string panelFilter
            , string resultContainer, int numeroPagina, int numeroFila);
        ResultadoDTO<TramiteEditViewModel> ConsultarPorId(short id);
        ResultadoDTO<string> ConsultarAnexosPorIdTramite(short idTramite);
        ResultadoDTO<string> ConsultarAnexoPorId(short id);
        ResultadoDTO<string> ConsultarObservacionesPorIdTramite(short idTramite);
        ResultadoDTO<string> ConsultarObservacionPorId(short id);
        ResultadoDTO<string> ConsultarTopografiasPorIdTramite(short idTramite);
        ResultadoDTO<string> ConsultarTopografiaPorId(short id);
        ResultadoDTO<string> ConsultarOficiosPorIdTramite(short idTramite);
        ResultadoDTO<string> ConsultarOficioPorId(short id);
    }
}
