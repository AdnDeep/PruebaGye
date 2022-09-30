
using eMAS.Api.TerrenosComodatos.ViewModel;

namespace eMAS.Api.TerrenosComodatos.IServices
{
    public interface IServiceDataProviderGeneric
    {
        ResultadoDTO<StructKeyValueSelect> GetDataSrc(string key1, string keyEntity, string target);
        ResultadoDTO<ExportSingleResult> GetDataExport(string codigo, string paramsFilter);
    }
}
