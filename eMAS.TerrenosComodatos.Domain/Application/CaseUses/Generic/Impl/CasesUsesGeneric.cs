using eMAS.TerrenosComodatos.Domain.DTOs;
using eMAS.TerrenosComodatos.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace eMAS.TerrenosComodatos.Domain.Application
{
    public class CasesUsesGeneric : ICasesUsesGeneric
    {
        private readonly IGestionRepositorioExternoGenerico _repositorioExterno;
        private readonly ValidadoresGenerico _validadores;
        private readonly MapeadoresGenerico _mapeadores;
        private readonly ILogger<CasesUsesGeneric> _logger;
        public CasesUsesGeneric(ILogger<CasesUsesGeneric> logger
            , MapeadoresGenerico mapeadores
            , ValidadoresGenerico validadores
            , IGestionRepositorioExternoGenerico repositorioExterno)
        {
            _repositorioExterno = repositorioExterno;
            _validadores = validadores;
            _mapeadores = mapeadores;
            _logger = logger;
        }
        public StructKeyValueSelect GetSingleDatasources(string key, string target)
        {
            StructKeyValueSelect resultadoClte = new StructKeyValueSelect();
            bool respValClte = _validadores.InputClientGetDsrByKey(key, target, ref resultadoClte);

            if (!respValClte)
                return resultadoClte;

            var respServ = _repositorioExterno.ObtenerListadoGenerico(key, target);

            bool respValRespServ = _validadores.RespuestaServidorGetDsrByKey(ref respServ, ref resultadoClte);

            if (!respValRespServ)
                return resultadoClte;

            _mapeadores.GenerateSingleDsrModel(ref respServ, ref resultadoClte);

            return resultadoClte;
        }
    }
}
