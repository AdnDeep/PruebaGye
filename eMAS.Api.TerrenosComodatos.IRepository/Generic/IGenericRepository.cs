using eMAS.Api.TerrenosComodatos.ViewModel;
using System;
using System.Collections.Generic;

namespace eMAS.Api.TerrenosComodatos.IRepository
{
    public interface IGenericRepository
    {
        Tuple<List<KeyValueSelect>, string> GetSingleSelect(string keyparam, string keyentity);
        Tuple<List<ExportSingle>, string, string> GetSingleExport(string codigo, string paramsFilter);
    }
}
