
using eMAS.TerrenosComodatos.Domain.DTOs;
using System;

namespace eMAS.TerrenosComodatos.Domain.Application
{
    public partial class MapeadoresGenerico
    {
        public MapeadoresGenerico()
        {
        }
        public void GenerateSingleDsrModel(ref ResultadoDTO<StructKeyValueSelect> model
            , ref StructKeyValueSelect salida)
        {
            salida.key = model.dataresult.key;
            salida.target = model.dataresult.target;
            salida.datasource = model.dataresult.datasource;
        }
        public void GenerateSingleExportModel(ref ExportSingleRequest request, ref ResultadoDTO<ExportSingleResult> entrada
            , ref ResultadoDTO<ExportSingleResult> salida)
        {
            salida.dataresult = new ExportSingleResult();
            //salida.dataresult.ContenidoArchivoBase64 = entrada.dataresult.ContenidoArchivoBase64;
            salida.dataresult.bytecontenidoarchivo = Convert.FromBase64String(entrada.dataresult.contenidoarchivobase64);
            salida.dataresult.codigoestado = entrada.dataresult.codigoestado;
            salida.dataresult.nombrearchivo = entrada.dataresult.nombrearchivo;
            salida.dataresult.RutaRetorno = request.RutaRetorno;
            salida.tipo = entrada.tipo;
            salida.mensaje = entrada.tipo;
        }
    }
}
