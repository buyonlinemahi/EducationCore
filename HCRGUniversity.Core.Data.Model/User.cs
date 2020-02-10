using System;

namespace HCRGUniversity.Core.Data.Model
{
    public class User:Base.BaseOrganizationColumn
    {
        public int UID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string EmailID { get; set; }
        public string Company { get; set; }
        public string Phone { get; set; }
        public string ProfessionalTitle { get; set; }
        public bool IsActive { get; set; }
        public bool IsLocked { get; set; }
        public int FailedAttemptCount { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public string Role { get; set; }
        public bool? IsAllAccessPricing { get; set; }
        public int? UserAllAccessPassID { get; set; }
        public bool? IsManagement { get; set; }
        public bool? IsCoursePreview { get; set; }
        public bool? IsVerified { get; set; }
        public DateTime? VerifiedOn { get; set; }
        public bool? IsCleared { get; set; }
        public DateTime? ClearedOn { get; set; }
        public int? ClearedBy { get; set; }
        public int UserMenuGroupID { get; set; }
        public string SpecialMenuIDs { get; set; }
        public int ClientID { get; set; }
        public string UserSessionID { get; set; }
    }
}