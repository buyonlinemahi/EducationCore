using HCRGUniversity.Core.BL;
using HCRGUniversity.Core.BL.Implementation;
using HCRGUniversity.Core.Data;
using HCRGUniversity.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CoreBusinessTierTest
{
    [TestClass]
    public class EducationModuleTest
    {
        private IEducationModuleRepository _educationModuleRepository;
        private IEducationModule _educationModuleBL;
        private HCRGUniversity.Core.Data.Model.EducationModule BLModel = new HCRGUniversity.Core.Data.Model.EducationModule();

        private IFileTypeRepository _fileTypeRepository;
        private IFileType _fileTypeBL;
        private HCRGUniversity.Core.Data.Model.FileType BLModelfiletype = new HCRGUniversity.Core.Data.Model.FileType();
        private IEducationModuleFileRepository _educationModuleFileRepository;
        private IEducationModuleFile _educationModuleFileBL;
        private HCRGUniversity.Core.Data.Model.EducationModuleFile BLModelModulfile = new HCRGUniversity.Core.Data.Model.EducationModuleFile();

       



        [TestInitialize]
        public void EducationModuleInitialize()
        {
            _educationModuleRepository = new EducationModuleRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _educationModuleBL = new EducationModuleImpl(_educationModuleRepository);
            _fileTypeRepository = new FileTypeRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _fileTypeBL = new FileTypeImpl(_fileTypeRepository);
            _educationModuleFileRepository = new EducationModuleFileRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _educationModuleFileBL = new EducationModuleFileImpl(_educationModuleFileRepository);
 
        }

        [TestMethod]
        public void AddEducationModule()
        {
            BLModel.EducationID = 559;
            BLModel.EducationModuleName = "test module timer null";
            BLModel.EducationModuleTime = null;
            BLModel.EducationModuleDate = DateTime.Now;
            BLModel.EducationModulePosition = 3;
            BLModel.EducationModuleDescription = "Test desc";
            int result = _educationModuleBL.AddEducationModule(BLModel);
            Assert.IsTrue(result > 0, "Unable to Add");
        }
        [TestMethod]
        public void UpdateEducationModule()
        {
            BLModel.EducationID = 1;
            BLModel.EducationModuleName = "test update dfgd module";
            BLModel.EducationModuleTime = "35";
            BLModel.EducationModuleDescription = "Test desc update";
            BLModel.EducationModuleDate = DateTime.Now;
            BLModel.EducationModuleID = 42;
            int result = _educationModuleBL.UpdateEducationModule(BLModel);
            Assert.IsTrue(result > 0, "Unable to update");
        }

        [TestMethod]
        public void UpdateEducationModuleTime()
        {
            BLModel.EducationModuleTime = "3";
            BLModel.EducationModuleID = 34;
            int result = _educationModuleBL.UpdateEducationModuleTime(BLModel);
            Assert.IsTrue(result > 0, "Unable to update");
        }

        [TestMethod]
        public void DeleteEducationModule()
        {
            _educationModuleBL.DeleteEducationModule(12);
        }

        [TestMethod]
        public void DeleteEducationModuleFileID()
        {
            _educationModuleFileBL.DeleteEducationModuleFileByEducationModuleFileID(669, 4);
        }


        [TestMethod]
        public void getAllEducationModule()
        {
            IEnumerable<HCRGUniversity.Core.Data.Model.EducationModule> educationModule = _educationModuleBL.GetAllEducationModule();
            Assert.IsTrue(_educationModuleBL != null, "Unable to get");
        }

        [TestMethod]
        public void GetOrganizationClientByEducationModuleID()
        {
            var _res = _educationModuleBL.GetOrganizationClientByEducationModuleID(2);
            Assert.IsTrue(_res != null, "Unable to get");
        }

        [TestMethod]
        public void getEducationModuleByID()
        {
            HCRGUniversity.Core.Data.Model.EducationModule educationModule = _educationModuleBL.GetEducationModuleByID(2);
            Assert.IsTrue(_educationModuleBL != null, "Unable to get");
        }

        [TestMethod]
        public void getAllEducationModuleByEducationID()
        {
            IEnumerable<HCRGUniversity.Core.Data.Model.EducationModule> educationModule = _educationModuleBL.GetAllEducationModuleByEducationID(4);
            Assert.IsTrue(_educationModuleBL != null, "Unable to get");
        }


        [TestMethod]
        public void AddEducationModuleFile()
        {
            BLModelModulfile.EducationModuleID = 2;
            BLModelModulfile.ModuleFile = "test module";
            BLModelModulfile.FileTypeID = 1;
            int result = _educationModuleFileBL.AddEducationModuleFile(BLModelModulfile);
            Assert.IsTrue(result > 0, "Unable to Add");
        }
        [TestMethod]
        public void UpdateEducationModuleFile()
        {
            BLModelModulfile.EducationModuleID = 2;
            BLModelModulfile.ModuleFile = "test module update";
            BLModelModulfile.FileTypeID = 1;
            BLModelModulfile.EducationModuleFileID = 1;
            int result = _educationModuleFileBL.UpdateEducationModuleFile(BLModelModulfile);
            Assert.IsTrue(result > 0, "Unable to update");
        }

        [TestMethod]
        public void DeleteEducationModuleFile()
        {
            _educationModuleFileBL.DeleteEducationModuleFile(1);
        }

        [TestMethod]
        public void getAllEducationModuleFile()
        {
            IEnumerable<HCRGUniversity.Core.Data.Model.EducationModuleFile> educationModuleFile = _educationModuleFileBL.GetAllEducationModuleFile();
            Assert.IsTrue(_educationModuleFileBL != null, "Unable to get");
        }
        [TestMethod]
        public void getEducationModuleFileByID()
        {
            HCRGUniversity.Core.Data.Model.EducationModuleFile educationModuleFile = _educationModuleFileBL.GetEducationModuleFileByID(4);
            Assert.IsTrue(_educationModuleFileBL != null, "Unable to get");
        }
               [TestMethod]
        public void getEducationModuleFileByModuleID()
        {
            HCRGUniversity.Core.Data.Model.EducationModuleFile educationModuleFile = _educationModuleFileBL.GetEducationModuleFileByModuleID(795);
            Assert.IsTrue(_educationModuleFileBL != null, "Unable to get");
        }
        
        //Get FileType

        [TestMethod]
        public void getAllFileType()
        {
            IEnumerable<HCRGUniversity.Core.Data.Model.FileType> fileType = _fileTypeBL.GetAllFileType();
            Assert.IsTrue(_educationModuleBL != null, "Unable to get");
        }

        [TestMethod]
        public void GetEducationModuleCountByeid()
        {
            var Edu = _educationModuleBL.GetAllPagedEducationModuleByEid(4, 0, 10);
            Assert.IsTrue(Edu != null, "Unable to find");
        }

        [TestMethod]
        public void GetMyEducationModulesDetailsByMEID_FileTypeID()
        {
            var result = _educationModuleFileBL.GetMyEducationModulesDetailsByMEID_FileTypeID(887, 4);
            Assert.IsTrue(result != null, "Unable to get");
        }

    }
}
