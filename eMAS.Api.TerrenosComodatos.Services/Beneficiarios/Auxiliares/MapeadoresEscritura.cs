using eMAS.Api.TerrenosComodatos.Entities;
using eMAS.Api.TerrenosComodatos.ViewModel;
using System;
using System.Collections.Generic;


namespace eMAS.Api.TerrenosComodatos.Services
{
    public class MapeadoresEscrituraBeneficiario
    {
        public MapeadoresEscrituraBeneficiario()
        { 
        }
        public void MapearModelBeneficiarioEditViewAModelValidacion1(string tipoMapeo, ref BeneficiarioEditViewModel entrada, ref BeneficiariosValidacion1Filter salida)
        {
            salida.Id = tipoMapeo == "AGREGAR" ? 0 : entrada.id;
            salida.nombre = entrada.nombre;
            salida.ruc = entrada.ruc;
        }
        public void MapearModelBeneficiarioEditViewAModelBeneficiario(ref BeneficiarioEditViewModel entrada
            , ref SmcBeneficiario salida, string usuario, string controlador, string pcclient)
        {
            salida.IdBeneficiario = entrada.id;
            salida.Nombre = entrada.nombre;
            salida.Identificacion = entrada.ruc;
            salida.NombreRepresentante = entrada.representante;
            salida.Contacto = entrada.contacto;
            salida.PdpEstado = true;
            salida.PdpUsuarioCreacion = usuario;
            salida.PdpFechaCreacion = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            salida.PdpUsuarioUltimaModificacion = usuario;
            salida.PdpFechaUltimaModificacion = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            salida.PdpUltimaTransaccion = controlador;
            salida.PdpUltimaPcCliente = pcclient;
        }
    }
}
