using System;
using System.Collections.Generic;
using System.Text;

namespace Paycor.MarketPlace.ApiClient.Models.SchedulingData
{
    public class EmployeeHolidayInstance
    {
        public Guid HolidayPolicyId { get; set; }

        public string HolidayName { get; set; }

        public DateTime HolidayDate { get; set; }

        public string HolidayHours { get; set; }
    }
}
