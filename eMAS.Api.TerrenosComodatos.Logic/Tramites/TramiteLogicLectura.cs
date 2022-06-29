using eMAS.Api.TerrenosComodatos.Entities;
using eMAS.Api.TerrenosComodatos.IRepository;
using eMAS.Api.TerrenosComodatos.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eMAS.Api.TerrenosComodatos.Logic
{
    public class TramiteLogicLectura
    {
        private readonly IGestionRepositorioLecturaTramites _repositorioTramiteLectura;
        public TramiteLogicLectura(IGestionRepositorioLecturaTramites repositorioTramiteLectura)
        {
            _repositorioTramiteLectura = repositorioTramiteLectura;
        }
        public Tuple<List<SmcTramitePaginado>, int> ObtenerTramitesPaginado(TramitesPanelFilterModel panelModel, int numeroPagina, int numeroFilas)
        {
            var resultadoBD = _repositorioTramiteLectura
                                        .GetTramitesVistaTodosPaginado(panelModel, numeroPagina, numeroFilas);
            return resultadoBD;
        }
        public Tuple<SmcTramiteEdit, string, short> ObtenerTramitePorId(short id)
        {
            var resultadoBD = _repositorioTramiteLectura
                                            .GetTramitePorId(id);

            return resultadoBD;
        }
    }
}
