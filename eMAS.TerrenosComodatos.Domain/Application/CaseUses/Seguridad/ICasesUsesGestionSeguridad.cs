using eMAS.TerrenosComodatos.Domain.DTOs;

namespace eMAS.TerrenosComodatos.Domain.Application
{
    public interface ICasesUsesGestionSeguridad
    {
        bool ValidarPermisoControlador(string user, string controlador);
        string ObtenerPermisosPorUsuario(string user, string controlador);
    }
}
