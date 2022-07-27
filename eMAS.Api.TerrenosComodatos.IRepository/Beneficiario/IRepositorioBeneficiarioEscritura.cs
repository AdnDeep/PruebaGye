using eMAS.Api.TerrenosComodatos.Entities;
using System;


namespace eMAS.Api.TerrenosComodatos.IRepository
{
    public interface IRepositorioBeneficiarioEscritura
    {
        Tuple<SmcBeneficiarioEdit, string> Add(SmcBeneficiario beneficiario);
        Tuple<SmcBeneficiarioEdit, string> Update(SmcBeneficiario beneficiario);
    }
}
