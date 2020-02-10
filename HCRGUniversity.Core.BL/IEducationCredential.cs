using System.Collections.Generic;
using HCRGUniversity.Core.Data.Model;
using BLModel = HCRGUniversity.Core.BL.Model;

namespace HCRGUniversity.Core.BL
{
    public interface IEducationCredential
    {
        //----Accreditor
        int AddAccreditor(Accreditor accreditor);
        int UpdateAccreditor(Accreditor accreditor);
        void DeleteAccreditor(int accreditorID,bool isActive);
        IEnumerable<Accreditor> getAll();
        BLModel.Paged.Accreditor GetAllPagedAccreditor(int skip, int take);
        IEnumerable<BLModel.Accreditor> GetAllAccreditorsByOrganizationID(int clientID,int orgID);

        //--EducationCredential
        int AddEducationCredential(EducationCredential educationCredential);
        int UpdateEducationCredential(EducationCredential educationCredential);
        void DeleteEducationCredential(int _credentialID, bool isActive);
        EducationCredential GetEducationCredentialByID(int _credentialID);
        IEnumerable<EducationCredential> GetEducationCredentialByEducationID(int _educationID);
        IEnumerable<BLModel.EducationCredential> GetEducationCredentialDetailByEducationID(int _educationID);
    }
}
