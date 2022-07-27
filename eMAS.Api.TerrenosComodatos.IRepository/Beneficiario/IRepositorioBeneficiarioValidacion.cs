using eMAS.Api.TerrenosComodatos.Entities;
using eMAS.Api.TerrenosComodatos.ViewModel;
using System;
using System.Collections.Generic;

namespace eMAS.Api.TerrenosComodatos.IRepository
{
    public interface IRepositorioBeneficiarioValidacion
    {
        Tuple<List<SmcValidacionEscritura>, string> ValidarEscritura(BeneficiariosValidacion1Filter validacionFilter); 
    }
}
