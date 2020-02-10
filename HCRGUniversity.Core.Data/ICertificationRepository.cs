using Core.Base.Data;
using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;
using BLModel = HCRGUniversity.Core.BL.Model;

namespace HCRGUniversity.Core.Data
{
    public interface ICertificationRepository : IBaseRepository<Certification>
    {
        IEnumerable<BLModel.Certification> GetAllCertificationsByOrganizationID(int OrganizationID, int ClientID);
    }
}
