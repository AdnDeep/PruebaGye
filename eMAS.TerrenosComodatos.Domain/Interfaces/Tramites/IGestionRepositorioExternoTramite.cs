using eMAS.TerrenosComodatos.Domain.DTOs;
using System;
using System.Collections.Generic;

namespace eMAS.TerrenosComodatos.Domain.Interfaces
{
    public interface IGestionRepositorioExternoTramite
    {
        ResultadoDTO<TramiteReportServerViewModel> ObtenerReportePdfTramite(short id, string name);
        ResultadoDTO<int> Eliminar(short id, string usuario, string controlador, string pcclient);
        ResultadoDTO<int> Crear(TramiteEditViewModel model, string usuario, string controlador, string pcclient);
        ResultadoDTO<int> Actualizar(TramiteEditViewModel model, string usuario, string controlador, string pcclient);
        ResultadoDTO<DataPagineada<TramiteListViewModel>> GetVistaTodosPaginado(string panelModel, string resultContainer, int numeroPagina, int numeroFilas);
        ResultadoDTO<TramiteEditViewModel> GetPorId(short id);
        
        ResultadoDTO<int> EliminarAnexo(short id, string usuario, string controlador, string pcclient);
        ResultadoDTO<int> CrearAnexo(AnexoTramiteEditViewModel model, string usuario, string controlador, string pcclient);
        ResultadoDTO<int> ActualizarAnexo(AnexoTramiteEditViewModel model, string usuario, string controlador, string pcclient);
        ResultadoDTO<List<AnexoTramiteListViewModel>> GetAnexosPorIdTramite(short id);
        ResultadoDTO<AnexoTramiteEditViewModel> GetAnexoPorId(short id);

        ResultadoDTO<int> EliminarObservacion(short id, string usuario, string controlador, string pcclient);
        ResultadoDTO<int> CrearObservacion(ObservacionTramiteEditViewModel model, string usuario, string controlador, string pcclient);
        ResultadoDTO<int> ActualizarObservacion(ObservacionTramiteEditViewModel model, string usuario, string controlador, string pcclient);
        ResultadoDTO<List<ObservacionTramiteListViewModel>> GetObservacionsPorIdTramite(short id);
        ResultadoDTO<ObservacionTramiteEditViewModel> GetObservacionPorId(short id);

        ResultadoDTO<int> EliminarOficio(short id, string usuario, string controlador, string pcclient);
        ResultadoDTO<int> CrearOficio(OficioTramiteEditViewModel model, string usuario, string controlador, string pcclient);
        ResultadoDTO<int> ActualizarOficio(OficioTramiteEditViewModel model, string usuario, string controlador, string pcclient);
        ResultadoDTO<List<OficioTramiteListViewModel>> GetOficiosPorIdTramite(short id);
        ResultadoDTO<OficioTramiteEditViewModel> GetOficioPorId(short id);

        ResultadoDTO<int> EliminarTopografia(short id, string usuario, string controlador, string pcclient);
        ResultadoDTO<int> CrearTopografia(TopografiaTerrenoEditViewMoel model, string usuario, string controlador, string pcclient);
        ResultadoDTO<int> ActualizarTopografia(TopografiaTerrenoEditViewMoel model, string usuario, string controlador, string pcclient);
        ResultadoDTO<List<TopografiaTerrenoListViewMoel>> GetTopografiasPorIdTramite(short id);
        ResultadoDTO<TopografiaTerrenoEditViewMoel> GetTopografiaPorId(short id);

    }
}
