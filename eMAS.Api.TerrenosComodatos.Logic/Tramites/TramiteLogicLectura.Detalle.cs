using eMAS.Api.TerrenosComodatos.Entities;
using eMAS.Api.TerrenosComodatos.IRepository;
using eMAS.Api.TerrenosComodatos.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eMAS.Api.TerrenosComodatos.Logic
{
    public partial class TramiteLogicLectura
    {
        public Tuple<SmcAnexoTramiteEdit, string, short> GetAnexoPorId(short id)
        {
            var resultadoBD = _repositorioTramiteLectura
                                        .GetAnexoPorId(id);
            return resultadoBD;
        }
        public Tuple<List<SmcAnexoTramiteEdit>, string> GetAnexosPorIdTramite(short idTramite)
        {
            var resultadoBD = _repositorioTramiteLectura
                                           .GetAnexosPorIdTramite(idTramite);
            return resultadoBD;
        }
        public Tuple<SmcTramitesDescEdit, string, short> GetObservacionPorId(short id)
        {
            var resultadoBD = _repositorioTramiteLectura
                                              .GetObservacionPorId(id);
            return resultadoBD;
        }
        public Tuple<List<SmcTramitesDescEdit>, string> GetObservacionsPorIdTramite(short idTramite)
        {
            var resultadoBD = _repositorioTramiteLectura
                                              .GetObservacionsPorIdTramite(idTramite);
            return resultadoBD;
        }
        public Tuple<SmcTopografiaTerrenoEdit, string, short> GetTopografiaTerrenoPorId(short id)
        {
            var resultadoBD = _repositorioTramiteLectura
                                              .GetTopografiaTerrenoPorId(id);
            return resultadoBD;
        }
        public Tuple<List<SmcTopografiaTerrenoEdit>, string> GetTopografiaTerrenoPorIdTramite(short idTramite)
        {
            var resultadoBD = _repositorioTramiteLectura
                                              .GetTopografiaTerrenoPorIdTramite(idTramite);
            return resultadoBD;
        }
        public Tuple<SmcOficioOtrasDireccioneEdit, string, short> GetSeguimientoOficioPorId(short id)
        {
            var resultadoBD = _repositorioTramiteLectura
                                              .GetSeguimientoOficioPorId(id);
            return resultadoBD;
        }
        public Tuple<List<SmcOficioOtrasDireccioneEdit>, string> GetSeguimientoOficioPorIdTramite(short idTramite)
        {
            var resultadoBD = _repositorioTramiteLectura
                                              .GetSeguimientoOficioPorIdTramite(idTramite);
            return resultadoBD;
        }
    }
}
