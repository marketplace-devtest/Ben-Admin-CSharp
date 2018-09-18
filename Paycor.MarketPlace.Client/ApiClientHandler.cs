using Paycor.MarketPlace.ApiClient.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Paycor.MarketPlace.ApiClient
{
    internal class ApiClientHandler : HttpClientHandler
    {
        const string GET_ACCESS_TOKEN_PATH = "Security/v2/AuthToken";
        readonly string _oauthClient = null;
        readonly string _oauthSecret = null;
        readonly string _subscriptionKey = null;

        AccessToken _accessToken = null;        

        public ApiClientHandler(string subscriptionKey, string oauthClient, string oauthSecret)
        {
            _oauthClient = oauthClient;
            _oauthSecret = oauthSecret;
            _subscriptionKey = subscriptionKey;            
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if(_accessToken == null || _accessToken.Expires <= DateTime.UtcNow)
            {
                var baseUrl = request.RequestUri.AbsoluteUri.Substring(0, request.RequestUri.AbsoluteUri.IndexOf(request.RequestUri.AbsolutePath));
                _accessToken = await GetAccessToken(baseUrl);               
            }

            AddRequestHeaders(request);
            
            return await base.SendAsync(request, cancellationToken);
        }
        
        private void AddRequestHeaders(HttpRequestMessage request)
        {           
            request.Headers.TryAddWithoutValidation("Ocp-Apim-Subscription-Key", _subscriptionKey);
            request.Headers.TryAddWithoutValidation("Authorization", string.Format("Bearer {0}", _accessToken.Token));
        }

        private async Task<AccessToken> GetAccessToken(string baseUrl)
        {
            var getAccessTokenUrl = string.Format("{0}/{1}", baseUrl, GET_ACCESS_TOKEN_PATH);
            var tokenRequest = new HttpRequestMessage(HttpMethod.Post, getAccessTokenUrl);
            var tokenCancellation = new CancellationToken(false);           

            tokenRequest.Headers.TryAddWithoutValidation("Accept", "application/json");
            tokenRequest.Headers.TryAddWithoutValidation("Ocp-Apim-Subscription-Key", _subscriptionKey);

            var formValues = GetAccessTokenFormValues();
            tokenRequest.Content = new FormUrlEncodedContent(formValues);

            var result = await base.SendAsync(tokenRequest, tokenCancellation);

            return await result.Content.ReadAsAsync<AccessToken>();
        }

        private IEnumerable<KeyValuePair<string,string>> GetAccessTokenFormValues()
        {
            var values = new List<KeyValuePair<string, string>>();
            values.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));
            values.Add(new KeyValuePair<string, string>("client_id", _oauthClient));
            values.Add(new KeyValuePair<string, string>("client_secret", _oauthSecret));

            return values;
        }
    }
}
