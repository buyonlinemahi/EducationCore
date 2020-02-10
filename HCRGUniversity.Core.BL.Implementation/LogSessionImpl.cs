using HCRGUniversity.Core.Data;
using Omu.ValueInjecter;
using System;
using System.Linq;
using BLModel = HCRGUniversity.Core.BL.Model;
using DLModel = HCRGUniversity.Core.Data.Model;
namespace HCRGUniversity.Core.BL.Implementation
{
    public class LogSessionImpl : ILogSession
    {
        private readonly ILogSessionRepository _logSessionRepository;
        private readonly IEducationRepository _EducationRepository;
        private readonly IMyEducationRepository _MyEducationRepository;
        private readonly IUserRepository _UserRepository;
        public LogSessionImpl(ILogSessionRepository logSessionRepository, IEducationRepository educationRepository, IMyEducationRepository MyEducationRepository, IUserRepository userRepository)
        {
            _logSessionRepository = logSessionRepository;
            _EducationRepository = educationRepository;
            _MyEducationRepository = MyEducationRepository;
            _UserRepository = userRepository;
        }
        public int AddSession(DLModel.LogSession logSession)
        {
            return _logSessionRepository.Add((DLModel.LogSession)new DLModel.LogSession().InjectFrom(logSession)).UserId;
        }
        public void LogModuleOrExam(string browser, string newurl, int MEID, int UserId)
        {
            string databaseurl = _logSessionRepository.GetAll().Where(b => b.UserId == UserId && b.MEID == MEID && b.Browser == browser).Select(u => u.PageUrl).FirstOrDefault();
            if (databaseurl != newurl)
            {
                _logSessionRepository.Delete(b => b.UserId == UserId && b.MEID == MEID && b.Browser == browser && b.PageUrl == databaseurl);
                DLModel.LogSession _logSession = new DLModel.LogSession
                {
                    MEID = MEID,
                    PageUrl = newurl,
                    Browser = browser,
                    UserId = UserId,
                    SessionId = UserId,
                    LogCreatedDate = System.DateTime.Now
                };
                AddSession(_logSession);
            }
        }
        public bool CheckLogModuleOrExam(int MEID, int UserId)
        {
            return (_logSessionRepository.GetAll().Where(b => b.UserId == UserId && b.MEID == MEID).Count() == 0);
        }
        public void DeleteSession(string browser, int MEID, int UserID)
        {
            _logSessionRepository.Delete(b => b.UserId == UserID && b.MEID == MEID && b.Browser == browser);
        }
        public DLModel.LogSession getLogSessionByUserIDAndMEID(int UserId, int MEID)
        {
            return _logSessionRepository.GetAll().Where(b => b.UserId == UserId && b.MEID == MEID).FirstOrDefault();
        }
        public void DeleteSessionAfterSchedule(int UserID, int LogScheduleTime)
        {
            DateTime dtFrom = System.DateTime.Now.AddHours(-LogScheduleTime);
            _logSessionRepository.Delete(x => x.LogCreatedDate <= dtFrom && x.UserId == UserID);
        }
        public BLModel.Paged.LogSessionDetail getAllLogSession(int skip, int take)
        {
            var _logsession = (from logsession in _logSessionRepository.GetAll()
                               join user in _UserRepository.GetAll()
                               on logsession.UserId equals user.UID
                               join myeducation in _MyEducationRepository.GetAll()
                               on logsession.MEID equals myeducation.MEID
                               join educaton in _EducationRepository.GetAll()
                               on myeducation.EducationID equals educaton.EducationID
                               select new
                               {
                                   logsession.LogSessionID,
                                   logsession.SessionId,
                                   logsession.UserId,
                                   logsession.PageUrl,
                                   logsession.MEID,
                                   logsession.LogCreatedDate,
                                   logsession.Browser,
                                   educaton.CourseName,
                                   user.FirstName,
                                   user.LastName,
                                   user.EmailID
                               }).Skip(skip).Take(take).ToList();
            return new BLModel.Paged.LogSessionDetail
            {
                LogSessionDetails = _logsession.Select(log => new DLModel.LogSessionDetail().InjectFrom(log)).Cast<DLModel.LogSessionDetail>(),
                TotalCount = _logSessionRepository.GetDbSet().Count()
            };
        }
        public BLModel.Paged.LogSessionDetail GetLogSessionByUserName(string username, int skip, int take, int organizationId)
        {
            BLModel.Paged.LogSessionDetail _logSession = new BLModel.Paged.LogSessionDetail
            {
                LogSessionDetails = _logSessionRepository.GetLogSessionByUserName(username, skip, take,organizationId).ToList(),
                TotalCount = _logSessionRepository.GetLogSessionByUserNameCount(username,organizationId)
            };
            return _logSession;
        }
        public void DeleteSessionByAdmin(int LogSessionID)
        {
            _logSessionRepository.Delete(x => x.LogSessionID == LogSessionID);
        }
    }
}
