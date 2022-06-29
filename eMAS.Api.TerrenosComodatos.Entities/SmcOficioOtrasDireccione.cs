using System;
using System.Collections.Generic;

#nullable disable

namespace eMAS.Api.TerrenosComodatos.Entities
{
    public partial class SmcOficioOtrasDireccione
    {
        public short IdOficioOtrasDirecciones { get; set; }
        public short IdTramite { get; set; }
        public short Secuencia { get; set; }
        public short IdDireccion { get; set; }
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
