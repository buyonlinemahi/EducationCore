using HCRGUniversity.Core.Data;
using Omu.ValueInjecter;
using System.Collections.Generic;
using System.Linq;
using DLModel = HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.BL.Implementation
{
    public class ClientTypeImpl :IClientType
    {
        private readonly IClientTypeRepository _clientTypeRepository;

        public ClientTypeImpl(IClientTypeRepository clientTypeRepository)
        {
            _clientTypeRepository = clientTypeRepository;
        }
        public IEnumerable<DLModel.ClientType> getAllClientType()
        {
            return _clientTypeRepository.GetAll().Select(rk => new DLModel.ClientType().InjectFrom(rk)).Cast<DLModel.ClientType>().OrderBy(rk => rk.ClientTypeName).ToList();
        }
    }
}
