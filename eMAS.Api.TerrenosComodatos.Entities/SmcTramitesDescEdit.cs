using System;
using System.Collections.Generic;

#nullable disable

namespace eMAS.Api.TerrenosComodatos.Entities
{
    public partial class SmcTramitesDescEdit
    {
        public short IdTramiteDesc { get; set; }
        public short IdTramite { get; set; }
        public DateTime Fecha { get; set; }
        public string Observacion { get; set; }
        public bool PdpEstado { get; set; }
        
    }
}
