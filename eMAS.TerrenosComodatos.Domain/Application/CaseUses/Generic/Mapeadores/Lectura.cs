
using eMAS.TerrenosComodatos.Domain.DTOs;


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
    }
}
