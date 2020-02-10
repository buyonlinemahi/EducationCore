using HCRGUniversity.Core.Data;
using Omu.ValueInjecter;
using System.Collections.Generic;
using System.Linq;
using BLModel = HCRGUniversity.Core.BL.Model;
using DLModel = HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.BL.Implementation
{
    public class EducationModuleImpl : IEducationModule
    {
        private readonly IEducationModuleRepository _educationModuleRepository;

        public EducationModuleImpl(IEducationModuleRepository educationModuleRepository)
        {
            _educationModuleRepository = educationModuleRepository;

        }
        public int AddEducationModule(DLModel.EducationModule educationModule)
        {
            return _educationModuleRepository.AddEducationModule(educationModule);

        }

        public int UpdateEducationModule(DLModel.EducationModule educationModule)
        {
            return _educationModuleRepository.UpdateEducationModule(educationModule);
        }

        public int UpdateEducationModuleTime(DLModel.EducationModule educationModule)
        {
            return _educationModuleRepository.UpdateEducationModuleTime(educationModule);
        }

        public void DeleteEducationModule(int educationModuleID)
        {
            _educationModuleRepository.DeleteEducationModule(educationModuleID);
        }

        public DLModel.EducationModule GetEducationModuleByID(int educationModuleID)
        {
            return (DLModel.EducationModule)new DLModel.EducationModule().InjectFrom(_educationModuleRepository.GetById(educationModuleID));
        }

        public IEnumerable<DLModel.EducationModule> GetAllEducationModule()
        {
            IEnumerable<DLModel.EducationModule> _educationModule = _educationModuleRepository.GetAll().Select(educationModule => new DLModel.EducationModule().InjectFrom(educationModule)).Cast<DLModel.EducationModule>().OrderBy(educationModule => educationModule.EducationModuleID).ToList();
            return _educationModule;
        }

        public IEnumerable<DLModel.EducationModule> GetAllEducationModuleByEducationID(int educationID)
        {
            IEnumerable<DLModel.EducationModule> _educationModule = _educationModuleRepository.GetAll(educationModule => educationModule.EducationID == educationID).Select(educationModule => new DLModel.EducationModule().InjectFrom(educationModule)).Cast<DLModel.EducationModule>().OrderBy(educationModule => educationModule.EducationModulePosition).ToList();
            return _educationModule;
        }

        public BLModel.Paged.EducationModule GetAllPagedEducationModuleByEid(int educationID, int skip, int take)
        {
            return new BLModel.Paged.EducationModule
            {
                TotalCount = _educationModuleRepository.GetEducationModuleCountByeid(education => (education.EducationID.Equals(educationID))),
                EducationModules = _educationModuleRepository.GetAllPagedEducationModuleByEid(educationID, skip, take).ToList()
            };
        }

        public DLModel.Client GetOrganizationClientByEducationModuleID(int educationModuleID)
        {
            return _educationModuleRepository.GetOrganizationClientByEducationModuleID(educationModuleID);
        }

    }
}
