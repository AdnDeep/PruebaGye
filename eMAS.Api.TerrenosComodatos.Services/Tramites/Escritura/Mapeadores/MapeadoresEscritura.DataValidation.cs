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
    }
}
