using System;


namespace HCRGUniversity.Core.Data.Model
{
    public class Order
    {
        public int OrderID { get; set; }
        public string OrderNumber { get; set; }
        public int UserID { get; set; }
        public DateTime  OrderDate { get; set; }
       
    }
}
