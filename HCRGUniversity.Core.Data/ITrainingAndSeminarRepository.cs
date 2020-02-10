using Core.Base.Data;
using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;
using BLModel = HCRGUniversity.Core.BL.Model;

namespace HCRGUniversity.Core.Data
{
    public interface ITrainingAndSeminarRepository : IBaseRepository<TrainingAndSeminar>
    {
        IEnumerable<BLModel.TrainingAndSeminar> GetAllTrainingAndSeminarByOrganizationID(int OrganizationID, int ClientID);
    }
}
