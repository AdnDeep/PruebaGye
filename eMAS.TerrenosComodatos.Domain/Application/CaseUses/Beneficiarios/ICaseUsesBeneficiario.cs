using eMAS.TerrenosComodatos.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMAS.TerrenosComodatos.Domain.Application
{
    public interface ICasesUseGestionBeneficiario
    {
        ResultadoDTO<DataPagineada<BeneficiarioListViewModel>> LeerTodosPaginado(string dataPanel, string resultContainer, int numeroPagina, int numeroFila);
        ResultadoDTO<BeneficiarioEditViewModel> LeerPorId(short id);
        ResultadoDTO<BeneficiarioEditViewModel> GrabarBeneficiario(BeneficiarioEditViewModel model, string usuario, string controlador, string pcclient);
        ResultadoDTO<string> EliminarBeneficiario(BeneficiarioDeleteViewModel model, string usuario, string controlador, string pcclient);
    }
}
