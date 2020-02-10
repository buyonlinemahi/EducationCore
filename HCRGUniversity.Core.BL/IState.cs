using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;

namespace HCRGUniversity.Core.BL
{
    public interface IState
    {
        IEnumerable<State> getAllState();
        string getStateByID(int _id);
    }
}
