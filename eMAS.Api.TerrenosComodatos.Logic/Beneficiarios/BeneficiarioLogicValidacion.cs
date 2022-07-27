using eMAS.Api.TerrenosComodatos.Entities;
using eMAS.Api.TerrenosComodatos.IRepository;
using eMAS.Api.TerrenosComodatos.ViewModel;
using System;
using System.Collections.Generic;

namespace eMAS.Api.TerrenosComodatos.Logic
{
    public class BeneficiarioLogicValidacion
    {
        private readonly IRepositorioBeneficiarioValidacion _repositorioBeneficiarioValidacion;
        public BeneficiarioLogicValidacion(IRepositorioBeneficiarioValidacion repositorioBeneficiarioValidacion)
        {
            _repositorioBeneficiarioValidacion = repositorioBeneficiarioValidacion;
        }
        public Tuple<List<SmcValidacionEscritura>, string> ValidarEntidadAEscribir(BeneficiariosValidacion1Filter validacionFilter)
        {
            var respuestaDB = _repositorioBeneficiarioValidacion.ValidarEscritura(validacionFilter);
            return respuestaDB;
        }
    }
}
