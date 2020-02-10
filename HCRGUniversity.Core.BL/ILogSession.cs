using HCRGUniversity.Core.Data.Model;
using BLModel = HCRGUniversity.Core.BL.Model;
namespace HCRGUniversity.Core.BL
{
    public interface ILogSession
    {
        int AddSession(LogSession aboutus);
        void LogModuleOrExam(string browser, string newurl, int MEID, int UserId);
        bool CheckLogModuleOrExam(int MEID, int UserId);
        void DeleteSession(string browser, int MEID, int UserID);
        void DeleteSessionAfterSchedule(int UserID, int LogScheduleTime);
        LogSession getLogSessionByUserIDAndMEID(int UserId, int MEID);
        void DeleteSessionByAdmin(int LogSessionID);
        BLModel.Paged.LogSessionDetail GetLogSessionByUserName(string username, int skip, int take, int organizationId);
        BLModel.Paged.LogSessionDetail getAllLogSession(int skip, int take);
    }
}
