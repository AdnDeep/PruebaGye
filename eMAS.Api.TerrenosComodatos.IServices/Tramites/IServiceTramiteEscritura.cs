using eMAS.Api.TerrenosComodatos.ViewModel;
using System.Collections.Generic;

namespace eMAS.Api.TerrenosComodatos.IServices
{
    public interface IServiceTramiteEscritura
    {
        ResultadoDTO<int> Agregar(TramiteEditViewModel model, string usuario, string controlador, string pcclient);
        ResultadoDTO<int> Actualizar(TramiteEditViewModel model, string usuario, string controlador, string pcclient);
        ResultadoDTO<int> AgregarAnexo(AnexoTramiteEditViewModel model, string usuario, string controlador, string pcclient);
        ResultadoDTO<int> ActualizarAnexo(AnexoTramiteEditViewModel model, string usuario, string controlador, string pcclient);
    }
}
