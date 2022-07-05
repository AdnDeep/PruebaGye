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
        ResultadoDTO<Tuple<IList<BeneficiarioListViewModel>, int>> GetBeneficiarioTodosPaginado(BeneficiarioPanelFilterViewModel panelModel, int numeroPagina, int numeroFilas);
        ResultadoDTO<Tuple<BeneficiarioEditViewModel, string, short>> GetBeneficiarioPorId(short id);
    }
}
