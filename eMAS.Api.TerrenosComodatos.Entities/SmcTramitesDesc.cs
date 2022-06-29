using System;
using System.Collections.Generic;

#nullable disable

namespace eMAS.Api.TerrenosComodatos.Entities
{
    public partial class SmcTramitesDesc
    {
        public short IdTramiteDesc { get; set; }
        public short IdTramite { get; set; }
        public DateTime Fecha { get; set; }
        public string Observacion { get; set; }
        public bool PdpEstado { get; set; }
        public string PdpUsuarioCreacion { get; set; }
        public DateTime PdpFechaCreacion { get; set; }
        public string PdpUsuarioUltimaModificacion { get; set; }
        public DateTime? PdpFechaUltimaModificacion { get; set; }
        public string PdpUltimaTransaccion { get; set; }
        public string PdpUltimaPcCliente { get; set; }
        public virtual SmcTramite IdTramiteNavigation { get; set; }
    }
}
