using HCRGUniversity.Core.BL.Model;
using System.Collections.Generic;
using BLModel = HCRGUniversity.Core.BL.Model;
namespace HCRGUniversity.Core.BL
{
    public interface ICollege
    {
        int AddCollege(College college);
        int UpdateCollege(College college);
        void DeleteCollege(int collegeID, bool IsActive);
        College GetCollageByID(int collegeID);
        IEnumerable<College> getAllCollege(int clientID);
        IEnumerable<College> getAllCollegeActive(int ClientID);
        BLModel.Paged.College GetAllPagedCollege(int skip, int take, int ClientID);

        IEnumerable<College> GetAllCollegeWeb(int OrganizationID);
        IEnumerable<BLModel.College> GetAllCollegeActiveWeb(int OrganizationID);
        IEnumerable<BLModel.College> GetAllCollegeByOrganizationID(int OrganizationID);





    }
}