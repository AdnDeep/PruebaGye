using eMAS.TerrenosComodatos.Domain.DTOs;
using System.Collections.Generic;

namespace eMAS.TerrenosComodatos.Domain.Application
{
    public partial class MapeadoresTramite
    {
        public void MapearDataEscritura(ref TramiteEditViewModel model) 
        {
            string _strAreaSolar = model.strareasolar;
            if (!(string.IsNullOrEmpty(_strAreaSolar) || string.IsNullOrWhiteSpace(_strAreaSolar)))
            {
                if (_systemSettings.CurrentDecimalSeparator == ".")
                    _strAreaSolar = _strAreaSolar.Replace(',', '.');
                if (_systemSettings.CurrentDecimalSeparator == ",")
                    _strAreaSolar = _strAreaSolar.Replace('.', ',');

                decimal areaSolarTmp = 0;
                decimal.TryParse(_strAreaSolar, out areaSolarTmp);
                model.areasolar = areaSolarTmp;
            }
        }
        public void GenerateEditViewModelAfterSave(ref ResultadoDTO<int> model
            , ref ResultadoDTO<int> salida, bool esNuevo)
        {
            salida.tipo = model.tipo;
            salida.mensaje = model.mensaje;
            salida.dataresult = model.dataresult;
            salida.mensajes = new List<Mensaje>();
            if(esNuevo)
                salida.mensajes.Add(new Mensaje { tipo = "TRANSACCION", codigo = "INSERTADO", descripcion = salida.dataresult.ToString() });
        }
    }
}
