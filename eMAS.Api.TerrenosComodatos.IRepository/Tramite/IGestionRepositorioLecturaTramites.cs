using eMAS.Api.TerrenosComodatos.Entities;
using eMAS.Api.TerrenosComodatos.ViewModel;
using System;
using System.Collections.Generic;

namespace eMAS.Api.TerrenosComodatos.IRepository
{
    public interface IGestionRepositorioLecturaTramites
    {
        Tuple<List<SmcTramitePaginado>, int> GetTramitesVistaTodosPaginado(TramitesPanelFilterModel panelModel, int numeroPagina, int numeroFilas);
        Tuple<SmcTramiteEdit, string, short> GetTramitePorId(short id);
    }
}
