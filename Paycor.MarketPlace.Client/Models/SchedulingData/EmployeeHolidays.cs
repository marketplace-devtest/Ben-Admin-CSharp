using System;
using System.Collections.Generic;
using System.Text;

namespace Paycor.MarketPlace.ApiClient.Models.SchedulingData
{
    public class EmployeeHolidays
    {
        public int ClientId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public IEnumerable<EmployeeHoliday> Employees { get; set; }

    }
}
