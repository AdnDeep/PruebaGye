using eMAS.TerrenosComodatos.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMAS.TerrenosComodatos.Domain.Application.CaseUses
{
    public interface ICaseUseLecturaTramite
    {
        ResultadoDTO<DataPagineada<BeneficiarioListViewModel>> LeerTodosPaginado(string dataPanel, string resultContainer, int numeroPagina, int numeroFila);

        ResultadoDTO<BeneficiarioEditViewModel> LeerPorId(short id);
    }
}
