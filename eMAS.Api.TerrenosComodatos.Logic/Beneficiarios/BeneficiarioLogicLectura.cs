using eMAS.Api.TerrenosComodatos.Entities;
using eMAS.Api.TerrenosComodatos.IRepository;
using eMAS.Api.TerrenosComodatos.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eMAS.Api.TerrenosComodatos.Logic
{
    public class BeneficiarioLogicLectura
    {
        private readonly IRepositorioBeneficiarioLectura _repositorioBeneficiarioLectura;
        public BeneficiarioLogicLectura(IRepositorioBeneficiarioLectura repositorioBeneficiarioLectura)
        {
            _repositorioBeneficiarioLectura = repositorioBeneficiarioLectura;
        }
        public Tuple<List<SmcBeneficiarioPaginado>, int> ObtenerBeneficiariosPaginado(BeneficiariosPanelFilterModel panelModel, int numeroPagina, int numeroFilas)
        {
            var resultadoBD = Task.Run(async () => await _repositorioBeneficiarioLectura
                                        .GetBeneficiarioTodosPaginado(panelModel, numeroPagina, numeroFilas)).Result;
            return resultadoBD;
        }
        public Tuple<SmcBeneficiarioEdit, string, short> ObtenerBeneficiarioPorId(short id)
        {
            var resultadoBD = _repositorioBeneficiarioLectura
                                            .GetBeneficiarioPorId(id);
            return resultadoBD;
        }
    }
}
