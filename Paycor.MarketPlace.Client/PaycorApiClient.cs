using Paycor.MarketPlace.ApiClient.Clients;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Paycor.MarketPlace.ApiClient
{
    public class PaycorApiClient
    {
        static HttpClient _client;
        static HttpClientHandler _handler;
        static bool _isInitialized = false;
        static object _lock = new object();

        DemographicDataClient _demographicDataClient;
        SchedulingDataClient _schedulingDataClient;

        public DemographicDataClient DemographicData { get => _demographicDataClient; }
        public SchedulingDataClient SchedulingData { get => _schedulingDataClient; }

        /// <summary>
        /// Initializes a new instance of the Paycor.MarketPlace.ApiClient.PaycorApiClient class to the value indicated
        /// by the specified string baseUrl, string subscriptionKey, string publicKey, and string privateKey.
        /// </summary>
        /// <param name="baseUrl">String value for the baseUrl of the PaycorApiClient.</param>
        /// <param name="subscriptionKey">string value for the subscriptionKey of the PaycorApiClient.</param>
        /// <param name="publicKey">string value for the publicKey of the PaycorApiClient.</param>
        /// <param name="privateKey">string value for the privateKey of the PaycorApiClient.</param>
        public PaycorApiClient(string baseUrl, string subscriptionKey, string oauthClient, string oauthSecret)
        {
            lock (_lock)
            {
                if (!_isInitialized)
                {
                    Init(baseUrl, subscriptionKey, oauthClient, oauthSecret);
                    _isInitialized = true;
                }
            }

            _demographicDataClient = new DemographicDataClient(_client);
            _schedulingDataClient = new SchedulingDataClient(_client);
        }

        private static void Init(string baseUrl, string subscriptionKey, string oauthClient, string oauthSecret)
        {
            _handler = new ApiClientHandler(subscriptionKey, oauthClient, oauthSecret);
            _client = new HttpClient(_handler) { BaseAddress = new Uri(baseUrl) };
            _client.Timeout = new TimeSpan(0, 20, 0);
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));            
        }
    }

    
}
