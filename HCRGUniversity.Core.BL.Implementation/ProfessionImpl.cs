using HCRGUniversity.Core.Data;
using Omu.ValueInjecter;
using System.Collections.Generic;
using System.Linq;
using BLModel = HCRGUniversity.Core.BL.Model;
using DLModel = HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.BL.Implementation
{
    public class ProfessionImpl : IProfession
    {
        private readonly IProfessionRepository _professionRepository;
        private readonly IOrganizationRepository _organizationRepository;
        public ProfessionImpl(IProfessionRepository professionRepository, IOrganizationRepository organizationRepository)
        {
            _professionRepository = professionRepository;
            _organizationRepository= organizationRepository;
        }
        public int AddProfession(DLModel.Profession profession)
        {
            return _professionRepository.Add(profession).ProfessionID;
        }

        public int UpdateProfession(DLModel.Profession profession)
        {
            return _professionRepository.Update(profession);
        }

        public DLModel.Profession GetProfessionByID(int professionID)
        {
            return _professionRepository.GetById(professionID);
        }

        public IEnumerable<DLModel.Profession> getAllProfession(int _clientID)
        {
            return _professionRepository.GetAllProfessionByClientID(_clientID);
        }

        public IEnumerable<DLModel.Profession> getAllProfessionActive(int _clientID)
        {
            return _professionRepository.GetAllProfessionByClientID(_clientID).Where(rk => rk.IsActive == true);
        }

        public IEnumerable<DLModel.Profession> GetProfessionsByCollegeID(int collegeID)
        {
            IEnumerable<DLModel.Profession> _profession = _professionRepository.GetProfessionsByCollegeID(collegeID).OrderBy(profession => profession.ProfessionTitle).ToList();
            return _profession;
        }

        public IEnumerable<DLModel.Profession> GetProfessionNotAssociateWithEducation(int educationID)
        {
            IEnumerable<DLModel.Profession> _profession = _professionRepository.GetProfessionNotAssociateWithEducation(educationID).OrderBy(profession => profession.ProfessionTitle).ToList();
            return _profession;
        }

        //*******************Lazy binding
        public BLModel.Paged.Profession GetAllPagedProfession(int skip, int take, int _clientID)
        {
            return new BLModel.Paged.Profession
            {
                TotalCount = _professionRepository.GetAllPagedProfessionByClientIDCount(_clientID),
                Professions = _professionRepository.GetAllPagedProfessionByClientID(skip, take, _clientID).ToList()
            };
        }

        public IEnumerable<DLModel.Profession> GetAllProfessionWeb(int OrganizationID)
        {

            if (_organizationRepository.GetById(OrganizationID).IsOrganizationAdmin)
                return _professionRepository.GetAll().Select(college => new DLModel.Profession().InjectFrom(college)).Cast<DLModel.Profession>().OrderBy(pro => pro.ProfessionID).ToList();
            else
                return _professionRepository.GetAllProfessionWeb(OrganizationID).Select(college => new DLModel.Profession().InjectFrom(college)).Cast<DLModel.Profession>().OrderBy(college => college.ProfessionID).ToList();
        }

        public IEnumerable<DLModel.Profession> GetAllProfessionWebActiveWeb(int OrganizationID)
        {
            if (_organizationRepository.GetById(OrganizationID).IsOrganizationAdmin)
                return _professionRepository.GetAll(rk => rk.IsActive == true).Select(college => new DLModel.Profession().InjectFrom(college)).Cast<DLModel.Profession>().OrderBy(college => college.ProfessionID).ToList();
            else
                return _professionRepository.GetAllProfessionWeb(OrganizationID).Where(rk => rk.IsActive == true).Select(college => new DLModel.Profession().InjectFrom(college)).Cast<DLModel.Profession>().OrderBy(college => college.ProfessionID).ToList();

        }
        public BLModel.Paged.Profession GetAllPagedProfessionByOrganizationID(int skip, int take, int organizationID)
        {
            return new BLModel.Paged.Profession
            {
                TotalCount = _professionRepository.GetAllPagedProfessionByOrganizationIDCount(organizationID),
                Professions = _professionRepository.GetAllPagedProfessionByOrganizationID(skip, take, organizationID).ToList()
            };
        }
    }
}