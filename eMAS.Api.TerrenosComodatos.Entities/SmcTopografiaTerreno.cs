using System;
using System.Collections.Generic;

#nullable disable

namespace eMAS.Api.TerrenosComodatos.Entities
{
    public partial class SmcTopografiaTerreno
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
        public string PdpUsuarioCreacion { get; set; }
        public DateTime PdpFechaCreacion { get; set; }
        public string PdpUsuarioUltimaModificacion { get; set; }
        public DateTime? PdpFechaUltimaModificacion { get; set; }
        public string PdpUltimaTransaccion { get; set; }
        public string PdpUltimaPcCliente { get; set; }
    }
}
