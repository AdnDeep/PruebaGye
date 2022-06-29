
using System;

namespace eMAS.Api.TerrenosComodatos.ViewModel
{
    public class TramiteEditViewModel
    {
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
    public class TramitesPanelFilterModel
    {
        public short anioexp { get; set; }
        public string secexp { get; set; }
        public short idbeneficiario { get; set; }
        public short sector { get; set; }
        public short manzana { get; set; }
        public short lote { get; set; }
        public short division { get; set; }
        public short phv { get; set; }
        public short phh { get; set; }
        public short numero { get; set; }
        public short idestado { get; set; }
    }
    public class TramitesListViewModel
    {
        public short id { get; set; }
        public short anioexp { get; set; }
        public short secexp { get; set; }
        public string beneficiario { get; set; }
        public string ruc { get; set; }
        public string codigocatastral { get; set; }
    }
}
