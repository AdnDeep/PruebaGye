using eMAS.TerrenosComodatos.Domain.DTOs;
using System.Collections.Generic;

namespace eMAS.TerrenosComodatos.Domain.Application
{
    public partial class CasesUsesGestionTramite : ICasesUsesGestionTramite
    {
        private ResultadoDTO<List<OficioTramiteListViewModel>> LeerOficioTodos(short idtramite)
        {
            ResultadoDTO<List<OficioTramiteListViewModel>> resultadoVista = new ResultadoDTO<List<OficioTramiteListViewModel>>();

            bool respValInputClient = _validadores.InputClientGetDetailListPorIdTramite(idtramite, ref resultadoVista);

            if (!respValInputClient)
                return resultadoVista;

            var respRepExterno = _repositorioExterno.GetOficiosPorIdTramite(idtramite);

            bool respValServ = _validadores.RespuestaServidorRemotoDetalleListaTodos<List<OficioTramiteListViewModel>>(ref respRepExterno, ref resultadoVista);

            if (!respValServ)
                return resultadoVista;

            _mapeadores.RespuestaServidorDetailList(ref respRepExterno, ref resultadoVista);

            // Procesamiento 2 se traducen fechas a formato string
            _mapeadores.DataLecturaTodosOficio(ref resultadoVista);

            return resultadoVista;
        }
    }
}
