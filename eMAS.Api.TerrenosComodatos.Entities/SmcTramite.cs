using System;
using System.Collections.Generic;

#nullable disable

namespace eMAS.Api.TerrenosComodatos.Entities
{
    public partial class SmcTramite
    {
        public SmcTramite()
        {
            SmcAnexoTramites = new HashSet<SmcAnexoTramite>();
            SmcOficioOtrasDirecciones = new HashSet<SmcOficioOtrasDireccione>();
            SmcTopografiaTerrenos = new HashSet<SmcTopografiaTerreno>();
            SmcTramitesDescs = new HashSet<SmcTramitesDesc>();
        }

        public short IdTramite { get; set; }
        public short Anio { get; set; }
        public short Secuencia { get; set; }
        public short IdSector { get; set; }
        public short Manzana { get; set; }
        public short Lote { get; set; }
        public short Division { get; set; }
        public short Phv { get; set; }
        public short Phh { get; set; }
        public short Numero { get; set; }
        public short IdBeneficiario { get; set; }
        public short IdTipoContrato { get; set; }
        public decimal? AreaSolar { get; set; }
        public string AniosPlazo { get; set; }
        public short IdEstado { get; set; }
        public short? IdDireccion { get; set; }
        public string AprobacionConcejoMun { get; set; }
        public DateTime? FechaAprobConcejoMun { get; set; }
        public DateTime? FechaEscritura { get; set; }
        public DateTime? FechaInsRegProp { get; set; }
        public string OficioRevocatoriaMod { get; set; }
        public DateTime? FechaInsRevocatoria { get; set; }
        public string ObservacionJuridico { get; set; }
        public string BaseOrigen { get; set; }
        public bool PdpEstado { get; set; }
        public string PdpUsuarioCreacion { get; set; }
        public DateTime PdpFechaCreacion { get; set; }
        public string PdpUsuarioUltimaModificacion { get; set; }
        public DateTime? PdpFechaUltimaModificacion { get; set; }
        public string PdpUltimaTransaccion { get; set; }
        public string PdpUltimaPcCliente { get; set; }
        public string OficioAg { get; set; }
        public string OficioDase { get; set; }

        public virtual SmcBeneficiario IdBeneficiarioNavigation { get; set; }
        public virtual SmcDireccion IdDireccionNavigation { get; set; }
        public virtual SmcEstadoTramite IdEstadoNavigation { get; set; }
        public virtual SmcTipoContrato IdTipoContratoNavigation { get; set; }
        public virtual ICollection<SmcAnexoTramite> SmcAnexoTramites { get; set; }
        public virtual ICollection<SmcOficioOtrasDireccione> SmcOficioOtrasDirecciones { get; set; }
        public virtual ICollection<SmcTopografiaTerreno> SmcTopografiaTerrenos { get; set; }
        public virtual ICollection<SmcTramitesDesc> SmcTramitesDescs { get; set; }
    }
}
