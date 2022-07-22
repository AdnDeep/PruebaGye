
using System;

namespace eMAS.TerrenosComodatos.Domain.DTOs
{
    public class TramitesDetailRequestDeleteViewModel
    {
        public string id { get; set; }
        public string entidad { get; set; }
    }
    public class TramitesDetailRequestEditViewModel
    {
        public string model { get; set; }
        public string entidad { get; set; }
    }
    public class TramitesDetailRequestViewModel
    {
        public string id { get; set; }
        public string entidad { get; set; }
    }
    public class TramitesListRequestViewModel
    {
        public short idtramite { get; set; }
        public string entidad { get; set; }
    }
    public class TramitePanelFilterViewModel
    {
        public short? anioexp { get; set; } = 0;
        public string secexp { get; set; }
        public short? idbeneficiario { get; set; } = 0;
        public short? sector { get; set; } = 0;
        public short? manzana { get; set; } = 0;
        public short? lote { get; set; } = 0;
        public short? division { get; set; } = 0;
        public short? phv { get; set; } = 0;
        public short? phh { get; set; } = 0;
        public short? numero { get; set; } = 0;
        public short? idestado { get; set; } = 0;
    }
    public class TramiteListViewModel
    {
        public short id { get; set; }
        public short anioexp { get; set; }
        public short secexp { get; set; }
        public string beneficiario { get; set; }
        public string ruc { get; set; }
        public string codigocatastral { get; set; }
    }
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
        public string representantelegal { get; set; }
        public short idtipocontrato { get; set; }
        public string tipocontrato { get; set; }
        public decimal? areasolar { get; set; }
        public string strareasolar { get; set; }
        public string aniosplazo { get; set; }
        public short idestado { get; set; }
        public string estado { get; set; }
        public short? iddireccion { get; set; }
        public string direccion { get; set; }
        public string aprobacionconcejomun { get; set; }
        public DateTime? fechaaprobconcejomun { get; set; }
        public string strfechaaprobconcejomun { get; set; }
        public DateTime? fechaescritura { get; set; }
        public string strfechaescritura { get; set; }
        public DateTime? fechainsregprop { get; set; }
        public string strfechainsregprop { get; set; }
        public string oficiorevocatoriamod { get; set; }
        public DateTime? fechainsrevocatoria { get; set; }
        public string strfechainsrevocatoria { get; set; }
        public string observacionjuridico { get; set; }
        public string baseorigen { get; set; }
        public string oficioag { get; set; }
        public string oficiodase { get; set; }
    }
    public class AnexoTramiteListViewModel
    {
        public short idanexotramite { get; set; }
        public short idtramite { get; set; }
        public string link { get; set; }
    }
    public interface ITramitesDetailEditViewModel
    { 
    }
    public class AnexoTramiteEditViewModel : ITramitesDetailEditViewModel
    {
        public short idanexotramite { get; set; }
        public short idtramite { get; set; }
        public string link { get; set; }
    }
    public class ObservacionTramiteListViewModel
    {
        public short idtramitedesc { get; set; }
        public short idtramite { get; set; }
        public DateTime fecha { get; set; }
        public string strfecha { get; set; }
        public string observacion { get; set; }
    }
    public class ObservacionTramiteEditViewModel : ITramitesDetailEditViewModel
    {
        public short idtramitedesc { get; set; }
        public short idtramite { get; set; }
        public DateTime fecha { get; set; }
        public string strfecha { get; set; }
        public string observacion { get; set; }
    }
    public class OficioTramiteEditViewModel : ITramitesDetailEditViewModel
    {
        public short idoficiootrasdirecciones { get; set; }
        public short idtramite { get; set; }
        public short secuencia { get; set; }
        public short iddireccion { get; set; }
        public string oficio { get; set; }
        public DateTime? fechaenvio { get; set; }
        public string strfechaenvio { get; set; }
        public string oficiorespuesta { get; set; }
        public DateTime? fecharespuesta { get; set; }
        public string strfecharespuesta { get; set; }
    }
    public class OficioTramiteListViewModel
    {
        public short idoficiootrasdirecciones { get; set; }
        public short idtramite { get; set; }
        public short secuencia { get; set; }
        public short iddireccion { get; set; }
        public string direccion { get; set; }
        public string oficio { get; set; }
        public DateTime? fechaenvio { get; set; }
        public string strfechaenvio { get; set; }
        public string oficiorespuesta { get; set; }
        public DateTime? fecharespuesta { get; set; }
        public string strfecharespuesta { get; set; }
    }

    public class TopografiaTerrenoEditViewMoel : ITramitesDetailEditViewModel
    {
        public short idtopografiaterreno { get; set; }
        public short idtipotopografiaterreno { get; set; }
        public string tipotopografiaterreno { get; set; }
        public short idtramite { get; set; }
        public string oficio { get; set; }
        public DateTime? fechaenvio { get; set; }
        public string strfechaenvio { get; set; }
        public string oficiorespuesta { get; set; }
        public DateTime? fecharespuesta { get; set; }
        public string strfecharespuesta { get; set; }
    }
    public class TopografiaTerrenoListViewMoel
    {
        public short idtopografiaterreno { get; set; }
        public short idtipoTopografiaterreno { get; set; }
        public string tipotopografiaterreno { get; set; }
        public short idtramite { get; set; }
        public string oficio { get; set; }
        public DateTime? fechaenvio { get; set; }
        public string strfechaenvio { get; set; }
        public string oficiorespuesta { get; set; }
        public DateTime? fecharespuesta { get; set; }
        public string strfecharespuesta { get; set; }
    }
}
