using eMAS.Api.TerrenosComodatos.ViewModel;
using System.Collections.Generic;

namespace eMAS.Api.TerrenosComodatos.Services
{
    public partial class ValidadoresEscrituraTramite
    {
        public bool OficioDataRequestToAdd(ref OficioTramiteEditViewModel entrada
            , string usuario, string controlador, string pcclient
            , ref ResultadoDTO<int> salida) 
        {
            var parametros = $"ValidadoresEscrituraTramite Service Layer";
            var props = new Dictionary<string, object>(){
                                { "Metodo", "OficioDataRequestToAdd" },
                                { "Sitio", "COMODATO-API" },
                                { "Parametros", parametros }
                        };
            List<Mensaje> lsMensajes = new List<Mensaje>();
            bool puedeContinuar = false;
            salida.mensaje = "OK";
            salida.tipo = "EXITO";
            if (entrada == null)
            {
                salida.mensaje = "No existe el parámetro de entrada";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            if (entrada.idoficiootrasdirecciones != 0)
            {
                salida.mensaje = "El parámetro de Entrada Id debe ser 0";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            if (entrada.idtramite <= 0)
            {
                salida.mensaje = "El parámetro de Entrada Id del tramite debe ser mayor a 0";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            if (entrada.iddireccion <= 0)
            {
                salida.mensaje = "El parámetro de Entrada Id Dirección debe ser mayor a 0";
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
        public bool OficioRequestToUpdate(ref OficioTramiteEditViewModel entrada
            , string usuario, string controlador, string pcclient
            , ref ResultadoDTO<int> salida)
        {
            var parametros = $"ValidadoresEscrituraTramite Service Layer";
            var props = new Dictionary<string, object>(){
                                { "Metodo", "ObligacionRequestToUpdate" },
                                { "Sitio", "COMODATO-API" },
                                { "Parametros", parametros }
                        };
            List<Mensaje> lsMensajes = new List<Mensaje>();
            bool puedeContinuar = false;
            salida.mensaje = "OK";
            salida.tipo = "EXITO";
            if (entrada == null)
            {
                salida.mensaje = "No existe el parámetro de entrada";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            if (entrada.idoficiootrasdirecciones <= 0)
            {
                salida.mensaje = "El parámetro de Entrada Id debe ser mayor a 0";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            if (entrada.idtramite <= 0)
            {
                salida.mensaje = "El parámetro de Entrada Id del tramite debe ser mayor a 0";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            if (entrada.iddireccion != 0)
            {
                salida.mensaje = "El parámetro de Entrada Id Dirección debe ser igual a 0";
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
