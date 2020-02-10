using HCRGUniversity.Core.Data.Model;
using BLModel = HCRGUniversity.Core.BL.Model;


namespace HCRGUniversity.Core.BL
{
    public interface IFaculty
    {
        int AddFaculty(Faculty _faculty);
        int UpdateFaculty(Faculty _faculty);
        BLModel.Paged.Faculties GetAllFaculties(int skip, int take, int organizationID, int ClientID);
        Faculty GetFacultyById(int id);
    }
}