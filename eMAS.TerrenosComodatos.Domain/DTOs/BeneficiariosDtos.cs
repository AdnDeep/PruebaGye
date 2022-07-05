
namespace eMAS.TerrenosComodatos.Domain.DTOs
{
    public class BeneficiarioPanelFilterViewModel
    {
        public string nombre { get; set; }
        public string representante { get; set; }
        public string ruc { get; set; }
        public string contacto { get; set; }
    }

    public class BeneficiarioDeleteViewModel
    {
        public short id { get; set; }
    }
    public class BeneficiarioEditViewModel
    {
        public short id { get; set; }
        public string nombre { get; set; }
        public string representante { get; set; }
        public string ruc { get; set; }
        public string contacto { get; set; }
        public string usuario { get; set; }
    }
    public class BeneficiarioListViewModel
    {
        public short id { get; set; }
        public string nombre { get; set; }
        public string representante { get; set; }
        public string ruc { get; set; }
        public string contacto { get; set; }    
    }
}
