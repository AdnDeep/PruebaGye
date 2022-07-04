
using System;

namespace eMAS.Api.TerrenosComodatos.ViewModel
{
    public class TopografiaTerrenoEditViewMoel
    {
        public short idtopografiaterreno { get; set; }
        public short idtipotopografiaterreno { get; set; }
        public short idtramite { get; set; }
        public string oficio { get; set; }
        public DateTime? fechaenvio { get; set; }
        public string oficiorespuesta { get; set; }
        public DateTime? fecharespuesta { get; set; }
    }
    public class TopografiaTerrenoListViewMoel
    {
        public short idtopografiaterreno { get; set; }
        public short idtipoTopografiaterreno { get; set; }
        public string tipotopografiaterreno { get; set; }
        public short idtramite { get; set; }
        public string oficio { get; set; }
        public DateTime? fechaenvio { get; set; }
        public string oficiorespuesta { get; set; }
        public DateTime? fecharespuesta { get; set; }
    }
    public class OficioTramiteEditViewModel
    {
        public short idoficiootrasdirecciones { get; set; }
        public short idtramite { get; set; }
        public short secuencia { get; set; }
        public short iddireccion { get; set; }
        public string oficio { get; set; }
        public DateTime? fechaenvio { get; set; }
        public string oficiorespuesta { get; set; }
        public DateTime? fecharespuesta { get; set; }
    }
    public class OficioTramiteListViewModel
    {
        public short idoficiootrasdirecciones { get; set; }
        public short idtramite { get; set; }
        public short secuencia { get; set; }
        public short iddireccion { get; set; }
        public string oficio { get; set; }
        public DateTime? fechaenvio { get; set; }
        public string oficiorespuesta { get; set; }
        public DateTime? fecharespuesta { get; set; }
    }
    public class ObservacionTramiteListViewModel
    {
        public short idtramitedesc { get; set; }
        public short idtramite { get; set; }
        public DateTime fecha { get; set; }
        public string observacion { get; set; }
            }
    public class ObservacionTramiteEditViewModel 
    {
        public short idtramitedesc { get; set; }
        public short idtramite { get; set; }
        public DateTime fecha { get; set; }
        public string observacion { get; set; }
    }
    public class AnexoTramiteListViewModel
    {
        public short idanexotramite { get; set; }
        public short idtramite { get; set; }
        public string link { get; set; }
    }
    public class AnexoTramiteEditViewModel
    {
        public short idanexotramite { get; set; }
        public short idtramite { get; set; }
        public string link { get; set; }
    }
}
