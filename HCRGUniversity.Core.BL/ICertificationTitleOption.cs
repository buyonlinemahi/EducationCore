using System.Collections.Generic;
using BLModel = HCRGUniversity.Core.BL.Model;
using DLModel = HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.BL
{
    public interface ICertificationTitleOption
    {
        int AddCertificationTitleOption(DLModel.CertificationTitleOption _certificationTitleOption);
        int  UpdateCertificationTitleOption(DLModel.CertificationTitleOption _certificationTitleOption);
        DLModel.CertificationTitleOption GetCertificationTitleOptionsByID(int CertificationTitleOptionID);
        DLModel.CertificationTitleOption GetCertificationTitleOptionsByEducationID(int _educationID);
        void DeleteCertificationTitleOption(int id);
        IEnumerable<DLModel.CourseNameDropDownList> GetCourseDropDownList(int organizationID);
        BLModel.Paged.CertificationTitleOption GetPagedCertificationTitleOption(int skip, int take);
        IEnumerable<DLModel.CertificationTitleOption> GetCertificationTitleOptionsByALL();
    }
}
