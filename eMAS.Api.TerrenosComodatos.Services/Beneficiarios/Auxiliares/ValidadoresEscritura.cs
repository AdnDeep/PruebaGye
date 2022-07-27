using eMAS.Api.TerrenosComodatos.Entities;
using eMAS.Api.TerrenosComodatos.ViewModel;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eMAS.Api.TerrenosComodatos.Services
{
    public partial class ValidadoresEscrituraBeneficiarios
    {
        private readonly ILogger<ValidadoresEscrituraBeneficiarios> _logger;
        public ValidadoresEscrituraBeneficiarios(ILogger<ValidadoresEscrituraBeneficiarios> logger)
        {
            _logger = logger;
        }
        public bool ValidarDatosClienteBeneficiarioEditViewModel(ref BeneficiarioEditViewModel entrada
            , ref ResultadoDTO<BeneficiarioEditViewModel> salida)
        {
            bool puedeContinuar = false;
            salida.mensaje = "OK";
            salida.tipo = "EXITO";
            List<Mensaje> lsMensajes = new List<Mensaje>();

            if (string.IsNullOrEmpty(entrada.nombre) || string.IsNullOrWhiteSpace(entrada.nombre))
            {
                lsMensajes.Add(new Mensaje 
                { 
                    codigo = "VLNVALCLI", 
                    descripcion = "El Nombre del Beneficiario es un campo obligatorio. (2)", 
                    tipo="ADVERTENCIA" 
                });
                salida.mensajes = lsMensajes;
                salida.mensaje = "El Nombre del Beneficiario es un campo obligatorio. (2)";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }

            puedeContinuar = true;
            return puedeContinuar;

        }
    }
}
