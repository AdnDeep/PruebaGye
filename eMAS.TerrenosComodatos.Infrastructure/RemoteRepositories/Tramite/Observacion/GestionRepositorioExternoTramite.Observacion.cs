using eMAS.TerrenosComodatos.Domain.Interfaces;

namespace eMAS.TerrenosComodatos.Infrastructure.RemoteRepositories
{
    public partial class GestionRepositorioExternoTramite : IGestionRepositorioExternoTramite
    {
        private const string methodObservacionGetAllByIdTramite = "api/GestionTramiteObservacion/ObtenerObservacionesPorIdTramite";
        private const string methodObservacionGetById = "api/GestionTramiteObservacion/ObtenerObservacionPorId";
        private const string methodObservacionPost = "api/GestionTramiteObservacion/Agregar";
        private const string methodObservacionPut = "api/GestionTramiteObservacion/Actualizar";
        private const string methodObservacionDelete = "api/GestionTramiteObservacion/Eliminar";
    }
}
