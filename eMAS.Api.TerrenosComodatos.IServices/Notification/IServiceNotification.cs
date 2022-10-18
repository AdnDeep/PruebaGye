
using System.Threading.Tasks;

namespace eMAS.Api.TerrenosComodatos.IServices
{
    public interface IServiceNotificationTramiteOficio
    {
        Task ObtenerOficiosSinRespuestaYNotificar();
    }
}
