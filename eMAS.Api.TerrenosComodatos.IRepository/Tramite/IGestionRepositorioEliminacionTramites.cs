using eMAS.Api.TerrenosComodatos.Entities;
using eMAS.Api.TerrenosComodatos.ViewModel;
using System;
using System.Collections.Generic;

namespace eMAS.Api.TerrenosComodatos.IRepository
{
    public interface IGestionRepositorioEliminacionTramites
    {
        Tuple<short, string> Eliminar(SmcTramite tramite);
        Tuple<short, string> EliminarAnexo(SmcAnexoTramite anexoTramite);
        Tuple<short, string> EliminarObservacion(SmcTramitesDesc observacionTramite);
        Tuple<short, string> EliminarTopografiaTerreno(SmcTopografiaTerreno topografiaTramite);
        Tuple<short, string> EliminarSeguimientoOficio(SmcOficioOtrasDireccione oficioTramite);
    }
}
