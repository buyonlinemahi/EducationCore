using Core.Base.Data;
using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;

namespace HCRGUniversity.Core.Data
{
    public interface IEducationFormatRepository : IBaseRepository<EducationFormat>
    {
        IEnumerable<EducationFormat> GetEducationFormatNotAssociateWithEducation(int educationID);
        IEnumerable<EducationFormat> GetAllPagedEducationFormat(int skip, int take);
        int GetEducationFormatCount();
        IEnumerable<HCRGUniversity.Core.BL.Model.EducationFormat> GetEducationFormatByClientID(int ClientID);
        IEnumerable<HCRGUniversity.Core.BL.Model.EducationFormat> GetAllEducationFormatByOrganizationID(int _organizationID);
        IEnumerable<HCRGUniversity.Core.BL.Model.EducationFormat> GetAllEducationFormatByClientID(int ClientID);
    }
}