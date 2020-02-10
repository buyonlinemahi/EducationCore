using DLModel= HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;
using BLModel = HCRGUniversity.Core.BL.Model;
namespace HCRGUniversity.Core.BL
{
    public interface IProfession
    {
        int AddProfession(DLModel.Profession profession);
        int UpdateProfession(DLModel.Profession profession);
        DLModel.Profession GetProfessionByID(int professionID);
        IEnumerable<DLModel.Profession> getAllProfession(int _clientID);
        IEnumerable<DLModel.Profession> getAllProfessionActive(int _clientID);
        IEnumerable<DLModel.Profession> GetProfessionsByCollegeID(int collegeID);
        IEnumerable<DLModel.Profession> GetProfessionNotAssociateWithEducation(int educationID);
        BLModel.Paged.Profession GetAllPagedProfession(int skip, int take, int _clientID);
        IEnumerable<DLModel.Profession> GetAllProfessionWeb(int OrganizationID);
        IEnumerable<DLModel.Profession> GetAllProfessionWebActiveWeb(int OrganizationID);
        BLModel.Paged.Profession GetAllPagedProfessionByOrganizationID(int skip, int take, int organizationID);
    }
}