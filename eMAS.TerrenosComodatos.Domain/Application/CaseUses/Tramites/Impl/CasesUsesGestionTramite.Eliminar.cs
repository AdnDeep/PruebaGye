using eMAS.TerrenosComodatos.Domain.DTOs;
using eMAS.TerrenosComodatos.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace eMAS.TerrenosComodatos.Domain.Application
{
    public partial class CasesUsesGestionTramite : ICasesUsesGestionTramite
    {
        public ResultadoDTO<int> EliminarTramite(short id, string usuario, string controlador, string pcclient)
        {
            ResultadoDTO<int> resultadoVista = new ResultadoDTO<int>();

            bool respValCli = _validadores.DataClienteEliminacion(id, ref resultadoVista);

            if (!respValCli)
                return resultadoVista;
            var respServRemoto = _repositorioExterno.Eliminar(id, usuario, controlador, pcclient);
            
            bool valRespServ = _validadores.RespuestaServidorRemotoEscritura(ref respServRemoto, ref resultadoVista);

            if (!valRespServ)
                return resultadoVista;

            _mapeadores.GenerateEditViewModelAfterSave(ref respServRemoto, ref resultadoVista, false);

            return resultadoVista;
        }

    }
}
