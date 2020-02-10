using HCRGUniversity.Core.BL.Model;
using System.Collections.Generic;
using BLModel = HCRGUniversity.Core.BL.Model;

namespace HCRGUniversity.Core.BL
{
    public interface IAboutUs
    {
        int AddAboutUs(About aboutus);
        int UpdateAboutUs(About aboutus);
        void DeleteAboutUs(int aboutUsID);
        IEnumerable<About> getAll(int _organizationID);
        BLModel.Paged.AboutUs GetAllPagedAboutus(int skip, int take, int _organizationID);
        IEnumerable<BLModel.About> GetAllAboutUsByOrganizationID(int OrganizationID, int ClientID);
    }
}