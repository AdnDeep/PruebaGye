using eMAS.Api.TerrenosComodatos.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eMAS.Api.TerrenosComodatos.IRepository
{
    public interface IGestionRepositorioLecturaUsuarios
    {
        Task<RespuestaViewModel<List<UsuarioPerfilOpcion>>> GetPerfilesOpcionesPorUsuario(string usuarioId);
    }
}
