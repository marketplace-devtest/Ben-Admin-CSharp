using Microsoft.Extensions.Configuration;
using Paycor.MarketPlace.ApiClient;
using Paycor.MarketPlace.ApiClient.Models;
using Paycor.MarketPlace.ApiClient.Models.DemographicData;
using Paycor.MarketPlace.ApiClient.Models.SchedulingData;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Paycor.MarketPlace.Samples
{
    class Program
    {
        static PaycorApiClient _client;
        static async Task Main(string[] args)
        {
            var config = GetConfig();

            Console.WriteLine("Calling Api");
            Console.WriteLine();

            _client = new PaycorApiClient(config["baseUrl"], config["subscriptionKey"], config["oauthClient"], config["oauthSecret"]);

            await GetFirstPageOfEmployees();
            await GetSinglePageOfEmployees();
            await GetThreePagesOfEmployees();
            await GetMaxEmployeeNumber();
            await GetEmployeesSmallObjectSize();
            await GetEmployeesUsingUnCommonQueryStringParameter();
            await GetEmployeeHolidays();

            Console.WriteLine();
            Console.WriteLine("Press any key to close.");
            Console.ReadKey();
        }

        static Dictionary<string, string> GetConfig()
        {

            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            return config.GetSection("APIClient").GetChildren().ToDictionary(c => c.Key, c => c.Value);
        }

        static async Task GetFirstPageOfEmployees()
        {
            Console.WriteLine("GetFirstPageOfEmployees");
            var parameterCollection = new List<QueryStringParameter>();
            parameterCollection.Add(new QueryStringParameter(CommonQueryStringNames.PageSize, "10"));

            var employeeCollection = await _client.DemographicData.GetEmployeeListV1(parameterCollection);

            WriteEmployeeCollectionToConsole("test");
        }

        static async Task GetSinglePageOfEmployees()
        {
            Console.WriteLine("GetSinglePageOfEmployees");
            var parameterCollection = new List<QueryStringParameter>();
            parameterCollection.Add(new QueryStringParameter(CommonQueryStringNames.PageSize, "10"));
            parameterCollection.Add(new QueryStringParameter(CommonQueryStringNames.Page, "3"));

            var employeeCollection = await _client.DemographicData.GetEmployeeListV1(parameterCollection);

            WriteEmployeeCollectionToConsole(employeeCollection);
        }

        static async Task GetThreePagesOfEmployees()
        {
            Console.WriteLine("GetThreePagesOfEmployees");
            var numberOfPages = 3;
            var employeeCollection = new List<Employee>();
            for (var i = 1; i <= numberOfPages; i++)
            {
                var parameterCollection = new List<QueryStringParameter>();
                parameterCollection.Add(new QueryStringParameter(CommonQueryStringNames.PageSize, "10"));
                parameterCollection.Add(new QueryStringParameter(CommonQueryStringNames.Page, i.ToString()));

                employeeCollection.AddRange(await _client.DemographicData.GetEmployeeListV1(parameterCollection));
            }

            WriteEmployeeCollectionToConsole(employeeCollection);
        }

        static async Task GetMaxEmployeeNumber()
        {
            Console.WriteLine("GetMaxEmployeeNumber");

            var parameterCollection = new List<QueryStringParameter>();
            parameterCollection.Add(new QueryStringParameter(CommonQueryStringNames.Sort, "-employeeNumber"));
            parameterCollection.Add(new QueryStringParameter(CommonQueryStringNames.PageSize, "1"));

            var employeeCollection = await _client.DemographicData.GetEmployeeListV1(parameterCollection);

            WriteEmployeeCollectionToConsole(employeeCollection);
        }

        static async Task GetEmployeesSmallObjectSize()
        {
            Console.WriteLine("GetEmployeesSmallObjectSize");

            var parameterCollection = new List<QueryStringParameter>();
            parameterCollection.Add(new QueryStringParameter(CommonQueryStringNames.ObjectSize, "small"));
            parameterCollection.Add(new QueryStringParameter(CommonQueryStringNames.PageSize, "10"));

            var employeeCollection = await _client.DemographicData.GetEmployeeListV1(parameterCollection);

            WriteEmployeeCollectionToConsole(employeeCollection);
        }

        static async Task GetEmployeesUsingUnCommonQueryStringParameter()
        {
            Console.WriteLine("GetEmployeesUsingUnCommonQueryStringParameter");

            var parameterCollection = new List<QueryStringParameter>();
            parameterCollection.Add(new QueryStringParameter("includeDirectReportField", "true"));
            parameterCollection.Add(new QueryStringParameter(CommonQueryStringNames.PageSize, "10"));

            var employeeCollection = await _client.DemographicData.GetEmployeeListV1(parameterCollection);

            WriteEmployeeCollectionToConsole(employeeCollection);
        }

        static async Task GetEmployeeHolidays()
        {
            var clientId = 302;
            var startDate = DateTime.Parse("01/01/2018");

            var employeeHolidays = await _client.SchedulingData.GetHolidaysV1(clientId, startDate);
            WriteEmployeeHolidayCollectionToConosle(employeeHolidays);
        }

        static void WriteEmployeeHolidayCollectionToConosle(EmployeeHolidays employeeHolidays)
        {
            Console.WriteLine("============================");
            foreach(var employee in employeeHolidays.Employees)
            {
                Console.WriteLine($"Employee {employee.EmployeeId}");
                foreach (var holiday in employee.Holidays)
                {
                    Console.WriteLine($"PolicyId: {holiday.HolidayPolicyId}");
                    Console.WriteLine($"Holiday Name: {holiday.HolidayName}");
                    Console.WriteLine($"Holiday Date: {holiday.HolidayDate}");
                    Console.WriteLine($"Holiday Hours: {holiday.HolidayHours}");
                    Console.WriteLine();
                }
            }
            Console.WriteLine("============================");
            Console.WriteLine();
        }

        static void WriteEmployeeCollectionToConsole(IEnumerable<Employee> employeeCollection)
        {
            Console.WriteLine("============================");
            foreach (var employee in employeeCollection)
            {
                if (employee.HasDirectReports != null)
                {
                    Console.WriteLine($"ClientID: {employee.ClientId}, Employee#: {employee.EmployeeNumber} HasDirectReports: {employee.HasDirectReports}");
                }
                else
                {
                    Console.WriteLine($"ClientID: {employee.ClientId}, Employee#: {employee.EmployeeNumber}");
                }
            }
            Console.WriteLine("============================");
            Console.WriteLine();
        }
    }
}
