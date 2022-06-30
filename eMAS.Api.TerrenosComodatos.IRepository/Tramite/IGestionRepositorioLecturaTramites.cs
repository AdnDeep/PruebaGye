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
        Tuple<SmcAnexoTramiteEdit, string, short> GetAnexoPorId(short id);
        Tuple<List<SmcAnexoTramiteEdit>, string> GetAnexosPorIdTramite(short idTramite);
        Tuple<SmcTramitesDescEdit, string, short> GetObservacionPorId(short id);
        Tuple<List<SmcTramitesDescEdit>, string> GetObservacionsPorIdTramite(short idTramite);
        Tuple<SmcTopografiaTerrenoEdit, string, short> GetTopografiaTerrenoPorId(short id);
        Tuple<List<SmcTopografiaTerrenoEdit>, string> GetTopografiaTerrenoPorIdTramite(short idTramite);
        Tuple<SmcOficioOtrasDireccioneEdit, string, short> GetSeguimientoOficioPorId(short id);
        Tuple<List<SmcOficioOtrasDireccioneEdit>, string> GetSeguimientoOficioPorIdTramite(short idTramite);

    }
}
