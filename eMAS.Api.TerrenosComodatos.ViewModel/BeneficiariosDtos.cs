
namespace eMAS.Api.TerrenosComodatos.ViewModel
{
    // Request Apis
    public class BeneficiarioTodosPaginadoRequest
    {
        public string panelFilter { get; set; }
        public string resultContainer { get; set; }
        public int numeroPagina { get; set; }
        public int numeroFila { get; set; }
    }
    public class BeneficiariosValidacion1Filter
    {
        public int Id { get; set; }
        public string nombre { get; set; }
        public string ruc { get; set; }
    }
    public class BeneficiariosPanelFilterModel
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
    public class BeneficiariosListViewModel
    {
        public short id { get; set; }
        public string nombre { get; set; }
        public string representante { get; set; }
        public string ruc { get; set; }
        public string contacto { get; set; }    
    }
}
