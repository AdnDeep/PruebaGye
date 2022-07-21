using System;
using System.Collections.Generic;

#nullable disable

namespace eMAS.Api.TerrenosComodatos.Entities
{
    public partial class SmcTopografiaTerrenoEdit
    {
        public short IdTopografiaTerreno { get; set; }
        public short IdTipoTopografiaTerreno { get; set; }
        public string TipoTopografiaTerreno { get; set; }
        public short IdTramite { get; set; }
        public string Oficio { get; set; }
        public DateTime? FechaEnvio { get; set; }
        public string OficioRespuesta { get; set; }
        public DateTime? FechaRespuesta { get; set; }
        public bool PdpEstado { get; set; }        
    }
}
