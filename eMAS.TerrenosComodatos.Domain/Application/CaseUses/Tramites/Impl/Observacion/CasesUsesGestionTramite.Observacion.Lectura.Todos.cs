using eMAS.TerrenosComodatos.Domain.DTOs;
using System.Collections.Generic;

namespace eMAS.TerrenosComodatos.Domain.Application
{
    public partial class CasesUsesGestionTramite : ICasesUsesGestionTramite
    {
        private ResultadoDTO<List<ObservacionTramiteListViewModel>> LeerObservacionTodos(short idtramite)
        {
            ResultadoDTO<List<ObservacionTramiteListViewModel>> resultadoVista = new ResultadoDTO<List<ObservacionTramiteListViewModel>>();

            bool respValInputClient = _validadores.InputClientGetDetailListPorIdTramite(idtramite, ref resultadoVista);

            if (!respValInputClient)
                return resultadoVista;

            var respRepExterno = _repositorioExterno.GetObservacionsPorIdTramite(idtramite);

            bool respValServ = _validadores.RespuestaServidorRemotoDetalleListaTodos(ref respRepExterno, ref resultadoVista);

            if (!respValServ)
                return resultadoVista;

            _mapeadores.RespuestaServidorDetailList(ref respRepExterno, ref resultadoVista);

            // Procesamiento 2 se traducen fechas a formato string
            _mapeadores.DataLecturaTodosObservacion(ref resultadoVista);

            return resultadoVista;
        }
    }
}
