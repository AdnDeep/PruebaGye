using eMAS.Api.TerrenosComodatos.Entities;
using eMAS.Api.TerrenosComodatos.ViewModel;
using System;
using System.Collections.Generic;

namespace eMAS.Api.TerrenosComodatos.IRepository
{
    public interface IGestionRepositorioEscrituraTramites
    {
        Tuple<List<SmcValidaDataServidor>, string> GetDataValidation(string paramFilter, string objObtieneDataValidacion);
        Tuple<short, string> Agregar(SmcTramite tramite);
        Tuple<short, string> Actualizar(SmcTramite tramite);
        Tuple<short, string> AgregarAnexo(SmcAnexoTramite anexoTramite);
        Tuple<short, string> ActualizarAnexo(SmcAnexoTramite anexoTramite);
        Tuple<short, string> AgregarObservacion(SmcTramitesDesc observacionTramite);
        Tuple<short, string> ActualizarObservacion(SmcTramitesDesc observacionTramite);
        Tuple<short, string> AgregarTopografiaTerreno(SmcTopografiaTerreno topografiaTramite);
        Tuple<short, string> ActualizarTopografiaTerreno(SmcTopografiaTerreno topografiaTramite);
        Tuple<short, string> AgregarSeguimientoOficio(SmcOficioOtrasDireccione oficioTramite);
        Tuple<short, string> ActualizarSeguimientoOficio(SmcOficioOtrasDireccione oficioTramite);
    }
}
