using eMAS.Api.TerrenosComodatos.Entities;
using eMAS.Api.TerrenosComodatos.IRepository;
using System;

namespace eMAS.Api.TerrenosComodatos.Logic
{
    public class BeneficiarioLogicEliminacion
    {
        private readonly IRepositorioBeneficiarioEliminacion _repositorioBeneficiarioEliminacion;
        public BeneficiarioLogicEliminacion(IRepositorioBeneficiarioEliminacion repositorioBeneficiarioEliminacion)
        {
            _repositorioBeneficiarioEliminacion = repositorioBeneficiarioEliminacion;
        }
        public string Eliminar(SmcBeneficiario beneficiario)
        {
            var respuestaDB= _repositorioBeneficiarioEliminacion.Delete(beneficiario);
            return respuestaDB;
        }
    }
}
