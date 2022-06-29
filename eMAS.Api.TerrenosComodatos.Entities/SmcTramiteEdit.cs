using System;
using System.Collections.Generic;

#nullable disable

namespace eMAS.Api.TerrenosComodatos.Entities
{
    public partial class SmcTramiteEdit
    {
        public SmcTramiteEdit()
        {
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
        public string NombreBeneficiario { get; set; }
        public short IdTipoContrato { get; set; }
        public string TipoContrato { get; set; }
        public decimal? AreaSolar { get; set; }
        public string AniosPlazo { get; set; }
        public short IdEstado { get; set; }
        public string Estado { get; set; }
        public short? IdDireccion { get; set; }
        public string Direccion { get; set; }
        public string AprobacionConcejoMun { get; set; }
        public DateTime? FechaAprobConcejoMun { get; set; }
        public DateTime? FechaEscritura { get; set; }
        public DateTime? FechaInsRegProp { get; set; }
        public string OficioRevocatoriaMod { get; set; }
        public DateTime? FechaInsRevocatoria { get; set; }
        public string ObservacionJuridico { get; set; }
        public string BaseOrigen { get; set; }
        public string OficioAg { get; set; }
        public string OficioDase { get; set; }
        public bool PdpEstado { get; set; }
    }
}
