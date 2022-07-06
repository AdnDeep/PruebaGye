using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace eMAS.TerrenosComodatos.Infrastructure
{
    public class ApiService : IDisposable
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly ITokenAcquisition _tokenAcquisition;
        private readonly IConfiguration _configuration;
        public ApiService(IHttpClientFactory clientFactory,
            ITokenAcquisition tokenAcquisition,
            IConfiguration configuration)
        {
            _clientFactory = clientFactory;
            _tokenAcquisition = tokenAcquisition;
            _configuration = configuration;
        }
        public async Task<Tuple<int, string>> GetApiDataAsync(string baseAddressConf, string scopeConf, string urlResource)
        {
            int responseCode;
            string responseContent = "";
            try
            {
                using (var client = _clientFactory.CreateClient())
                {
                    //baseAddressConf - ApiComodato:ApiBaseAddress

                    //var scope = _configuration["CallApi:ScopeForAccessToken"];
                    //var accessToken = await _tokenAcquisition.GetAccessTokenForUserAsync(new[] { scope });

                    client.BaseAddress = new Uri(baseAddressConf);
                    //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var response = await client.GetAsync(urlResource);
                    if (response != null)
                    {
                        responseCode = (int)response.StatusCode;
                        if (response.Content != null)
                        {
                            responseContent = await response.Content.ReadAsStringAsync();
                        }
                    }
                    else
                    {
                        responseCode = (int)HttpStatusCode.NoContent;
                    }
                }
            }
            catch (Exception e)
            {
                responseCode = (int)HttpStatusCode.InternalServerError;
                responseContent = $"Excepction {e}";
            }
            return new Tuple<int, string>(responseCode, responseContent);
        }
        public void Dispose()
        {
        }
    }
}
