using System;
using System.Collections.Generic;
using System.Text;

namespace Paycor.MarketPlace.ApiClient.Models.SchedulingData
{
    public class EmployeeHoliday
    {
        public Guid EmployeeId { get; set; }

        public IEnumerable<EmployeeHolidayInstance> Holidays { get; set; }
    }
}
