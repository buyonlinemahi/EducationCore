using Core.Base.Data;
using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;

namespace HCRGUniversity.Core.Data
{
    public interface IProfessionRepository : IBaseRepository<Profession>
    {
        IEnumerable<Profession> GetProfessionsByCollegeID(int collegeID);
        IEnumerable<Profession> GetProfessionNotAssociateWithEducation(int educationID);
        IEnumerable<Profession> GetAllProfessionByClientID(int clientID);
        IEnumerable<HCRGUniversity.Core.BL.Model.Profession> GetAllPagedProfessionByClientID(int skip, int take, int clientID);
        int GetAllPagedProfessionByClientIDCount(int clientID);
        IEnumerable<Profession> GetAllProfessionWeb(int OrganizationID);

        IEnumerable<HCRGUniversity.Core.BL.Model.Profession> GetAllPagedProfessionByOrganizationID(int skip, int take, int organizationID);
        int GetAllPagedProfessionByOrganizationIDCount(int organizationID);
    }
}