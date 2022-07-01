using eMAS.Api.TerrenosComodatos.Entities;
using eMAS.Api.TerrenosComodatos.IServices;
using eMAS.Api.TerrenosComodatos.Logic;
using eMAS.Api.TerrenosComodatos.ViewModel;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace eMAS.Api.TerrenosComodatos.Services
{
    public partial class ServiceTramiteEscritura : IServiceTramiteEscritura
    {
        public ResultadoDTO<int> ActualizarAnexo(AnexoTramiteEditViewModel model, string usuario, string controlador, string pcclient)
        {
            throw new NotImplementedException();
        }
        public ResultadoDTO<int> AgregarAnexo(AnexoTramiteEditViewModel model, string usuario, string controlador, string pcclient)
        {
            throw new NotImplementedException();
        }
    }
}
