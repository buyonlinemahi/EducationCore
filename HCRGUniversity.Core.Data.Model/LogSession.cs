using System;
namespace HCRGUniversity.Core.Data.Model
{
    public class LogSession
    {
        public int LogSessionID { get; set; }
        public int SessionId { get; set; }
        public int UserId { get; set; }
        public string PageUrl { get; set; }
        public string Browser { get; set; }
        public int MEID { get; set; }
        public DateTime LogCreatedDate { get; set; }
    }
}
