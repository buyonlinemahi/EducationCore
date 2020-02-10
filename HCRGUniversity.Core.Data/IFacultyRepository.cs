using Core.Base.Data;
using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;

namespace HCRGUniversity.Core.Data
{
    public interface IFacultyRepository : IBaseRepository<Faculty>
    {
        IEnumerable<Faculty> GetFacultyAll(int skip, int take, int organizationID);
        IEnumerable<HCRGUniversity.Core.BL.Model.Faculty> GetAllFacultiesByOrganizationID(int skip, int take, int organizationID, int ClientID);
        int GetAllFacultiesByOrganizationIDCount(int organizationID, int ClientID);
    }
}
