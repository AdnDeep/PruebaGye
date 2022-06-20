using eMAS.TerrenosComodatos.Domain.DTOs;
using eMAS.TerrenosComodatos.Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMAS.TerrenosComodatos.Domain.Application.CaseUses.Validations
{
    public class CaseUseLecturaBeneficiarioValidadores
    {
        private readonly ILogger<CaseUseLecturaBeneficiarioValidadores> _logger;
        public CaseUseLecturaBeneficiarioValidadores(ILogger<CaseUseLecturaBeneficiarioValidadores> logger)
        {
            _logger = logger;
        }
        public bool ValidarRespuestaBeneficiarioPorId(ref ResultadoDTO<Tuple<Beneficiario, string, short>> entradaAValidar
            , ref ResultadoDTO<BeneficiarioEditModel> salida)
        {
            bool puedeContinuar = false;
            if (entradaAValidar == null)
            {
                _logger.LogError($"LeerPorId El objeto devuelto de la base de datos es nulo");
                salida.dataresult = new BeneficiarioEditModel();
                salida.mensaje = "Se produjo un error en la aplicación (1). Vuelva a intentar.";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }

            var mensajeProducidoErrCapaRepositorio = entradaAValidar.mensajes.FirstOrDefault(fod => fod.codigo == "GRBIMPLINT001");

            if (mensajeProducidoErrCapaRepositorio != null)
            {
                _logger.LogError($"LeerPorId {mensajeProducidoErrCapaRepositorio.descripcion}");
                salida.dataresult = new BeneficiarioEditModel();
                salida.mensaje = "Se produjo un error en la aplicación (2). Vuelva a intentar.";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }

            if (entradaAValidar.dataresult == null)
            {
                _logger.LogError($"LeerPorId El objeto devuelto de la base de datos es nulo (1)");
                salida.dataresult = new BeneficiarioEditModel();
                salida.mensaje = "Se produjo un error en la aplicación (3). Vuelva a intentar.";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            if (entradaAValidar.dataresult.Item1 == null || string.IsNullOrEmpty(entradaAValidar.dataresult.Item2)
                || string.IsNullOrWhiteSpace(entradaAValidar.dataresult.Item2))
            {
                _logger.LogError($"LeerPorId El objeto devuelto de la base de datos es nulo (2)");
                salida.dataresult = new BeneficiarioEditModel();
                salida.mensaje = "Se produjo un error en la aplicación (4). Vuelva a intentar.";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            if (entradaAValidar.dataresult.Item3 > 1)
            {
                _logger.LogError($"LeerPorId MensajeBD {entradaAValidar.dataresult.Item2}");
                salida.dataresult = new BeneficiarioEditModel();
                salida.mensaje = "Hay Errores en los datos de la aplicación.";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            if (entradaAValidar.dataresult.Item3 == 0)
            {
                _logger.LogError($"LeerPorId MensajeBD {entradaAValidar.dataresult.Item2}");
                salida.dataresult = new BeneficiarioEditModel();
                salida.mensaje = "El registro seleccionado no existe, por favor cree uno nuevo.";
                salida.tipo = "ADVERTENCIA";                
                return puedeContinuar;
            }

            puedeContinuar = true;
            return puedeContinuar;
        }
    }
}
