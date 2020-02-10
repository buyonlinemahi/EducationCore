using Core.Base.Data;
using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;
using BLModel = HCRGUniversity.Core.BL.Model;

namespace HCRGUniversity.Core.Data
{

    public interface IAccreditationRepository : IBaseRepository<Accreditation>
    {
        IEnumerable<BLModel.Accreditation> GetAllAccreditationsByOrganizationID(int OrganizationID, int ClientID);
    }
}
