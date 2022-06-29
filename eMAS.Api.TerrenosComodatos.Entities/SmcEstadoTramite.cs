using System;
using System.Collections.Generic;

#nullable disable

namespace eMAS.Api.TerrenosComodatos.Entities
{
    public partial class SmcEstadoTramite
    {
        public SmcEstadoTramite()
        {
            SmcTramites = new HashSet<SmcTramite>();
        }

        public short IdEstado { get; set; }
        public string Descripcion { get; set; }
        public bool PdpEstado { get; set; }
        public string PdpUsuarioCreacion { get; set; }
        public DateTime PdpFechaCreacion { get; set; }
        public string PdpUsuarioUltimaModificacion { get; set; }
        public DateTime? PdpFechaUltimaModificacion { get; set; }
        public string PdpUltimaTransaccion { get; set; }
        public string PdpUltimaPcCliente { get; set; }

        public virtual ICollection<SmcTramite> SmcTramites { get; set; }
    }
}
