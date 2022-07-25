using Microsoft.ApplicationInsights.AspNetCore.TelemetryInitializers;
using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.AspNetCore.Http;


namespace eMAS.Api.TerrenosComodatos
{
    public class TelemetryUser : TelemetryInitializerBase
    {
        public TelemetryUser(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {

        }


        protected override void OnInitializeTelemetry(HttpContext platformContext, RequestTelemetry requestTelemetry, ITelemetry telemetry)
        {
            telemetry.Context.User.AuthenticatedUserId =
              platformContext.User?.Identity.Name ?? string.Empty;

        }
    }
}
