using eMAS.TerrenosComodatos.Domain.DTOs;

namespace eMAS.TerrenosComodatos.Domain.Application
{
    public interface ICasesUsesGestionTramite
    {
        ResultadoDTO<DataPagineada<TramiteListViewModel>> LeerTodosPaginado(string dataPanel, string resultContainer, int numeroPagina, int numeroFila);
        ResultadoDTO<TramiteEditViewModel> LeerPorId(short id);
        TramiteReportClientViewModel ReporteGeneral(short id);
        ResultadoDTO<int> GrabarTramite(TramiteEditViewModel model, string usuario, string controlador, string pcclient);
        ResultadoDTO<int> EliminarTramite(short id, string usuario, string controlador, string pcclient);
        object LeerDetalleListaTodos(short idtramite, string entidad);
        ResultadoDTO<AnexoTramiteEditViewModel> LeerDetalleAnexoPorId(short identidad);
        ResultadoDTO<ObservacionTramiteEditViewModel> LeerDetalleObservacionPorId(short identidad);
        ResultadoDTO<OficioTramiteEditViewModel> LeerDetalleOficioPorId(short identidad);
        ResultadoDTO<TopografiaTerrenoEditViewMoel> LeerDetalleTopografiaPorId(short identidad);
        object GrabarDetalle(string model, string usuario, string controlador, string pcclient, string entidad);
        object EliminarDetalle(short id, string usuario, string controlador, string pcclient, string entidad);
    }
}
