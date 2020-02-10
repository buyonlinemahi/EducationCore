using HCRGUniversity.Core.Data;
using Omu.ValueInjecter;
using System.Collections.Generic;
using System.Linq;
using DLModel = HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.BL.Implementation
{
    public class StateImpl :IState
    {
        private readonly IStateRepository _stateRepository;

        public StateImpl(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }
        public IEnumerable<DLModel.State> getAllState()
        {
            IEnumerable<DLModel.State> _state = _stateRepository.GetAll().Select(rk => new DLModel.State().InjectFrom(rk)).Cast<DLModel.State>().OrderBy(rk => rk.StateName).ToList();
            return _state;
        }

        public string getStateByID(int _id)
        {
            return _stateRepository.GetById(_id).StateName;
        }
    }
}
