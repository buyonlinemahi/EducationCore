using System.Collections.Generic;
using HCRGUniversity.Core.Data.Model;
using BLModel = HCRGUniversity.Core.BL.Model;
namespace HCRGUniversity.Core.BL
{
    public interface IEducationFormat
    {
        int AddEducationFormat(EducationFormat educationFormat);
        int UpdateEducationFormat(EducationFormat educationFormat);
        IEnumerable<EducationFormat> getAllEducationFormat(int _organizationID);
        IEnumerable<BLModel.EducationFormat> GetEducationFormatByClientID(int ClientID);
        IEnumerable<EducationFormat> GetEducationFormatNotAssociateWithEducation(int educationID);
        BLModel.Paged.EducationFormat GetAllPagedEducationFormat(int skip, int take);
        IEnumerable<BLModel.EducationFormat> GetAllEducationFormatByClientID(int ClientID);
        IEnumerable<BLModel.EducationFormat> GetAllEducationFormatByOrganizationID(int _organizationID);
    }
}