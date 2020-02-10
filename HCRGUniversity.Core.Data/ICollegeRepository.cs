using Core.Base.Data;
using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;

namespace HCRGUniversity.Core.Data
{
    public interface ICollegeRepository : IBaseRepository<College>
    {
        IEnumerable<College> GetAllPagedCollege(int skip, int take);
        int GetCollegeCount();
        IEnumerable<BL.Model.College> GetAllCollegeByClientID(int ClientID);

        IEnumerable<BL.Model.College> GetAllCollegeWeb(int OrganizationID);
        IEnumerable<BL.Model.College> GetAllCollegeByOrganizationID(int _organizationID);
    }
}