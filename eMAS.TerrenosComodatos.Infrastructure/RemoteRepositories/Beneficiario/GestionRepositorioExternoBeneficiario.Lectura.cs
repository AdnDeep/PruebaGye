using eMAS.TerrenosComodatos.Domain.DTOs;
using eMAS.TerrenosComodatos.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace eMAS.TerrenosComodatos.Infrastructure.RemoteRepositories
{
    public partial class GestionRepositorioExternoBeneficiario : IGestionRepositorioExternoBeneficiario
    {
        public ResultadoDTO<string> ActualizarBeneficiario(BeneficiarioEditViewModel model)
        {
            throw new NotImplementedException();
        }

        public ResultadoDTO<string> CrearBeneficiario(BeneficiarioEditViewModel model)
        {
            throw new NotImplementedException();
        }

        public ResultadoDTO<string> EliminarBeneficiario(BeneficiarioDeleteViewModel model)
        {
            throw new NotImplementedException();
        }

        public ResultadoDTO<Tuple<BeneficiarioEditViewModel, string, short>> GetBeneficiarioPorId(short id)
        {
            throw new NotImplementedException();
        }

    }
}
