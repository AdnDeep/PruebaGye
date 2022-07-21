using eMAS.TerrenosComodatos.Domain.DTOs;
using System.Collections.Generic;

namespace eMAS.TerrenosComodatos.Domain.Application
{
    public partial class CasesUsesGestionTramite : ICasesUsesGestionTramite
    {
        private ResultadoDTO<List<TopografiaTerrenoListViewMoel>> LeerTopografiaTodos(short idtramite)
        {
            ResultadoDTO<List<TopografiaTerrenoListViewMoel>> resultadoVista = new ResultadoDTO<List<TopografiaTerrenoListViewMoel>>();

            bool respValInputClient = _validadores.InputClientGetDetailListPorIdTramite(idtramite, ref resultadoVista);

            if (!respValInputClient)
                return resultadoVista;

            var respRepExterno = _repositorioExterno.GetTopografiasPorIdTramite(idtramite);

            bool respValServ = _validadores.RespuestaServidorRemotoDetalleListaTodos<List<TopografiaTerrenoListViewMoel>>(ref respRepExterno, ref resultadoVista);

            if (!respValServ)
                return resultadoVista;

            _mapeadores.RespuestaServidorDetailList(ref respRepExterno, ref resultadoVista);

            // Procesamiento 2 se traducen fechas a formato string
            _mapeadores.DataLecturaTodosTopografia(ref resultadoVista);

            return resultadoVista;
        }
    }
}
