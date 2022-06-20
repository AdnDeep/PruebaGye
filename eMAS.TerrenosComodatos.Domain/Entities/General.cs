using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMAS.TerrenosComodatos.Domain.Entities
{
    public class EntidadValidacion
    {
        public string clave { get; set; }
        public int valorNumerico { get; set; }
    }
    public abstract class EntidadMunicipalAud
    {
        public bool PdpEstado { get; set; }
        public string PdpUsuarioCreacion { get; set; }
        public DateTime? PdpFechaCreacion { get; set; }
        public string PdpUsuarioUltimaModificacion { get; set; }
        public DateTime? PdpFechaUltimaModificacion { get; set; }
        public string PdpUltimaTransaccion { get; set; }
        public string PdpUltimaPcCliente { get; set; }
        public EntidadMunicipalAud()
        {
            this.PdpEstado = true;
            this.PdpFechaCreacion = DateTime.Now;
        }
    }
}
