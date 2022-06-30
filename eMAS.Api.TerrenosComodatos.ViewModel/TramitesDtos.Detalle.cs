
using System;

namespace eMAS.Api.TerrenosComodatos.ViewModel
{
    public class TopografiaTerrenoEditViewMoel
    {
        public short IdTopografiaTerreno { get; set; }
        public short IdTipoTopografiaTerreno { get; set; }
        public short IdTramite { get; set; }
        public string Oficio { get; set; }
        public DateTime? FechaEnvio { get; set; }
        public string OficioRespuesta { get; set; }
        public DateTime? FechaRespuesta { get; set; }
        public bool PdpEstado { get; set; }
    }
    public class TopografiaTerrenoListViewMoel
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
    public class OficioTramiteEditViewModel
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
    }
    public class OficioTramiteListViewModel
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
    }
    public class ObservacionTramiteListViewModel
    {
        public short IdTramiteDesc { get; set; }
        public short IdTramite { get; set; }
        public DateTime Fecha { get; set; }
        public string Observacion { get; set; }
        public bool PdpEstado { get; set; }
    }
    public class ObservacionTramiteEditViewModel 
    {
        public short IdTramiteDesc { get; set; }
        public short IdTramite { get; set; }
        public DateTime Fecha { get; set; }
        public string Observacion { get; set; }
        public bool PdpEstado { get; set; }
    }
    public class AnexoTramiteListViewModel
    {
        public short IdAnexoTramite { get; set; }
        public short IdTramite { get; set; }
        public string Link { get; set; }
        public bool PdpEstado { get; set; }
    }
    public class AnexoTramiteEditViewModel
    {
        public short IdAnexoTramite { get; set; }
        public short IdTramite { get; set; }
        public string Link { get; set; }
        public bool PdpEstado { get; set; }
    }
}
