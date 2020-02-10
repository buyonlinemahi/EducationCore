
using System;
namespace HCRGUniversity.Core.Data.Model
{
    public class EnterprisePackageRegister
    {
        public int EPRID { get; set; }
        public string EPRName { get; set; }
        public string EPRPhone { get; set; }
        public string EPREmail { get; set; }
        public string EPRCompany { get; set; }
        public DateTime? EPRCreatedDate { get; set; }
        public int OrganizationID { get; set; }

    }
}
