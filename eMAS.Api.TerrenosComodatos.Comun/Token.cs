//using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using System;
using System.Threading.Tasks;

namespace eMAS.Api.TerrenosComodatos.Comun
{
    public class Token
    {
        private string clientId;
        private string secretIdweb;
        private string aadInstance;
        private string tenantId;
        private string scope;
        private string authority;
        //private IHttpContextAccessor _httpContextAccessor;
        private IConfiguration _configuration;

        public Token(
            //IHttpContextAccessor httpContextAccessor,
            IConfiguration configuration)
        {
            //_httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            clientId = configuration["ClientCredentialApiComodato:ClientId"];
            secretIdweb = configuration["ClientCredentialApiComodato:SecretId"];
            tenantId = configuration["ClientCredentialApiComodato:TenantId"];
            aadInstance = configuration["ClientCredentialApiComodato:Instance"];
            authority = aadInstance + tenantId;

        }
        public async Task<string> GetToken(string apiNombre)
        {
            try
            {
                string ClientIdApi = "";
                
                ClientIdApi = _configuration[apiNombre];
                
                scope = ClientIdApi;

                IConfidentialClientApplication app = ConfidentialClientApplicationBuilder
                                                            .Create(clientId)
                                                            .WithClientSecret(secretIdweb)
                                                            .WithAuthority(new Uri(authority)) 
                                                            .Build();
                var accessToken = await app.AcquireTokenForClient(new[] { scope }).ExecuteAsync();

                return accessToken.AccessToken;
            }
            catch (Exception)
            {
                return "";
            }
        }

    }
}
