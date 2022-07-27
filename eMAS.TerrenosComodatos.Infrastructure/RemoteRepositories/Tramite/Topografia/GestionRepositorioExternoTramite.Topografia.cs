using eMAS.TerrenosComodatos.Domain.Interfaces;

namespace eMAS.TerrenosComodatos.Infrastructure.RemoteRepositories
{
    public partial class GestionRepositorioExternoTramite : IGestionRepositorioExternoTramite
    {
        private const string methodTopografiaGetAllByIdTramite = "api/GestionTramiteTopografia/ObtenerTopografiasPorIdTramite";
        private const string methodTopografiaGetById = "api/GestionTramiteTopografia/ObtenerTopografiaPorId";
        private const string methodTopografiaPost = "api/GestionTramiteTopografia/Agregar";
        private const string methodTopografiaPut = "api/GestionTramiteTopografia/Actualizar";
        private const string methodTopografiaDelete = "api/GestionTramiteTopografia/Eliminar";
    }
}
