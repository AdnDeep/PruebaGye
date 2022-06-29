using eMAS.TerrenosComodatos.Domain.DTOs;
using eMAS.TerrenosComodatos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMAS.TerrenosComodatos.Domain.Application.CaseUses.Mappers
{
    public class CaseUseEliminacionBeneficiarioMapeadores
    {
        public void MapearBeneficiarioDeleteModelABeneficiario(ref BeneficiarioDeleteModel entrada, ref Beneficiario salida
            , string usuario, string controlador, string pcclient)
        {
            salida.IdBeneficiario = entrada.id;
            salida.PdpEstado = false;
            salida.PdpUsuarioUltimaModificacion = usuario;
            salida.PdpFechaUltimaModificacion = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            salida.PdpUltimaTransaccion = controlador;
            salida.PdpUltimaPcCliente = pcclient;
        }
    }
}
