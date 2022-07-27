using eMAS.TerrenosComodatos.Domain.DTOs;

namespace eMAS.TerrenosComodatos.Domain.Application
{
    public partial class CasesUsesGestionTramite : ICasesUsesGestionTramite
    {
        private ResultadoDTO<int> EliminarTopografia(short id, string usuario, string controlador, string pcclient)
        {
            ResultadoDTO<int> resultadoVista = new ResultadoDTO<int>();

            bool respValCli = _validadores.DataClienteEliminacionDetalle(id, ref resultadoVista);

            if (!respValCli)
                return resultadoVista;
            var respServRemoto = _repositorioExterno.EliminarTopografia(id, usuario, controlador, pcclient);
            
            bool valRespServ = _validadores.RespuestaServidorRemotoEscrituraDetail<int>(ref respServRemoto, ref resultadoVista);

            if (!valRespServ)
                return resultadoVista;

            _mapeadores.GenerateEditViewModelDetailAfterSave(ref respServRemoto, ref resultadoVista, false);

            return resultadoVista;
        }

    }
}
