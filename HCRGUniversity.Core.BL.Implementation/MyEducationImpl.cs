using HCRGUniversity.Core.Data;
using Omu.ValueInjecter;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BLModel = HCRGUniversity.Core.BL.Model;
using DLModel = HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.BL.Implementation
{
    public class MyEducationImpl : IMyEducation
    {
        private readonly IMyEducationRepository _myEducationRepository;
        private readonly IMyEducationModuleRepository _myEducationModuleRepository;
        private readonly IEducationModuleFileRepository _educationModuleFileRepository;

        public MyEducationImpl(IMyEducationRepository myEducationRepository, IMyEducationModuleRepository myEducationModuleRepository, IEducationModuleFileRepository educationModuleFileRepository)
        {
            _myEducationRepository = myEducationRepository;
            _myEducationModuleRepository = myEducationModuleRepository;
            _educationModuleFileRepository = educationModuleFileRepository;
        }

        public int AddMyEducation(DLModel.MyEducation myEducation)
        {
            return _myEducationRepository.Add((DLModel.MyEducation)new DLModel.MyEducation().InjectFrom(myEducation)).MEID;
        }

        public int UpdateMyEducation(DLModel.MyEducation myEducation)
        {
            return _myEducationRepository.Update((DLModel.MyEducation)new DLModel.MyEducation().InjectFrom(myEducation));
        }

        public BLModel.Paged.MyEducation GetMyEducationCompletedByUserIDPaged(int userID,int skip,int take)
        {
            BLModel.Paged.MyEducation _myEducation = new BLModel.Paged.MyEducation
            {
                myeducation = _myEducationRepository.GetMyEducationCompletedByUserIDPaged(userID, skip, take).ToList(),
                TotalCount = _myEducationRepository.GetMyEducationCompletedByUserIDPagedCount(userID)

                //TotalCount = _myEducationRepository.GetMyEducationCountByFilter(hp => (hp.UserID == userID) && ((hp.Completed == true) || hp.Expired == true))
            };
            return _myEducation;
        }
        public BLModel.Paged.MyEducation GetMyEducationInProgressByUserIDPaged(int userID, int skip, int take)
        {
            BLModel.Paged.MyEducation _myEducation = new BLModel.Paged.MyEducation
            {
                myeducation = _myEducationRepository.GetMyEducationInProgressByUserIDPaged(userID, skip, take).ToList(),
                TotalCount = _myEducationRepository.GetMyEducationInProgressByUserIDPagedCount(userID)
                //TotalCount = _myEducationRepository.GetMyEducationCountByFilter(hp => (hp.UserID == userID) && (hp.Completed == false) && (hp.Expired == false || hp.Expired == null))
            };
            return _myEducation;
        }

        public BLModel.Paged.MyEducationAccountHistory GetMyEducationDetailByUserIDPaged(int userID, int skip, int take)
        {
            BLModel.Paged.MyEducationAccountHistory accountHis = new BLModel.Paged.MyEducationAccountHistory
            {
                accounthistory = _myEducationRepository.GetMyEducationDetailByUserIDPaged(userID, skip, take).ToList(),
                TotalCount = _myEducationRepository.GetMyEducationCountByFilterCount(userID)
            };
            return accountHis;
        }
        
        public void UpdateMyEducationExpiredByUserID(int userID)
        {
            _myEducationRepository.UpdateMyEducationExpiredByUserID(userID);
        }

        public void UpdateMyEducationCourseCompletedByMEMID(int MEMID,int MEID)
        {
            DLModel.MyEducationModule myeducationmodule =new DLModel.MyEducationModule{
                MEMID = MEMID,
                Completed = true,
                CompletedDate = System.DateTime.Now
            };
            _myEducationModuleRepository.Update(myeducationmodule, rk => rk.Completed, rk => rk.CompletedDate);
            
            // check if all the module is completed then need to set completed the my education coruse.
            //int meID = _myEducationModuleRepository.GetById(MEMID).MEID;
            if (_myEducationModuleRepository.GetAll(rk => rk.MEID == MEID && rk.Completed == false).Count() == 0)
            {
                // all module completd and need to set course completed 
                DLModel.MyEducation myeducation = new DLModel.MyEducation
                {
                    MEID = MEID,
                    Completed = true,
                    CompletedDate = System.DateTime.Now
                };
                _myEducationRepository.Update(myeducation, rk => rk.Completed, rk => rk.CompletedDate);
            }

        }

        public void UpdateMyEducationForCertificateByMEID(int meid,bool isPrinted,string certificateName)
        {
            DLModel.MyEducation myeducation=new DLModel.MyEducation{
                MEID=meid,
                CertificatePrinted=isPrinted,
                CertificateURL=certificateName
            };
            _myEducationRepository.Update(myeducation, hp => hp.CertificatePrinted, hp => hp.CertificateURL);
        }

        //my educatin moduels mathods...hp
        public void AddEducationModuleToMyEducationByEducationID(int meid, int educationID)
        {
            _myEducationModuleRepository.AddEducationModuleToMyEducationByEducationID(meid, educationID);
        }

        public int UpdateMyEducationModule(DLModel.MyEducationModule myEducationModule)
        {
            var id = _myEducationModuleRepository.Update((DLModel.MyEducationModule)new DLModel.MyEducationModule().InjectFrom(myEducationModule));
            //check if pretest, exam and eval are not required for course then complete course...hp
            Engine.CourseCompleteProcessEngine _engine = new Engine.CourseCompleteProcessEngine();
            _engine.RunEngineAfterModuleCompleted(myEducationModule.MEID);
            return id;
        }
        
        public void UpdateMyEducationModuleTimeLeft(int memID, string TimeLeft)
        {
            _myEducationModuleRepository.UpdateMyEducationModuleTimeLeft(memID, TimeLeft);
        }

        public IEnumerable<DLModel.MyEducationModuleDetail> GetMyEducationModulesDetailsByMEID(int meID, int userID)
        {
          IEnumerable <DLModel.MyEducationModuleDetail> _MyEducationModuleDetail =  _myEducationModuleRepository.GetMyEducationModulesDetailsByMEID(meID, userID).ToList();
            //foreach (DLModel.MyEducationModuleDetail _myEducationModuleDetail in _MyEducationModuleDetail)
            //{
            //    _myEducationModuleDetail.EducationModuleFileDetail = _educationModuleFileRepository.GetAll(me => me.EducationModuleID == _myEducationModuleDetail.EducationModuleID && me.FileTypeID == 4).ToList();
            //}
            return _MyEducationModuleDetail;
        }
        public DLModel.MyEducationModuleDetail GetMyEducationModulesDetailByMEMID(int memID)
        {
            
            return _myEducationModuleRepository.GetMyEducationModulesDetailByMEMID(memID);
        }

        public DLModel.CertificateDetail GetCertificateDetailByMEID(int meID)
        {
            return _myEducationRepository.GetCertificateDetailByMEID(meID);
        }

        public  int GetMyEducationByID(int meID)
        {
            return _myEducationRepository.GetMyEducationByID(meID);
        }
    }
}