using eMAS.Api.TerrenosComodatos.Entities;
using System;


namespace eMAS.Api.TerrenosComodatos.IRepository
{
    public interface IRepositorioBeneficiarioEliminacion
    {
        string Delete(SmcBeneficiario beneficiario);
    }
}
