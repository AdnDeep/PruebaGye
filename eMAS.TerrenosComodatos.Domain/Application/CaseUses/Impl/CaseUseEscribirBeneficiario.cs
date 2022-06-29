using eMAS.TerrenosComodatos.Domain.Application.CaseUses.Mappers;
using eMAS.TerrenosComodatos.Domain.Application.CaseUses.Validations;
using eMAS.TerrenosComodatos.Domain.DTOs;
using eMAS.TerrenosComodatos.Domain.Entities;
using eMAS.TerrenosComodatos.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace eMAS.TerrenosComodatos.Domain.Application.CaseUses
{
    public class CaseUseEscribirBeneficiario : ICaseUseEscribirBeneficiario
    {
        private readonly CaseUseEscrituraBeneficiarioMapeadores _caseUseEscrituraBeneficiarioMapeadores;
        private readonly CaseUseEscrituraBeneficiarioValidadores _validadoresCaseUseEscrituraBeneficiario;
        private readonly IGestionRepositorioEscrituraBeneficiario _gestionRepositorioEscrituraBeneficiario;
        private readonly IGestionRepositorioValidacionesBeneficiario _gestionRepositorioValidacionesBeneficiario;
        private readonly ILogger<CaseUseEscribirBeneficiario> _logger;
        public CaseUseEscribirBeneficiario(ILogger<CaseUseEscribirBeneficiario> logger
            , CaseUseEscrituraBeneficiarioValidadores validadoresCaseUseEscrituraBeneficiario
            , IGestionRepositorioEscrituraBeneficiario gestionRepositorioEscrituraBeneficiario
            , IGestionRepositorioValidacionesBeneficiario gestionRepositorioValidacionesBeneficiario
            , CaseUseEscrituraBeneficiarioMapeadores caseUseEscrituraBeneficiarioMapeadores)
        {
            _logger = logger;
            _gestionRepositorioEscrituraBeneficiario = gestionRepositorioEscrituraBeneficiario;
            _validadoresCaseUseEscrituraBeneficiario = validadoresCaseUseEscrituraBeneficiario;
            _gestionRepositorioValidacionesBeneficiario = gestionRepositorioValidacionesBeneficiario;
            _caseUseEscrituraBeneficiarioMapeadores = caseUseEscrituraBeneficiarioMapeadores;
        }
        public ResultadoDTO<BeneficiarioEditModel> GrabarBeneficiario(BeneficiarioEditModel model, string usuario, string controlador, string pcclient)
        {
            ResultadoDTO<BeneficiarioEditModel> resultadoVista = new ResultadoDTO<BeneficiarioEditModel>();
            BeneficiarioEditModel _beneficiarioEditModelRespuesta = null;
            Beneficiario _beneficiarioEntidad = null;
            ResultadoDTO<Tuple<List<EntidadValidacion>, string>> resultadoDataValidacion = new ResultadoDTO<Tuple<List<EntidadValidacion>, string>>();

            List<Mensaje> lsMensajes = new List<Mensaje>();
            
            bool respuestaValidacionesCliente = _validadoresCaseUseEscrituraBeneficiario.ValidarDatosClienteBeneficiarioEditModel(ref model, ref resultadoVista);

            if (!respuestaValidacionesCliente)
            {
                _beneficiarioEditModelRespuesta = new BeneficiarioEditModel();
                resultadoVista.dataresult = _beneficiarioEditModelRespuesta;
                return resultadoVista;
            }
            
            // Validaciones 2
            BeneficiariosValidacion1Filter bValidacion1Filter = new BeneficiariosValidacion1Filter();
            _caseUseEscrituraBeneficiarioMapeadores.MapearModelBeneficiarioEditViewAModelValidacion1(ref model, ref bValidacion1Filter);

            resultadoDataValidacion = _gestionRepositorioValidacionesBeneficiario.GetDataValidacionBeneficiarios1(bValidacion1Filter);

            bool respuestaValidacionesServidor = _validadoresCaseUseEscrituraBeneficiario.ValidarDatosServidorBeneficiarioEditModel(ref resultadoDataValidacion, ref resultadoVista);

            if (!respuestaValidacionesServidor)
            {
                _beneficiarioEditModelRespuesta = new BeneficiarioEditModel();
                resultadoVista.dataresult = _beneficiarioEditModelRespuesta;
                return resultadoVista;
            }

            // Mapear datos desde cliente a servidor
            _beneficiarioEntidad = new Beneficiario();
            _caseUseEscrituraBeneficiarioMapeadores.MapearModelBeneficiarioEditViewAModelBeneficiario(ref model, ref _beneficiarioEntidad, usuario, controlador, pcclient);

            // Escribe datos en Servidor
            ResultadoDTO<string> respuestaGestionRepositorio = null;
            if (model.id == 0)
            {
                // Crear
                respuestaGestionRepositorio = _gestionRepositorioEscrituraBeneficiario.CrearBeneficiario(_beneficiarioEntidad);
            }
            else 
            {
                // Actualizar
                respuestaGestionRepositorio = _gestionRepositorioEscrituraBeneficiario.ActualizarBeneficiario(_beneficiarioEntidad);
            }
            var respuestaValidacion = _validadoresCaseUseEscrituraBeneficiario.ValidarRespuestaServidorGestionCrear(ref respuestaGestionRepositorio, ref resultadoVista);

            // Setear Data Clave 
            lsMensajes.Add(new Mensaje { codigo = "CLAVEID", descripcion = model.id.ToString(), tipo = "COMINTERNA" });
            resultadoVista.mensajes = lsMensajes;
            if (!respuestaValidacion)
            {
                _beneficiarioEditModelRespuesta = new BeneficiarioEditModel();
                resultadoVista.dataresult = _beneficiarioEditModelRespuesta;
                return resultadoVista;
            }
            _beneficiarioEditModelRespuesta = new BeneficiarioEditModel();
            resultadoVista.dataresult = _beneficiarioEditModelRespuesta;

            return resultadoVista;
        }
    }
}
