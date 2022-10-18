using eMAS.Api.TerrenosComodatos.Entities;
using eMAS.Api.TerrenosComodatos.IRepository;
using eMAS.Api.TerrenosComodatos.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eMAS.Api.TerrenosComodatos.Logic
{
    public partial class CatalogoLogic
    {
        private readonly IGestionRepositorioLecturaCatalogo _repositorioCatalogoLectura;
        public CatalogoLogic(IGestionRepositorioLecturaCatalogo repositorioCatalogoLectura)
        {
            _repositorioCatalogoLectura = repositorioCatalogoLectura;
        }
        public Task<List<SmcCatalogoConfiguracion>> ObtenerCatalogoPorCodigoYTipo(string codigo,
            string tipo, string claveBusqueda1, string claveBusqueda2)
        {
            var resultadoBD = _repositorioCatalogoLectura.GetCatalogoPorCodigoYTipo(codigo
                    , tipo, claveBusqueda1, claveBusqueda2);

            return resultadoBD;
        }
    }
}
