using Paycor.MarketPlace.ApiClient.Models;
using Paycor.MarketPlace.ApiClient.Models.SchedulingData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Paycor.MarketPlace.ApiClient.Clients
{
    public class SchedulingDataClient : BaseClient
    {
        public SchedulingDataClient(HttpClient client)
            : base(client)
        {

        }

        /// <summary>
        /// Retrieves an EmployeeHolidays object from the SchedulingData Holidays version 1 endpoint.
        /// <para>Accepted Querystring Parameters: EndDate, Page, PageSize</para>        
        /// </summary>
        /// <param name="clientId">Integer value that represents the Paycor client id.</param>
        /// <param name="startDate">DateTime value that represents the start date.</param>
        /// <param name="queryParameters">IEnumberable of QueryStringParameter.  Will be used to build the querystring used in the API call.</param>
        /// <returns></returns>
        public async Task<EmployeeHolidays> GetHolidaysV1(int clientId, DateTime startDate, ICollection<QueryStringParameter> queryParameters = null)
        {
            AddQueryStringParameter(ref queryParameters, new QueryStringParameter("startDate", startDate.ToShortDateString()));

            string url = $"public/SchedulingData/v1/Clients/{clientId}/Holidays" + queryParameters.GetQueryString();

            HttpResponseMessage response = await Client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<EmployeeHolidays>();
            }

            throw HandleException(response);
        }
    }
}
