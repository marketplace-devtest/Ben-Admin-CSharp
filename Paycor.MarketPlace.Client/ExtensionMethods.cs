using Paycor.MarketPlace.ApiClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Paycor.MarketPlace.ApiClient
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Takes an IEnumerable of QueryStringParameter and returns an UrlEncoded query string.
        /// </summary>
        /// <param name="queryStringParameters">IEnumerable of QueryStringParamete.</param>
        /// <returns></returns>
        public static string GetQueryString(this IEnumerable<QueryStringParameter> queryStringParameters)
        {
            string queryString = "";
            if (queryStringParameters != null)
            {
                var queryStringCollection = queryStringParameters.Select(q => HttpUtility.UrlEncode(q.QueryStringName) + "=" + HttpUtility.UrlEncode(q.Value)).ToArray();

                queryString = String.Concat("?", String.Join("&", queryStringCollection));
            }

            return queryString;
        }       
    }
}
