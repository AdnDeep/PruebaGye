using eMAS.TerrenosComodatos.Domain.DTOs;


namespace eMAS.TerrenosComodatos.Domain.Interfaces
{
    public interface IGestionRepositorioExternoGenerico
    {
        ResultadoDTO<StructKeyValueSelect> ObtenerListadoGenerico(string keyparam, string keyentity, string target);
        ResultadoDTO<ExportSingleResult> ObtenerDataExportacion(string codigo, string paramsFilter);    
    }
}
