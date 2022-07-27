using eMAS.Api.TerrenosComodatos.Entities;
using eMAS.Api.TerrenosComodatos.IRepository;
using System;
using System.Collections.Generic;

namespace eMAS.Api.TerrenosComodatos.Logic
{
    public class TramiteLogicEscritura
    {
        private readonly IGestionRepositorioEscrituraTramites _repositorioTramitesEscritura;
        public TramiteLogicEscritura(IGestionRepositorioEscrituraTramites repositorioTramitesEscritura)
        {
            _repositorioTramitesEscritura = repositorioTramitesEscritura;
        }
        public Tuple<short, string> Agregar(SmcTramite tramite)
        {
            var resultadoBD = _repositorioTramitesEscritura
                                        .Agregar(tramite);
            return resultadoBD;
        }
        public Tuple<short, string> Actualizar(SmcTramite tramite)
        {
            var resultadoBD = _repositorioTramitesEscritura
                                    .Actualizar(tramite);
            return resultadoBD;
        }
        public Tuple<short, string> AgregarAnexo(SmcAnexoTramite anexoTramite)
        {
            var resultadoBD = _repositorioTramitesEscritura
                                    .AgregarAnexo(anexoTramite);
            return resultadoBD;
        }
        public Tuple<short, string> ActualizarAnexo(SmcAnexoTramite anexoTramite)
        {
            var resultadoBD = _repositorioTramitesEscritura
                                    .ActualizarAnexo(anexoTramite);
            return resultadoBD;
        }
        public Tuple<short, string> AgregarObservacion(SmcTramitesDesc observacionTramite)
        {
            var resultadoBD = _repositorioTramitesEscritura
                                    .AgregarObservacion(observacionTramite);
            return resultadoBD;
        }
        public Tuple<short, string> ActualizarObservacion(SmcTramitesDesc observacionTramite)
        {
            var resultadoBD = _repositorioTramitesEscritura
                                    .ActualizarObservacion(observacionTramite);
            return resultadoBD;
        }
        public Tuple<short, string> AgregarTopografiaTerreno(SmcTopografiaTerreno topografiaTramite)
        {
            var resultadoBD = _repositorioTramitesEscritura
                                    .AgregarTopografiaTerreno(topografiaTramite);
            return resultadoBD;
        }
        public Tuple<short, string> ActualizarTopografiaTerreno(SmcTopografiaTerreno topografiaTramite)
        {
            var resultadoBD = _repositorioTramitesEscritura
                                    .ActualizarTopografiaTerreno(topografiaTramite);
            return resultadoBD;
        }
        public Tuple<short, string> AgregarSeguimientoOficio(SmcOficioOtrasDireccione oficioTramite)
        {
            var resultadoBD = _repositorioTramitesEscritura
                                    .AgregarSeguimientoOficio(oficioTramite);
            return resultadoBD;
        }
        public Tuple<short, string> ActualizarSeguimientoOficio(SmcOficioOtrasDireccione oficioTramite)
        {
            var resultadoBD = _repositorioTramitesEscritura
                                    .ActualizarSeguimientoOficio(oficioTramite);
            return resultadoBD;
        }
        public Tuple<List<SmcValidaDataServidor>, string> ValidarEntidadAEscribir(string paramFilter
            , string objObtieneDataValidacion)
        {
            var respuestaDB = _repositorioTramitesEscritura
                                    .GetDataValidation(paramFilter, objObtieneDataValidacion);
            return respuestaDB;
        }
    }
}
