
using eMAS.Api.TerrenosComodatos.IRepository;
using eMAS.Api.TerrenosComodatos.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace eMAS.Api.TerrenosComodatos.Logic.Generic
{
    public class DataProviderLogicGeneric
    {
        private readonly IGenericRepository _genericRepository;
        public DataProviderLogicGeneric(IGenericRepository genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public Tuple<List<KeyValueSelect>, string> ObtenerDataByParam(string keyParam, string keyEntity)
        {
            var resultadoBD = _genericRepository.GetSingleSelect(keyParam, keyEntity);
            return resultadoBD;
        }
        public Tuple<List<ExportSingle>, string, string> ObtenerDataExportByParam(string codigo, string paramsFilter)
        {
            var resultadoBD = _genericRepository.GetSingleExport(codigo, paramsFilter);
            return resultadoBD;
        }
        public void ProcesaRespuestaExportSingleData(
            ref Tuple<List<ExportSingle>, string, string> entrada
            , ref ResultadoDTO<ExportSingleResult> salida)
        {
            string contenidoArchivo = "";
            DateTime now = DateTime.Now;
            string strNow = now.ToString("yyyyMMddHHmmss");
            List<ExportSingle> lsResult = entrada.Item1;
            string columnas = entrada.Item2;
            string nombreArchivo = entrada.Item3;

            var builder = new StringBuilder();

            builder.AppendLine(columnas);

            foreach (var det  in lsResult)
            {
                string linea = det.ResultRow != null ? det.ResultRow.Trim().Replace("\n", ""):"";
                builder.AppendLine($"{linea}");
            }

            contenidoArchivo = builder.ToString();

            byte[] byteContenidoArchivo = Encoding.ASCII.GetBytes(contenidoArchivo);

            salida.dataresult.contenidoarchivobase64 = Convert.ToBase64String(byteContenidoArchivo);
            salida.dataresult.nombrearchivo = $"{nombreArchivo}_{strNow}.csv";
            salida.dataresult.codigoestado = 200;
            salida.tipo = "EXITO";

        }
    }
}
