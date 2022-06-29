
using eMAS.Api.TerrenosComodatos.IRepository;
using eMAS.Api.TerrenosComodatos.ViewModel;
using System;
using System.Collections.Generic;

namespace eMAS.Api.TerrenosComodatos.Logic.Generic
{
    public class DataProviderLogicGeneric
    {
        private readonly IGenericRepository _genericRepository;
        public DataProviderLogicGeneric(IGenericRepository genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public Tuple<List<KeyValueSelect>, string> ObtenerDataByParam(string keyParam)
        {
            var resultadoBD = _genericRepository.GetSingleSelect(keyParam);
            return resultadoBD;
        }
    }
}
