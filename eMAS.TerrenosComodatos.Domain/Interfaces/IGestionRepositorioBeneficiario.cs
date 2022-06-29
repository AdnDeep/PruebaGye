using eMAS.TerrenosComodatos.Domain.DTOs;
using eMAS.TerrenosComodatos.Domain.Entities;
using System;
using System.Collections.Generic;

namespace eMAS.TerrenosComodatos.Domain.Interfaces
{
    public interface IGestionRepositorioEliminacionBeneficiario
    {
        ResultadoDTO<string> EliminarBeneficiario(Beneficiario model);
    }
    public interface IGestionRepositorioEscrituraBeneficiario
    {
        ResultadoDTO<string> CrearBeneficiario(Beneficiario model);
        ResultadoDTO<string> ActualizarBeneficiario(Beneficiario model);
    }
    public interface IGestionRepositorioValidacionesBeneficiario
    {
        ResultadoDTO<Tuple<List<EntidadValidacion>, string>> GetDataValidacionBeneficiarios1(BeneficiariosValidacion1Filter validacionFilter);
    }
    public interface IGestionRepositorioLecturaBeneficiario
    {
        ResultadoDTO<Tuple<IList<Beneficiario>,int>> GetBeneficiarioTodosPaginado(BeneficiariosPanelFilterModel panelModel, int numeroPagina, int numeroFilas);
        ResultadoDTO<Beneficiario> GetBeneficiarioPorNombre(string nombre);
        ResultadoDTO<Tuple<Beneficiario, string, short>> GetBeneficiarioPorId(short id);
    }
    public interface IGestionRepositorioLecturaGenerica
    {
        ResultadoDTO<Tuple<List<KeyValueSelect>, string>> ObtenerListadoGenerico(string keyparam);
    }
}
