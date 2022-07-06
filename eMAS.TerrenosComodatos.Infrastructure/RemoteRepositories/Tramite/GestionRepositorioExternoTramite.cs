using eMAS.TerrenosComodatos.Domain.DTOs;
using eMAS.TerrenosComodatos.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace eMAS.TerrenosComodatos.Infrastructure.RemoteRepositories
{
    public class GestionRepositorioExternoTramite : IGestionRepositorioExternoTramite
    {
        public ResultadoDTO<Tuple<TramiteEditViewModel, string, short>> GetTramitePorId(short id)
        {
            throw new NotImplementedException();
        }

        public ResultadoDTO<Tuple<List<TramiteListViewModel>, int>> GetTramitesVistaTodosPaginado(TramitePanelFilterViewModel panelModel, int numeroPagina, int numeroFilas)
        {
            throw new NotImplementedException();
        }
    }
}
