using HCRGUniversity.Core.BL.Model.Base;
using System.Collections.Generic;
using BLModel = HCRGUniversity.Core.BL.Model;
namespace HCRGUniversity.Core.BL.Model.Paged
{
    public class Client
    {

        public IEnumerable<BLModel.Client> Clients { get; set; }
        public int TotalCount { get; set; }
    }
}
