using eMAS.TerrenosComodatos.Domain.DTOs;
using eMAS.TerrenosComodatos.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace eMAS.TerrenosComodatos.Domain.Application
{
    public partial class CasesUsesGestionTramite : ICasesUsesGestionTramite
    {
        private ResultadoDTO<List<AnexoTramiteListViewModel>> LeerAnexoTodos(short idtramite)
        {
            ResultadoDTO<List<AnexoTramiteListViewModel>> resultadoVista = new ResultadoDTO<List<AnexoTramiteListViewModel>>();

            bool respValInputClient = _validadores.InputClientGetDetailListPorIdTramite(idtramite, ref resultadoVista);

            if (!respValInputClient)
                return resultadoVista;

            var respRepExterno = _repositorioExterno.GetAnexosPorIdTramite(idtramite);

            bool respValServ = _validadores.RespuestaServidorRemotoDetalleListaTodos(ref respRepExterno, ref resultadoVista);

            if (!respValServ)
                return resultadoVista;

            _mapeadores.RespuestaServidorDetailList(ref respRepExterno, ref resultadoVista);

            return resultadoVista;
        }
    }
}
