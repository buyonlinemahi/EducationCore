using Core.Base.Data;
using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;
using BLModel = HCRGUniversity.Core.BL.Model;

namespace HCRGUniversity.Core.Data
{
    public interface INewsLetterRepository : IBaseRepository<NewsLetter>
    {
        IEnumerable<BLModel.NewsLetter> GetNewsLetterByClientID(int clientID, int orgID);
    }
}
