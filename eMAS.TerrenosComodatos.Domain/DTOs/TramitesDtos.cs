
namespace eMAS.TerrenosComodatos.Domain.DTOs
{
    public class TramitePanelFilterViewModel
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
    public class TramiteListViewModel
    {
        public short id { get; set; }
        public short anioexp { get; set; }
        public short secexp { get; set; }
        public string beneficiario { get; set; }
        public string ruc { get; set; }
        public string codigoCatastral { get; set; }
    }
    public class TramiteEditViewModel
    { 
    }
}
