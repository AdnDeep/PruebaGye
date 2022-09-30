using eMAS.Api.TerrenosComodatos.Entities;
using eMAS.Api.TerrenosComodatos.IRepository;
using eMAS.Api.TerrenosComodatos.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eMAS.Api.TerrenosComodatos.Logic
{
    public partial class UsuarioLogicLectura
    {
        private readonly IGestionRepositorioLecturaUsuarios _repositorioUsuarioLectura;
        public UsuarioLogicLectura(IGestionRepositorioLecturaUsuarios repositorioUsuarioLectura)
        {
            _repositorioUsuarioLectura = repositorioUsuarioLectura;
        }
        public async Task<RespuestaViewModel<List<UsuarioPerfilOpcion>>> ObtenerPerfilesPorUsuario(string userId)
        {
            var resultadoRemoto = await _repositorioUsuarioLectura
                                        .GetPerfilesOpcionesPorUsuario(userId);
            return resultadoRemoto;
        }
    }
}
