using eMAS.TerrenosComodatos.Domain.DTOs;
using eMAS.TerrenosComodatos.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMAS.TerrenosComodatos.Domain.Entities
{
    public class Beneficiario : EntidadMunicipalAud
	{
		public Beneficiario() : base()
		{
			this.IdBeneficiario = 0;
		}
		public short IdBeneficiario { get; set; }
		public string Nombre { get; set; }
		public string Identificacion { get; set; }
		public string NombreRepresentante { get; set; }
		public string Contacto { get; set; }

	}
}
