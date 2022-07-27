using eMAS.Api.TerrenosComodatos.Entities;
using eMAS.Api.TerrenosComodatos.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eMAS.Api.TerrenosComodatos.IRepository
{
    public interface IRepositorioBeneficiarioLectura
    {
        Tuple<SmcBeneficiarioEdit, string, short> GetBeneficiarioPorId(short id);
        Task<Tuple<List<SmcBeneficiarioPaginado>,int>> GetBeneficiarioTodosPaginado(BeneficiariosPanelFilterModel panelModel, int numeroPagina, int numeroFilas);
    }
}
