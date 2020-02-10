using Core.Base.Data;
using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;
using BLModel = HCRGUniversity.Core.BL.Model;

namespace HCRGUniversity.Core.Data
{
    public interface IHomeContentRepository : IBaseRepository<HomeContent>
    {
        IEnumerable<BLModel.HomeContent> GetAllHomeContentByOrganizationID(int clientID,int orgID);
    }
}
