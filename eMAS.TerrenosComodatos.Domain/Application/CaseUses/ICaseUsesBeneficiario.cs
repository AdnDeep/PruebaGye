using eMAS.TerrenosComodatos.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMAS.TerrenosComodatos.Domain.Application.CaseUses
{
    public interface ICaseUseEliminarBeneficiario
    {
        /// <summary>
        /// Responda Los siguientes codigo
        /// 
        /// CUEBD0001 - Eliminado Exitoso, Tipo Exito
        /// CUEBD0002 - No Existe el registro Eliminado, Tipo Advertencia
        /// CUEBD0003 - ERROR BD, Se escribe en log, Presentador informa Se ha producido un error en la aplicación.
        /// </summary>
        /// <param name="id"></param>
        void EliminarBeneficiario(int id);
    }
    public interface ICaseUseEscribirBeneficiario
    {
        ResultadoDTO<BeneficiarioEditModel> GrabarBeneficiario(BeneficiarioEditModel model, string usuario, string controlador, string pcclient);
    }
    public interface ICaseUseLecturaBeneficiario
    {
        ResultadoDTO<DataPagineada<BeneficiariosViewModel>> LeerTodosPaginado(string dataPanel, string resultContainer, int numeroPagina, int numeroFila);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        ResultadoDTO<BeneficiarioEditModel> LeerPorId(short id);
    }
}
