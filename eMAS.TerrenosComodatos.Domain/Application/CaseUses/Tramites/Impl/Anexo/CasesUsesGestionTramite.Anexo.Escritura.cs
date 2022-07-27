using eMAS.TerrenosComodatos.Domain.DTOs;

namespace eMAS.TerrenosComodatos.Domain.Application
{
    public partial class CasesUsesGestionTramite : ICasesUsesGestionTramite
    {
        private ResultadoDTO<int> GrabarAnexo(string strModelo, string usuario, string controlador, string pcclient)
        {
            ResultadoDTO<int> resultadoVista = new ResultadoDTO<int>();
            AnexoTramiteEditViewModel model = new AnexoTramiteEditViewModel();

            bool respValCli1 =_validadores.DataClienteEscrituraDetalle<AnexoTramiteEditViewModel>(strModelo, ref resultadoVista, ref model);

            if (!respValCli1)
                return resultadoVista;

            bool respValCli = _validadores.DataClienteEscrituraAnexo(ref model, ref resultadoVista);

            if (!respValCli)
                return resultadoVista;
            
            ResultadoDTO<int> respServRemoto = new ResultadoDTO<int>();

            _mapeadores.MapearDataEscrituraAnexo(ref model);
                
            if (model.idanexotramite == 0)
            {
                respServRemoto= _repositorioExterno.CrearAnexo(model, usuario, controlador, pcclient);
            }
            else if (model.idtramite > 0)
            {
                respServRemoto= _repositorioExterno.ActualizarAnexo(model, usuario, controlador, pcclient);
            }

            bool valRespServ = _validadores.RespuestaServidorRemotoEscrituraDetail<int>(ref respServRemoto, ref resultadoVista);

            if (!valRespServ)
                return resultadoVista;

            _mapeadores.GenerateEditViewModelDetailAfterSave(ref respServRemoto, ref resultadoVista, model.idanexotramite == 0);

            return resultadoVista;
        }
    }
}
