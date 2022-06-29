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
    public partial class ServiceTramiteLectura : IServiceTramiteLectura
    {
        public ResultadoDTO<string> ConsultarObservacionesPorIdTramite(short idTramite)
        {
            throw new NotImplementedException();
        }

        public ResultadoDTO<string> ConsultarObservacionPorId(short id)
        {
            throw new NotImplementedException();
        }

    }
}
