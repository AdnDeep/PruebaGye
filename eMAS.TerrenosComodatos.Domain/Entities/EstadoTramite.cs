using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMAS.TerrenosComodatos.Domain.Entities
{
    public class EstadoTramite : EntidadMunicipalAud
	{
		public EstadoTramite() : base()
		{ 
		}
		public short IdEstado { get; set; }
		public string Descripcon { get; set; }
	}
}
