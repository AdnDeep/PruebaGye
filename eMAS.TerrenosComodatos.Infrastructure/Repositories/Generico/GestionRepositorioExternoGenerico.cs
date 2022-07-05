using eMAS.TerrenosComodatos.Domain.DTOs;
using eMAS.TerrenosComodatos.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace eMAS.TerrenosComodatos.Infrastructure.Repositories
{
    public class GestionRepositorioExternoGenerico : IGestionRepositorioExternoGenerico
    {
        public ResultadoDTO<Tuple<List<KeyValueSelect>, string>> ObtenerListadoGenerico(string keyparam)
        {
            throw new NotImplementedException();
        }
    }
}
