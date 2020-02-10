using Core.Base.Data;
using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;
using BLModel = HCRGUniversity.Core.BL.Model;

namespace HCRGUniversity.Core.Data
{
    public interface IAboutUsRepository : IBaseRepository<About>
    {
        IEnumerable<About> GetAllPagedAboutUs(int skip, int take);
        int GetAboutUsCount();
        IEnumerable<BLModel.About> GetAllAboutUsByOrganizationID(int OrganizationID, int ClientID);
    }
}