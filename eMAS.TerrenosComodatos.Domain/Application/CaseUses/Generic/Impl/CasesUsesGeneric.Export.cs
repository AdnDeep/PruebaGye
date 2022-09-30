using eMAS.TerrenosComodatos.Domain.DTOs;
using eMAS.TerrenosComodatos.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace eMAS.TerrenosComodatos.Domain.Application
{
    public partial class CasesUsesGeneric : ICasesUsesGeneric
    {
        public ResultadoDTO<ExportSingleResult> GetSingleExport(ExportSingleRequest input)
        {
            ResultadoDTO<ExportSingleResult> resultadoClte = new ResultadoDTO<ExportSingleResult>();
            resultadoClte.dataresult = resultadoClte.dataresult ?? new ExportSingleResult();

            bool respValClte = _validadores.InputClientGetExport(input, ref resultadoClte);

            if (!respValClte)
                return resultadoClte;

            var respServ = _repositorioExterno.ObtenerDataExportacion(input.Codigo, input.ParamsFilter);

            bool respValRespServ = _validadores.InputServerGetExport(ref respServ, ref resultadoClte);

            if (!respValRespServ)
                return resultadoClte;

            _mapeadores.GenerateSingleExportModel(ref input, ref respServ, ref resultadoClte);

            return resultadoClte;
        }
    }
}
