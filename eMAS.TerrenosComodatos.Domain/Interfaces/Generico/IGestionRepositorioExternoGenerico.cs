using eMAS.TerrenosComodatos.Domain.DTOs;
using System;
using System.Collections.Generic;

namespace eMAS.TerrenosComodatos.Domain.Interfaces
{
    public interface IGestionRepositorioExternoGenerico
    {
        ResultadoDTO<StructKeyValueSelect> ObtenerListadoGenerico(string keyparam, string target);
    }
}
