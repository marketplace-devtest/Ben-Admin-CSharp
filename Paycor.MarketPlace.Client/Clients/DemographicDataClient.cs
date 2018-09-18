using Paycor.MarketPlace.ApiClient.Models;
using Paycor.MarketPlace.ApiClient.Models.DemographicData;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Paycor.MarketPlace.ApiClient.Clients
{
    public class DemographicDataClient :BaseClient
    {
        public DemographicDataClient(HttpClient client)
            : base(client)
        {

        }

        /// <summary>
        /// Retrieves a list of employee objects from the DemographicData Employee List version 1 endpoint.
        /// <para>Accepted Querystring Parameters: ClientId, IncludeDirectReportField, ObjectSize, Page, PageSize, Sort</para>
        /// </summary>
        /// <param name="queryParameters">IEnumberable of QueryStringParameter.  Will be used to build the querystring used in the API call.</param>
        /// <returns></returns>
        public async Task<IEnumerable<Employee>> GetEmployeeListV1(IEnumerable<QueryStringParameter> queryParameters = null)
        {
            string url = "public/DemographicData/v1/employees" + queryParameters.GetQueryString();

            HttpResponseMessage response = await Client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<Employee[]>();
            }

            throw HandleException(response);
        }
    }
}
