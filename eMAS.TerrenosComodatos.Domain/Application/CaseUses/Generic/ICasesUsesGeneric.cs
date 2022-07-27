using eMAS.TerrenosComodatos.Domain.DTOs;

namespace eMAS.TerrenosComodatos.Domain.Application
{
    public interface ICasesUsesGeneric
    {
        StructKeyValueSelect GetSingleDatasources(string key, string keyentity, string target);

    }
}
