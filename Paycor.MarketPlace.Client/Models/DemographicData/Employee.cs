using System;

namespace Paycor.MarketPlace.ApiClient.Models.DemographicData
{
    public class Employee
    {
        public string Id { get; set; }        
        public long? EmployeeUid { get; set; }        
        public int ClientId { get; set; }        
        public int? EmployeeNumber { get; set; }
        public Person Person { get; set; }
        public Manager Manager { get; set; }        
        public Address PrimaryAddress { get; set; }
        public string WorkPhone { get; set; }
        public string WorkEmail { get; set; }
        public string EmploymentStatus { get; set; }
        public string StatusType { get; set; }
        public string Flsa { get; set; }
        public string EmployeeType { get; set; }
        public decimal? AnnualHours { get; set; }
        public string OwnerOfficer { get; set; }
        public decimal? OwnershipPercent { get; set; }
        public short? BaseShift { get; set; }
        public bool? KeyEmployee { get; set; }
        public bool? HighlyCompensatedEmployee { get; set; }
        public string FamilyMember { get; set; }
        public int? Section125IneligibleEmployee { get; set; }
        public string RetirementPlan { get; set; }
        public string BenefitClassification { get; set; }
        public string JobTitle { get; set; }
        public long? DepartmentCode { get; set; }
        public long? PayrollCode { get; set; }
        public string PaygroupDescription { get; set; }
        public string StateCode { get; set; }
        public string ProfilePicture { get; set; }
        public DateTime? HireDate { get; set; }
        public string WorkLocation { get; set; }
        public string PaygroupFrequency { get; set; }
        public DateTime? ReHireDate { get; set; }
        public string PayrollName { get; set; }
        public int? CompanyId { get; set; }
        public string WorkFaxNumber { get; set; }
        public DateTime? TerminationDate { get; set; }
        public string TerminationReason { get; set; }
        public long? BaseDepartmentUid { get; set; }
        public long? PayrollUid { get; set; }        
        public long? PaygroupUid { get; set; }
        public string WorkAnniversaryDay { get; set; }
        public int? DaysToWorkAnniversary { get; set; }
        public bool HasWorkAnniversary { get; set; }
        public int? AnniversaryYears { get; set; }        
        public bool? HasDirectReports { get; set; }
    }
}
