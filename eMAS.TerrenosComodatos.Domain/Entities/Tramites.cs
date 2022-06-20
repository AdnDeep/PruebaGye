using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMAS.TerrenosComodatos.Domain.Entities
{
    public class Tramites : EntidadMunicipalAud
	{
		public Tramites() : base()
		{ 
		}
		public short IdInstitucion { get; set; }
		public string Nombre { get; set; }
		public string Identificacion { get; set; }
		public string NombreRepresentante { get; set; }
		public string Contacto { get; set; }
	}
}
