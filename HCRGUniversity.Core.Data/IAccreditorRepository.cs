using Core.Base.Data;
using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;
using BLModel=HCRGUniversity.Core.BL.Model;


namespace HCRGUniversity.Core.Data
{
    public interface IAccreditorRepository : IBaseRepository<Accreditor>
    {
        IEnumerable<BLModel.Accreditor> GetAllAccreditorsByOrganizationID(int clientID, int orgID);
    }
}
