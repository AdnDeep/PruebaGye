using eMAS.TerrenosComodatos.Domain.Application.CaseUses.Mappers;
using eMAS.TerrenosComodatos.Domain.Application.CaseUses.Validations;
using eMAS.TerrenosComodatos.Domain.DTOs;
using eMAS.TerrenosComodatos.Domain.Entities;
using eMAS.TerrenosComodatos.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace eMAS.TerrenosComodatos.Domain.Application.CaseUses
{
    public class CaseUseEliminarBeneficiario : ICaseUseEliminarBeneficiario
    {
        private readonly CaseUseEliminacionBeneficiarioValidadores _validadoresCaseUseEliminacionBeneficiario;
        private readonly CaseUseEliminacionBeneficiarioMapeadores _caseUseEliminacionBeneficiarioMapeadores;
        private readonly ILogger<CaseUseLecturaBeneficiario> _logger;
        private readonly IGestionRepositorioEliminacionBeneficiario _gestionRepositorioEliminacionBeneficiario;
        public CaseUseEliminarBeneficiario(ILogger<CaseUseLecturaBeneficiario> logger
            , IGestionRepositorioEliminacionBeneficiario gestionRepositorioEliminacionBeneficiario
            , CaseUseEliminacionBeneficiarioValidadores validadoresCaseUseEliminacionBeneficiario
            , CaseUseEliminacionBeneficiarioMapeadores caseUseEliminacionBeneficiarioMapeadores
            )
        {
            _logger = logger;
            _gestionRepositorioEliminacionBeneficiario = gestionRepositorioEliminacionBeneficiario;
            _validadoresCaseUseEliminacionBeneficiario = validadoresCaseUseEliminacionBeneficiario;
            _caseUseEliminacionBeneficiarioMapeadores = caseUseEliminacionBeneficiarioMapeadores;
        }
        public ResultadoDTO<string> EliminarBeneficiario(BeneficiarioDeleteModel model, string usuario, string controlador, string pcclient)
        {
            ResultadoDTO<string> resultadoVista = new ResultadoDTO<string>();
            Beneficiario _beneficiarioEntidad = null;
            List<Mensaje> lsMensajes = new List<Mensaje>();

            bool respuestaValidacionesCliente = _validadoresCaseUseEliminacionBeneficiario.ValidarDatosEliminacionClienteBeneficiario(ref model, ref resultadoVista);

            if (!respuestaValidacionesCliente) 
                return resultadoVista;

            // Mapear datos desde cliente a servidor
            _beneficiarioEntidad = new Beneficiario();
            _caseUseEliminacionBeneficiarioMapeadores.MapearBeneficiarioDeleteModelABeneficiario(ref model, ref _beneficiarioEntidad, usuario, controlador, pcclient);

            ResultadoDTO<string> respuestaGestionRepositorio = new ResultadoDTO<string>();
            respuestaGestionRepositorio = _gestionRepositorioEliminacionBeneficiario.EliminarBeneficiario(_beneficiarioEntidad);

            var respuestaValidacion = _validadoresCaseUseEliminacionBeneficiario.ValidarDatosEliminacionServidorGestionRepositorio(ref respuestaGestionRepositorio, ref resultadoVista);

            if (!respuestaValidacion)
                return resultadoVista;

            return resultadoVista;
        }
    }
}
