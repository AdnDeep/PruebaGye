using eMAS.TerrenosComodatos.Domain.DTOs;
using System;
using System.Collections.Generic;

namespace eMAS.TerrenosComodatos.Domain.Interfaces
{
    public interface IGestionRepositorioExternoSeguridad
    {
        ResultadoViewModel ObtenerPermisoPorUsuario(string user, string controlador);
    }
}
