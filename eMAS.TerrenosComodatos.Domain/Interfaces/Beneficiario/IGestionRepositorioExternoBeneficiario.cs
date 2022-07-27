using eMAS.TerrenosComodatos.Domain.DTOs;
using System;
using System.Collections.Generic;

namespace eMAS.TerrenosComodatos.Domain.Interfaces
{
    public interface IGestionRepositorioExternoBeneficiario
    {
        ResultadoDTO<BeneficiarioEditViewModel> EliminarBeneficiario(short id, string usuario, string controlador, string pcclient);
        ResultadoDTO<BeneficiarioEditViewModel> CrearBeneficiario(BeneficiarioEditViewModel model, string usuario, string controlador, string pcclient);
        ResultadoDTO<BeneficiarioEditViewModel> ActualizarBeneficiario(BeneficiarioEditViewModel model, string usuario, string controlador, string pcclient);
        ResultadoDTO<DataPagineada<BeneficiarioListViewModel>> GetBeneficiarioTodosPaginado(string panelFilter
                    , string resultContainer, int numeroPagina, int numeroFila);
        ResultadoDTO<BeneficiarioEditViewModel> GetBeneficiarioPorId(short id);
    }
}
