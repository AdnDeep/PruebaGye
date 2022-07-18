using eMAS.TerrenosComodatos.Domain.DTOs;
using eMAS.TerrenosComodatos.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace eMAS.TerrenosComodatos.Domain.Application
{
    public partial class CasesUsesGestionTramite : ICasesUsesGestionTramite
    {
        public ResultadoDTO<int> GrabarTramite(TramiteEditViewModel model, string usuario, string controlador, string pcclient)
        {
            ResultadoDTO<int> resultadoVista = new ResultadoDTO<int>();

            bool respValCli = _validadores.DataClienteEscritura(ref model, ref resultadoVista);

            if (!respValCli)
                return resultadoVista;
            ResultadoDTO<int> respServRemoto = new ResultadoDTO<int>();

            _mapeadores.MapearDataEscritura(ref model);
                
            if (model.idtramite == 0)
            {
                respServRemoto= _repositorioExterno.Crear(model, usuario, controlador, pcclient);
            }
            else if (model.idtramite > 0)
            {
                respServRemoto= _repositorioExterno.Actualizar(model, usuario, controlador, pcclient);
            }

            bool valRespServ = _validadores.RespuestaServidorRemotoEscritura(ref respServRemoto, ref resultadoVista);

            if (!valRespServ)
                return resultadoVista;

            _mapeadores.GenerateEditViewModelAfterSave(ref respServRemoto, ref resultadoVista, model.idtramite == 0);

            return resultadoVista;
        }
    }
}
