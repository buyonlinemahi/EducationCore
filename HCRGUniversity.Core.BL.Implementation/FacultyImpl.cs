using HCRGUniversity.Core.Data;
using HCRGUniversity.Core.Data.Model;
using System.Linq;
using BLModel = HCRGUniversity.Core.BL.Model;

namespace HCRGUniversity.Core.BL.Implementation
{
    public class FacultyImpl : IFaculty
    {
        private readonly IFacultyRepository _facultyRepository;
        private readonly IOrganizationRepository _organizationRepository;
        public FacultyImpl(IFacultyRepository facultyRepository, IOrganizationRepository organizationRepository)
        {
            _facultyRepository = facultyRepository;
            _organizationRepository = organizationRepository;
        }

        public int AddFaculty(Faculty _faculty)
        {
            _faculty.CreatedDate = System.DateTime.Now;
            return _facultyRepository.Add(_faculty).FacultyID;
        }

        public int UpdateFaculty(Faculty _faculty)
        {
            return _facultyRepository.Update(_faculty);
        }

        public BLModel.Paged.Faculties GetAllFaculties(int skip, int take, int organizationID, int ClientID)
        {
            return new BLModel.Paged.Faculties
            {
                FacultyDetails = _facultyRepository.GetAllFacultiesByOrganizationID(skip, take, organizationID, ClientID).ToList(),
                TotalCount = _facultyRepository.GetAllFacultiesByOrganizationIDCount(organizationID, ClientID)
            };
        }

        public Faculty GetFacultyById(int id)
        {
            return _facultyRepository.GetById(id);
        }
    }
}