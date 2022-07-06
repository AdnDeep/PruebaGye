using eMAS.TerrenosComodatos.Domain.DTOs;

namespace eMAS.TerrenosComodatos.Domain.Application
{
    public class CasesUsesGeneric : ICasesUsesGeneric
    {
        public StructKeyValueSelect GetSingleDatasources(string key, string target)
        {
            return new StructKeyValueSelect();
            //throw new System.NotImplementedException();
        }
    }
}
