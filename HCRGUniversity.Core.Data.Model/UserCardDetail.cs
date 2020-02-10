using System;
namespace HCRGUniversity.Core.Data.Model
{
    public class UserCardDetail
    {
        public int UserCardDetailID { get; set; }
        public int UserID { get; set; }
        public string UserCardName { get; set; }
        public string UserCardNumber { get; set; }
        public string UserCardExpiry { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
