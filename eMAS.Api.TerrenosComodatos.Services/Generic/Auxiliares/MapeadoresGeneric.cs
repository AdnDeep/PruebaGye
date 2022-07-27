using eMAS.Api.TerrenosComodatos.ViewModel;
using System;
using System.Collections.Generic;

namespace eMAS.Api.TerrenosComodatos.Services
{
    public class MapeadoresGeneric
    {
        public MapeadoresGeneric()
        { 
        }
        public void MapearKeyValueSelectAStructKeyValueSelect(ref Tuple<List<KeyValueSelect>, string> entrada
            , ref ResultadoDTO<StructKeyValueSelect> salida, string key, string target)
        {
            var ls = entrada.Item1;
            StructKeyValueSelect data = new StructKeyValueSelect();

            data.datasource = ls;
            data.key = key;
            data.target = target;

            salida.dataresult = data;
        }
    }
}
