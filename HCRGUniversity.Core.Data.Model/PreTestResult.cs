
namespace HCRGUniversity.Core.Data.Model
{
    public class PreTestResult
    {
        public int PreTestResultID { get; set; }
        public int UID { get; set; }
        public bool IsPass { get; set; }
        public int MEID { get; set; }
        public int? PreTestID { get; set; }
    }
}
