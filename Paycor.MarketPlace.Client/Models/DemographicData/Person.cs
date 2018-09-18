using System;

namespace Paycor.MarketPlace.ApiClient.Models.DemographicData
{
    public class Person
    {
        public string Id { get; set; }
        public int ClientId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Prefix { get; set; }
        public string Suffix { get; set; }
        public string MaidenName { get; set; }
        public string Accredited { get; set; }
        public string LegalFirstName { get; set; }
        public string LegalLastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Birthday { get; set; }
        public int? DaysToBirthday { get; set; }
        public bool HasBirthday { get; set; }        
        public string Ssn { get; set; }
        public string Gender { get; set; }
        public string HomePhone { get; set; }
        public string HomeEmail { get; set; }
        public string MobilePhone { get; set; }
        public string Ethnicity { get; set; }
        public string MaritalStatus { get; set; }
        public string VeteranStatus { get; set; }
        public bool? IsTobaccoUser { get; set; }
        public string DisabilityStatus { get; set; }
        public DateTime? DischargeDate { get; set; }
        public bool? IsArmedForcesServiceMedalVeteran { get; set; }
        public bool? IsDisabledVeteran { get; set; }
        public bool? IsOtherProtectedVeteran { get; set; }
        public bool? IsRecentlySeperatedVeteran { get; set; }
        public bool? IsSpecialDisabledVeteran { get; set; }
        public bool? IsVietnamEra { get; set; }

    }
}
