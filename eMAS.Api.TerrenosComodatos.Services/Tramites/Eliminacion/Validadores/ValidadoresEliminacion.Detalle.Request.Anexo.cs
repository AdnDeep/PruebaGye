using eMAS.Api.TerrenosComodatos.ViewModel;
using System.Collections.Generic;

namespace eMAS.Api.TerrenosComodatos.Services
{
    public partial class ValidadoresEliminacionTramite
    {
        public bool DataAnexoRequestToDelete(short idAnexoTramite
            , string usuario, string controlador, string pcclient
            , ref ResultadoDTO<int> salida) 
        {
            var parametros = $"ValidadoresEscrituraTramite Service Layer";
            var props = new Dictionary<string, object>(){
                                { "Metodo", "DataAnexoRequestToDelete" },
                                { "Sitio", "COMODATO-API" },
                                { "Parametros", parametros }
                        };
            List<Mensaje> lsMensajes = new List<Mensaje>();
            bool puedeContinuar = false;
            salida.mensaje = "OK";
            salida.tipo = "EXITO";
            
            if (idAnexoTramite <= 0)
            {
                salida.mensaje = "El parámetro de Entrada Id debe ser mayor a 0";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(usuario))
            {
                salida.mensaje = "El campo usuario se encuentra vacío.";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            if (string.IsNullOrEmpty(controlador) || string.IsNullOrEmpty(controlador))
            {
                salida.mensaje = "El campo controlador se encuentra vacío.";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            if (string.IsNullOrEmpty(pcclient) || string.IsNullOrEmpty(pcclient))
            {
                salida.mensaje = "El campo pcclient se encuentra vacío.";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }

            puedeContinuar = true;
            return puedeContinuar;
        }
    }
}
