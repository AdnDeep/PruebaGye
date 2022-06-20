using eMAS.TerrenosComodatos.Domain.DTOs;
using eMAS.TerrenosComodatos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMAS.TerrenosComodatos.Domain.Application.CaseUses.Mappers
{
    public class CaseUseEscrituraBeneficiarioMapeadores
    {
        public void MapearModelBeneficiarioEditViewAModelValidacion1(ref BeneficiarioEditModel entrada, ref BeneficiariosValidacion1Filter salida)
        {
            salida.Id = entrada.id;
            salida.nombre = entrada.nombre;
        }

        public void MapearModelBeneficiarioEditViewAModelBeneficiario(ref BeneficiarioEditModel entrada
            , ref Beneficiario salida, string usuario, string controlador, string pcclient)
        {
            /*
             public short IdBeneficiario { get; set; }
		public string Nombre { get; set; }
		public string Identificacion { get; set; }
		public string NombreRepresentante { get; set; }
		public string Contacto { get; set; }
            public bool PdpEstado { get; set; }
        public string PdpUsuarioCreacion { get; set; }
        public DateTime? PdpFechaCreacion { get; set; }
        public string PdpUsuarioUltimaModificacion { get; set; }
        public DateTime? PdpFechaUltimaModificacion { get; set; }
        public string PdpUltimaTransaccion { get; set; }
        public string PdpUltimaPcCliente { get; set; }
             */
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
