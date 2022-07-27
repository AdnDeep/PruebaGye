using eMAS.Api.TerrenosComodatos.Entities;
using eMAS.Api.TerrenosComodatos.IRepository;
using System;

namespace eMAS.Api.TerrenosComodatos.Logic
{
    public class TramiteLogicEliminacion
    {
        private readonly IGestionRepositorioEliminacionTramites _repositorioTramiteEliminacion;
        public TramiteLogicEliminacion(IGestionRepositorioEliminacionTramites repositorioTramiteEliminacion)
        {
            _repositorioTramiteEliminacion = repositorioTramiteEliminacion;
        }
        public Tuple<short, string> Eliminar(SmcTramite tramite)
        {
            var resultadoBD = _repositorioTramiteEliminacion
                                        .Eliminar(tramite);
            return resultadoBD;
        }
        public Tuple<short, string> EliminarAnexo(SmcAnexoTramite anexoTramite) 
        {
            var resultadoBD = _repositorioTramiteEliminacion
                                        .EliminarAnexo(anexoTramite);
            return resultadoBD;
        }
        public Tuple<short, string> EliminarObservacion(SmcTramitesDesc observacionTramite) 
        {
            var resultadoBD = _repositorioTramiteEliminacion
                                        .EliminarObservacion(observacionTramite);
            return resultadoBD;
        }
        public Tuple<short, string> EliminarTopografiaTerreno(SmcTopografiaTerreno topografiaTramite) 
        {
            var resultadoBD = _repositorioTramiteEliminacion
                                        .EliminarTopografiaTerreno(topografiaTramite);
            return resultadoBD;
        }
        public Tuple<short, string> EliminarSeguimientoOficio(SmcOficioOtrasDireccione oficioTramite) 
        {
            var resultadoBD = _repositorioTramiteEliminacion
                                        .EliminarSeguimientoOficio(oficioTramite);
            return resultadoBD;
        }
    }
}
