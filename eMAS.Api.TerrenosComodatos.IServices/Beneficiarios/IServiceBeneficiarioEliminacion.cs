using eMAS.Api.TerrenosComodatos.ViewModel;

namespace eMAS.Api.TerrenosComodatos.IServices
{
    public interface IServiceBeneficiarioEliminacion
    {
        ResultadoDTO<string> Eliminar(short id, string usuario, string controlador, string pcclient);
    }
}
