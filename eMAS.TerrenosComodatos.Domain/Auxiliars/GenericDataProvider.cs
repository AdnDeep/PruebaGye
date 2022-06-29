using eMAS.TerrenosComodatos.Domain.DTOs;
using eMAS.TerrenosComodatos.Domain.Interfaces;
using System.Collections.Generic;

namespace eMAS.TerrenosComodatos.Domain.Auxiliars
{
    public class GenericDataProvider
    {
        private readonly ValidateDataProvider _validateDataProvider;
        private readonly IGestionRepositorioLecturaGenerica _gestionRepositorioGenerica;
        public GenericDataProvider(IGestionRepositorioLecturaGenerica gestionRepositorioGenerica
            , ValidateDataProvider validateDataProvider
            )
        {
            _validateDataProvider = validateDataProvider;
            _gestionRepositorioGenerica = gestionRepositorioGenerica;
        }
        public StructKeyValueSelect GetDataSrc(string key, string target)
        {
            StructKeyValueSelect respuesta = new StructKeyValueSelect();
            respuesta.key = key;
            respuesta.target = target;

            List<KeyValueSelect> lsRespuesta = new List<KeyValueSelect>();
            var resultadoRepositorio = _gestionRepositorioGenerica.ObtenerListadoGenerico(key);

            var respuestaValidacion = _validateDataProvider.ValidateRepository(ref resultadoRepositorio, key);

            if (!respuestaValidacion)
                return respuesta;

            lsRespuesta = resultadoRepositorio.dataresult.Item1;
            respuesta.datasource = lsRespuesta;

            return respuesta;
        }
    }
}
