using eMAS.TerrenosComodatos.Domain.DTOs;
using eMAS.TerrenosComodatos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMAS.TerrenosComodatos.Domain.Application.CaseUses.Mappers
{
    public class CaseUseLecturaBeneficiarioMapeadores
    {
        public void MapearBeneficiarioABeneficiarioEditModel(ref Beneficiario entrada, ref BeneficiarioEditModel salida)
        {
            salida.id = entrada.IdBeneficiario;
            salida.nombre = entrada.Nombre;
            salida.representante = entrada.NombreRepresentante;
            salida.ruc = entrada.Identificacion;
            salida.contacto = entrada.Contacto;
        }
        public void MapearListaBeneficiarioAListaBeneficiarioViewModel(ref IList<Beneficiario> lsBeneficiario
            , ref  List<BeneficiariosViewModel> lsBeneficiarioViewModel)
        {
            foreach (var det in lsBeneficiario)
            {
                lsBeneficiarioViewModel.Add(new BeneficiariosViewModel
                {
                    id = det.IdBeneficiario,
                    nombre = det.Nombre,
                    contacto = det.Contacto,
                    representante = det.NombreRepresentante,
                    ruc = det.Identificacion
                });
            }
        }
    }
}
