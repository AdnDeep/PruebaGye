using System;
using System.Collections.Generic;

#nullable disable

namespace eMAS.Api.TerrenosComodatos.Entities
{
    public partial class SmcAnexoTramiteEdit
    {
        public short IdAnexoTramite { get; set; }
        public short IdTramite { get; set; }
        public string Link { get; set; }
        public bool PdpEstado { get; set; }
    }
}
