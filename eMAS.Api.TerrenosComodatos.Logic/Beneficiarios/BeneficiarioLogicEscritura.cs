using eMAS.Api.TerrenosComodatos.Entities;
using eMAS.Api.TerrenosComodatos.IRepository;
using System;

namespace eMAS.Api.TerrenosComodatos.Logic
{
    public class BeneficiarioLogicEscritura
    {
        private readonly IRepositorioBeneficiarioEscritura _repositorioBeneficiarioEscritura;
        public BeneficiarioLogicEscritura(IRepositorioBeneficiarioEscritura repositorioBeneficiarioEscritura)
        {
            _repositorioBeneficiarioEscritura = repositorioBeneficiarioEscritura;
        }
        public Tuple<SmcBeneficiarioEdit, string> Agregar(SmcBeneficiario beneficiario)
        {
            var respuestaDB= _repositorioBeneficiarioEscritura.Add(beneficiario);
            return respuestaDB;
        }
        public Tuple<SmcBeneficiarioEdit, string> Actualizar(SmcBeneficiario beneficiario)
        {
            var respuestaDB = _repositorioBeneficiarioEscritura.Update(beneficiario);
            return respuestaDB;
        }
    }
}
