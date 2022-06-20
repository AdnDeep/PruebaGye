
namespace eMAS.TerrenosComodatos.Domain.DTOs
{
    public class BeneficiariosValidacion1Filter
    {
        public int Id { get; set; }
        public string nombre { get; set; }
    }
    public class BeneficiariosPanelFilterModel
    {
        public string nombre { get; set; }
        public string representante { get; set; }
        public string ruc { get; set; }
        public string contacto { get; set; }
    }
    public class BeneficiarioEditModel
    {
        public short id { get; set; }
        public string nombre { get; set; }
        public string representante { get; set; }
        public string ruc { get; set; }
        public string contacto { get; set; }
        public string usuario { get; set; }
    }
    public class BeneficiariosViewModel
    {
        public short id { get; set; }
        public string nombre { get; set; }
        public string representante { get; set; }
        public string ruc { get; set; }
        public string contacto { get; set; }    
    }
}
