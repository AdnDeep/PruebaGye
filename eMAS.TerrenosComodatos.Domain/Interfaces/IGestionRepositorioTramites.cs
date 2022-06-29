using eMAS.TerrenosComodatos.Domain.DTOs;
using eMAS.TerrenosComodatos.Domain.Entities;
using System;
using System.Collections.Generic;

namespace eMAS.TerrenosComodatos.Domain.Interfaces
{
    public interface IGestionRepositorioLecturaTramites
    {
        ResultadoDTO<Tuple<List<Tramite>,int>> GetTramitesVistaTodosPaginado(TramitesPanelFilterModel panelModel, int numeroPagina, int numeroFilas);
        ResultadoDTO<Tuple<Tramite, string, short>> GetTramitePorId(short id);
    }
}
