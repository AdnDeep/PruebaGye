using eMAS.TerrenosComodatos.Domain.DTOs;
using System;
using System.Collections.Generic;

namespace eMAS.TerrenosComodatos.Domain.Interfaces
{
    public interface IGestionRepositorioExternoGenerico
    {
        ResultadoDTO<Tuple<List<KeyValueSelect>, string>> ObtenerListadoGenerico(string keyparam);
    }
}
