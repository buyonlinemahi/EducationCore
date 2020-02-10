using HCRGUniversity.Core.Data;
using Omu.ValueInjecter;
using System.Collections.Generic;
using System.Linq;
using BLModel = HCRGUniversity.Core.BL.Model;
using DLModel = HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.BL.Implementation
{
    public class CollegeImpl : ICollege
    {
        private readonly ICollegeRepository _collegeRepository;
        private readonly IOrganizationRepository _organizationRepository;
        public CollegeImpl(ICollegeRepository collegeRepository, IOrganizationRepository organizationRepository)
        {
            _collegeRepository = collegeRepository;
            _organizationRepository = organizationRepository;
        }
        public int AddCollege(BLModel.College college)
        {
            return _collegeRepository.Add((DLModel.College)new DLModel.College().InjectFrom(college)).CollegeID;
        }

        public int UpdateCollege(BLModel.College college)
        {
            return _collegeRepository.Update((DLModel.College)new DLModel.College().InjectFrom(college));
        }

        public void DeleteCollege(int collegeID, bool IsActive)
        {
            DLModel.College _clg = new DLModel.College
            {
                CollegeID = collegeID,
                CollegeName = "",
                Abbreviation = "",
                StartNumber = "",
                IsActive = IsActive
            };
            _collegeRepository.Update(_clg, hp => hp.IsActive);
        }

        public BLModel.College GetCollageByID(int collegeID)
        {
            return (BLModel.College)new BLModel.College().InjectFrom(_collegeRepository.GetById(collegeID));
        }

        public IEnumerable<BLModel.College> getAllCollege(int ClientID)
        {
            //IEnumerable<BLModel.College> _college = _collegeRepository.GetAll().Select(college => new BLModel.College().InjectFrom(college)).Cast<BLModel.College>().OrderBy(college => college.CollegeID).ToList();
            return _collegeRepository.GetAllCollegeByClientID(ClientID);
        }
        public IEnumerable<BLModel.College> getAllCollegeActive(int ClientID)
        {
            //return _collegeRepository.GetAll(hp => hp.IsActive != false).Select(college => new BLModel.College().InjectFrom(college)).Cast<BLModel.College>().OrderBy(college => college.CollegeID).ToList();

            return _collegeRepository.GetAllCollegeByClientID(ClientID).Where(rk => rk.IsActive == true).Select(college => new BLModel.College().InjectFrom(college)).Cast<BLModel.College>().OrderBy(college => college.CollegeID).ToList();
        }

        //*******************Lazy binding
        public BLModel.Paged.College GetAllPagedCollege(int skip, int take, int ClientID)
        {
            return new BLModel.Paged.College
            {
                TotalCount = _collegeRepository.GetAllCollegeByClientID(ClientID).Count(),
                Colleges = _collegeRepository.GetAllCollegeByClientID(ClientID).Select(college => (BLModel.College)new BLModel.College().InjectFrom(college)).ToList()
            };
        }


        public IEnumerable<BLModel.College> GetAllCollegeWeb(int OrganizationID)
        {

            if(_organizationRepository.GetById(OrganizationID).IsOrganizationAdmin) 
                return _collegeRepository.GetAll().Select(college => new BLModel.College().InjectFrom(college)).Cast<BLModel.College>().OrderBy(college => college.CollegeID).ToList();
            else
                return _collegeRepository.GetAllCollegeWeb(OrganizationID).Select(college => new BLModel.College().InjectFrom(college)).Cast<BLModel.College>().OrderBy(college => college.CollegeID).ToList();
        }

        public IEnumerable<BLModel.College> GetAllCollegeActiveWeb(int OrganizationID)
        {
            if (_organizationRepository.GetById(OrganizationID).IsOrganizationAdmin)
                return _collegeRepository.GetAll(rk => rk.IsActive == true).Select(college => new BLModel.College().InjectFrom(college)).Cast<BLModel.College>().OrderBy(college => college.CollegeID).ToList();
            else
                return _collegeRepository.GetAllCollegeWeb(OrganizationID).Where(rk => rk.IsActive == true).Select(college => new BLModel.College().InjectFrom(college)).Cast<BLModel.College>().OrderBy(college => college.CollegeID).ToList();
            
        }
        public IEnumerable<BLModel.College> GetAllCollegeByOrganizationID(int _organizationID)
        {
            return _collegeRepository.GetAllCollegeByOrganizationID(_organizationID).ToList();
        }

    }
}