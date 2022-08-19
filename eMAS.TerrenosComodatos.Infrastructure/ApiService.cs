using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using Microsoft.Identity.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
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
        public async Task<Tuple<int, string>> GetAsync(string baseAddressConf, string scopeConf, string urlResource)
        {
            int responseCode = 0;
            string responseContent = "";
            try
            {
                using (var client = _clientFactory.CreateClient())
                {
                    var scope = _configuration[scopeConf];
                    var accessToken = await _tokenAcquisition.GetAccessTokenForUserAsync(new[] { scope });
                    //var accessToken = await _tokenAcquisition.GetAccessTokenForAppAsync( scope );

                    client.BaseAddress = new Uri(baseAddressConf);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _configuration["APIM:SubscriptionKey.MIMGApis"]);

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
                responseContent = $"Exception {e}";
            }
            return new Tuple<int, string>(responseCode, responseContent);
        }
        public async Task<Tuple<int, string>> PostAsync(string baseAddressConf, string scopeConf, string urlResource, object body)
        {
            int responseCode;
            string responseContent = "";
            try
            {
                using (var client = _clientFactory.CreateClient())
                {
                    var scope = _configuration[scopeConf];

                    var accessToken = await _tokenAcquisition.GetAccessTokenForUserAsync(new[] { scope });

                    client.BaseAddress = new Uri(baseAddressConf);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _configuration["APIM:SubscriptionKey.MIMGApis"]);

                    var contentBody = GetStringContent(body);
                    var response = await client.PostAsync(urlResource, contentBody);
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
        public async Task<Tuple<int, string>> PutAsync(string baseAddressConf, string scopeConf, string urlResource, object body)
        {
            int responseCode;
            string responseContent = "";
            try
            {
                using (var client = _clientFactory.CreateClient())
                {
                    var scope = _configuration[scopeConf];
                    var accessToken = await _tokenAcquisition.GetAccessTokenForUserAsync(new[] { scope });
                    client.BaseAddress = new Uri(baseAddressConf);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _configuration["APIM:SubscriptionKey.MIMGApis"]);

                    var contentBody = GetStringContent(body);
                    var response = await client.PutAsync(urlResource, contentBody);
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
        public async Task<Tuple<int, string>> DeleteAsync(string baseAddressConf, string scopeConf, string urlResource)
        {
            int responseCode;
            string responseContent = "";
            try
            {
                using (var client = _clientFactory.CreateClient())
                {
                    var scope = _configuration[scopeConf];
                    var accessToken = await _tokenAcquisition.GetAccessTokenForUserAsync(new[] { scope });

                    client.BaseAddress = new Uri(baseAddressConf);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _configuration["APIM:SubscriptionKey.MIMGApis"]);

                    var response = await client.DeleteAsync(urlResource);
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

        private StringContent GetStringContent(object body)
        {
            string content = JsonSerializer.Serialize(body);
            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");
            return stringContent;
        }
        public void Dispose()
        {
        }
    }
}
