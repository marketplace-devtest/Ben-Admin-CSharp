using Paycor.MarketPlace.ApiClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace Paycor.MarketPlace.ApiClient.Clients
{
    public class BaseClient
    {
        HttpClient _client;

        public HttpClient Client { get => _client; }

        public BaseClient(HttpClient client)
        {
            _client = client;
        }

        public static void AddQueryStringParameter(ref ICollection<QueryStringParameter> queryStringParameters, QueryStringParameter qsParameter)
        {
            if (queryStringParameters == null)
            {
                queryStringParameters = new List<QueryStringParameter>();
            }

            if (!queryStringParameters.Any(q => q.QueryStringName == qsParameter.QueryStringName))
            {
                queryStringParameters.Add(qsParameter);
            }
        }

        public static Exception HandleException(HttpResponseMessage response)
        {
            return new WebException(response.ReasonPhrase, (WebExceptionStatus)response.StatusCode);
        }
    }
}
