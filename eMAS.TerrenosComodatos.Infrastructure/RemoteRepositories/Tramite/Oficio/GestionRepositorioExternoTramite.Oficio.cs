using eMAS.TerrenosComodatos.Domain.Interfaces;

namespace eMAS.TerrenosComodatos.Infrastructure.RemoteRepositories
{
    public partial class GestionRepositorioExternoTramite : IGestionRepositorioExternoTramite
    {
        private const string methodOficioGetAllByIdTramite = "api/GestionTramiteOficio/ObtenerOficiosPorIdTramite";
        private const string methodOficioGetById = "api/GestionTramiteOficio/ObtenerOficioPorId";
        private const string methodOficioPost = "api/GestionTramiteOficio/Agregar";
        private const string methodOficioPut = "api/GestionTramiteOficio/Actualizar";
        private const string methodOficioDelete = "api/GestionTramiteOficio/Eliminar";
    }
}
