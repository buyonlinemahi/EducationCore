using System.Collections.Generic;
using HCRGUniversity.Core.Data.Model;
using BLModel = HCRGUniversity.Core.BL.Model;

namespace HCRGUniversity.Core.BL
{
    public interface IMyEducation
    {
        //my educatin mathods...hp
        int AddMyEducation(MyEducation myEducation);
        int UpdateMyEducation(MyEducation myEducation);
        BLModel.Paged.MyEducation GetMyEducationCompletedByUserIDPaged(int userID, int skip, int take);
        BLModel.Paged.MyEducation GetMyEducationInProgressByUserIDPaged(int userID, int skip, int take);
        BLModel.Paged.MyEducationAccountHistory GetMyEducationDetailByUserIDPaged(int userID, int skip, int take);
        void UpdateMyEducationExpiredByUserID(int userID);
        void UpdateMyEducationCourseCompletedByMEMID(int MEMID, int MEID);
        void UpdateMyEducationForCertificateByMEID(int meid,bool isPrinted,string certificateName);
        
        //my educatin moduels mathods...hp
        void AddEducationModuleToMyEducationByEducationID(int meid, int educationID);
        int UpdateMyEducationModule(MyEducationModule myEducationModule);
        IEnumerable<MyEducationModuleDetail> GetMyEducationModulesDetailsByMEID(int meID, int userID);
        MyEducationModuleDetail GetMyEducationModulesDetailByMEMID(int memID);
        void UpdateMyEducationModuleTimeLeft(int memID, string TimeLeft);
        CertificateDetail GetCertificateDetailByMEID(int meID);

        int GetMyEducationByID(int meID);
    }
}