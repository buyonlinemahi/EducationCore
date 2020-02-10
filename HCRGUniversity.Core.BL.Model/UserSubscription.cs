using System;

namespace HCRGUniversity.Core.BL.Model
{
   public class UserSubscription
    {
        public int UserSubscriptionID { get; set; }
        public decimal IndividualAccessPricing { get; set; }
        public decimal IndividualAccessPricingStart { get; set; }
        public decimal IndividualAccessPricingEnd { get; set; }
        public string IndividualAccessTermsOfService { get; set; }
        public decimal AllAccessPassPricing { get; set; }
        public decimal AllAccessParametersCoursePriceStart { get; set; }
        public decimal AllAccessParametersCoursePriceEnd { get; set; }
        public bool? AllAccessIncludeProgram { get; set; }
        public string AllAccessTermsOfService { get; set; }
        public decimal EnterprisePricing { get; set; }
        public string EnterpriseTermsOfService { get; set; }
        public int OrganizationID { get; set; }
        public string OrganizationName { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
