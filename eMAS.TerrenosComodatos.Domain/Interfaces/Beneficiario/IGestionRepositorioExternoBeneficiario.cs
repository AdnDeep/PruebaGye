using eMAS.TerrenosComodatos.Domain.DTOs;
using System;
using System.Collections.Generic;

namespace eMAS.TerrenosComodatos.Domain.Interfaces
{
    public interface IGestionRepositorioExternoBeneficiario
    {
        ResultadoDTO<string> EliminarBeneficiario(BeneficiarioDeleteViewModel model);
        ResultadoDTO<string> CrearBeneficiario(BeneficiarioEditViewModel model);
        ResultadoDTO<string> ActualizarBeneficiario(BeneficiarioEditViewModel model);
        ResultadoDTO<DataPagineada<BeneficiarioListViewModel>> GetBeneficiarioTodosPaginado(string panelFilter
                    , string resultContainer, int numeroPagina, int numeroFila);

        //ResultadoDTO<Tuple<IList<BeneficiarioListViewModel>, int>> GetBeneficiarioTodosPaginado(string panelFilter
        //    , string resultContainer, int numeroPagina, int numeroFila);
        ResultadoDTO<Tuple<BeneficiarioEditViewModel, string, short>> GetBeneficiarioPorId(short id);
    }
}
