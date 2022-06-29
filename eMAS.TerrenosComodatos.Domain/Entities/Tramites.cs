using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMAS.TerrenosComodatos.Domain.Entities
{
    public class Tramite : EntidadMunicipalAud
	{
		public Tramite() : base()
		{ 
		}
		public short IdTramite { get; set; }
		public short Anio { get; set; }
		public short Secuencia { get; set; }
		public short IdSector { get; set; }
		public short Manzana { get; set; }
		public short Lote { get; set; }
		public short Division { get; set; }
		public short Phv { get; set; }
		public short Phh { get; set; }
		public short Numero { get; set; }
		public short IdBeneficiario { get; set; }
		public Beneficiario Beneficiario { get; set; }
		public short IdTipoContrato { get; set; }
		public decimal AreaSolar { get; set; }
		public string AniosPlazo { get; set; }
		public short IdEstado { get; set; }
		public EstadoTramite Estado { get; set; }
		public short IdDireccion { get; set; }
		public string AprobacionConcejoMun { get; set; }
		
	}
}
