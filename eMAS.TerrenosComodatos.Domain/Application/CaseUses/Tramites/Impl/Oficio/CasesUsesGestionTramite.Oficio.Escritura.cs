using eMAS.TerrenosComodatos.Domain.DTOs;

namespace eMAS.TerrenosComodatos.Domain.Application
{
    public partial class CasesUsesGestionTramite : ICasesUsesGestionTramite
    {
        private ResultadoDTO<int> GrabarOficio(string strModelo, string usuario, string controlador, string pcclient)
        {
            ResultadoDTO<int> resultadoVista = new ResultadoDTO<int>();
            OficioTramiteEditViewModel model = new OficioTramiteEditViewModel();

            bool respValCli1 =_validadores.DataClienteEscrituraDetalle<OficioTramiteEditViewModel>(strModelo, ref resultadoVista, ref model);

            if (!respValCli1)
                return resultadoVista;

            bool respValCli = _validadores.DataClienteEscrituraOficio(ref model, ref resultadoVista);

            if (!respValCli)
                return resultadoVista;
            
            ResultadoDTO<int> respServRemoto = new ResultadoDTO<int>();

            _mapeadores.MapearDataEscrituraOficio(ref model);
                
            if (model.idoficiootrasdirecciones == 0)
            {
                respServRemoto= _repositorioExterno.CrearOficio(model, usuario, controlador, pcclient);
            }
            else if (model.idtramite > 0)
            {
                respServRemoto= _repositorioExterno.ActualizarOficio(model, usuario, controlador, pcclient);
            }

            bool valRespServ = _validadores.RespuestaServidorRemotoEscrituraDetail<int>(ref respServRemoto, ref resultadoVista);

            if (!valRespServ)
                return resultadoVista;

            _mapeadores.GenerateEditViewModelDetailAfterSave(ref respServRemoto, ref resultadoVista, model.idoficiootrasdirecciones == 0);

            return resultadoVista;
        }
    }
}
