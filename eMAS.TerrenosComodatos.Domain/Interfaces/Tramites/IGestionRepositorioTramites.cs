using eMAS.TerrenosComodatos.Domain.DTOs;
using System;
using System.Collections.Generic;

namespace eMAS.TerrenosComodatos.Domain.Interfaces
{
    public interface IGestionRepositorioExternoTramites
    {
        ResultadoDTO<Tuple<List<TramiteListViewModel>,int>> GetTramitesVistaTodosPaginado(TramitePanelFilterViewModel panelModel, int numeroPagina, int numeroFilas);
        ResultadoDTO<Tuple<TramiteEditViewModel, string, short>> GetTramitePorId(short id);
    }
}
