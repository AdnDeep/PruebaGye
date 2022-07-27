using eMAS.Api.TerrenosComodatos.Entities;
using eMAS.Api.TerrenosComodatos.ViewModel;
using System.Collections.Generic;
using System.Text.Json;

namespace eMAS.Api.TerrenosComodatos.Services
{
    public partial class MapeadoresEscrituraTramite
    {
        public string MapearTramiteEditViewModelADataValidationEscritura(ref TramiteEditViewModel entrada)
        {
            string respuesta = string.Empty;
            TramiteDataValidationEscritura modelValidacion = new TramiteDataValidationEscritura();

            modelValidacion.idtramite = entrada.idtramite;
            modelValidacion.idbeneficiario = entrada.idbeneficiario;
            modelValidacion.iddireccion = entrada.iddireccion ?? 0;
            modelValidacion.idestado = entrada.idestado;
            modelValidacion.idtipocontrato = entrada.idtipocontrato;

            respuesta = JsonSerializer.Serialize(modelValidacion);

            return respuesta;
        }
        public string MapearAnexoTramiteEditViewModelADataValidationEscritura(ref AnexoTramiteEditViewModel entrada)
        {
            string respuesta = string.Empty;
            var modelValidacion = new 
            {
                idanexotramite= entrada.idanexotramite,
                idtramite = entrada.idtramite
            };
            respuesta = JsonSerializer.Serialize(modelValidacion);

            return respuesta;
        }
        public string MapearObservacionTramiteEditViewModelADataValidationEscritura(ref ObservacionTramiteEditViewModel entrada)
        {
            string respuesta = string.Empty;

            var modelValidacion = new
            {
                idobservaciontramite = entrada.idtramitedesc,
                idtramite = entrada.idtramite
            };

            respuesta = JsonSerializer.Serialize(modelValidacion);

            return respuesta;
        }
        public string MapearOficioTramiteEditViewModelADataValidationEscritura(ref OficioTramiteEditViewModel entrada)
        {
            string respuesta = string.Empty;

            var modelValidacion = new
            {
                idoficiotramite = entrada.idoficiootrasdirecciones,
                idtramite = entrada.idtramite
            };

            respuesta = JsonSerializer.Serialize(modelValidacion);

            return respuesta;
        }
        public string MapearTopografiaTramiteEditViewModelADataValidationEscritura(ref TopografiaTerrenoEditViewMoel entrada)
        {
            string respuesta = string.Empty;

            var modelValidacion = new
            {
                idtipotopografia = entrada.idtipotopografiaterreno,
                idtopografiatramite = entrada.idtopografiaterreno,
                idtramite = entrada.idtramite
            };

            respuesta = JsonSerializer.Serialize(modelValidacion);

            return respuesta;
        }
    }
}
