
using System;

namespace eMAS.Api.TerrenosComodatos.ViewModel
{
    public class TramiteEditViewModel
    {
        public short idtramite { get; set; }
        public short anio { get; set; }
        public short secuencia { get; set; }
        public short idsector { get; set; }
        public short manzana { get; set; }
        public short lote { get; set; }
        public short division { get; set; }
        public short phv { get; set; }
        public short phh { get; set; }
        public short numero { get; set; }
        public short idbeneficiario { get; set; }
        public string nombrebeneficiario { get; set; }
        public short idtipocontrato { get; set; }
        public string tipocontrato { get; set; }
        public decimal? areasolar { get; set; }
        public string aniosplazo { get; set; }
        public short idestado { get; set; }
        public string estado { get; set; }
        public short? iddireccion { get; set; }
        public string direccion { get; set; }
        public string aprobacionconcejomun { get; set; }
        public DateTime? fechaaprobconcejomun { get; set; }
        public DateTime? fechaescritura { get; set; }
        public DateTime? fechainsregprop { get; set; }
        public string oficiorevocatoriamod { get; set; }
        public DateTime? fechainsrevocatoria { get; set; }
        public string observacionjuridico { get; set; }
        public string baseorigen { get; set; }
        public string oficioag { get; set; }
        public string oficiodase { get; set; }
        public bool pdpestado { get; set; }
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
