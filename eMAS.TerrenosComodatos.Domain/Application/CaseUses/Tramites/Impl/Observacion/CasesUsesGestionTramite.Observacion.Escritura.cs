using eMAS.TerrenosComodatos.Domain.DTOs;

namespace eMAS.TerrenosComodatos.Domain.Application
{
    public partial class CasesUsesGestionTramite : ICasesUsesGestionTramite
    {
        private ResultadoDTO<int> GrabarObservacion(string strModelo, string usuario, string controlador, string pcclient)
        {
            ResultadoDTO<int> resultadoVista = new ResultadoDTO<int>();
            ObservacionTramiteEditViewModel model = new ObservacionTramiteEditViewModel();

            bool respValCli1 =_validadores.DataClienteEscrituraDetalle<ObservacionTramiteEditViewModel>(strModelo, ref resultadoVista, ref model);

            if (!respValCli1)
                return resultadoVista;

            bool respValCli = _validadores.DataClienteEscrituraObservacion(ref model, ref resultadoVista);

            if (!respValCli)
                return resultadoVista;
            
            ResultadoDTO<int> respServRemoto = new ResultadoDTO<int>();

            _mapeadores.MapearDataEscrituraObservacion(ref model);
                
            if (model.idtramitedesc == 0)
            {
                respServRemoto= _repositorioExterno.CrearObservacion(model, usuario, controlador, pcclient);
            }
            else if (model.idtramite > 0)
            {
                respServRemoto= _repositorioExterno.ActualizarObservacion(model, usuario, controlador, pcclient);
            }

            bool valRespServ = _validadores.RespuestaServidorRemotoEscrituraDetail<int>(ref respServRemoto, ref resultadoVista);

            if (!valRespServ)
                return resultadoVista;

            _mapeadores.GenerateEditViewModelDetailAfterSave(ref respServRemoto, ref resultadoVista, model.idtramitedesc == 0);

            return resultadoVista;
        }
    }
}
