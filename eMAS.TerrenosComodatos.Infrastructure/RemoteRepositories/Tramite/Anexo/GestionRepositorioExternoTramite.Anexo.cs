using eMAS.TerrenosComodatos.Domain.Interfaces;

namespace eMAS.TerrenosComodatos.Infrastructure.RemoteRepositories
{
    public partial class GestionRepositorioExternoTramite : IGestionRepositorioExternoTramite
    {
        private const string methodAnexoGetAllByIdTramite = "api/GestionTramiteAnexo/ObtenerAnexosPorIdTramite";
        private const string methodAnexoGetById = "api/GestionTramiteAnexo/ObtenerAnexoPorId";
        private const string methodAnexoPost = "api/GestionTramiteAnexo/Agregar";
        private const string methodAnexoPut = "api/GestionTramiteAnexo/Actualizar";
        private const string methodAnexoDelete = "api/GestionTramiteAnexo/Eliminar";
    }
}
