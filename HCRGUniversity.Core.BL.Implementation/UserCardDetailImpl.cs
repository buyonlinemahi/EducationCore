using HCRGUniversity.Core.Data;
using Omu.ValueInjecter;
using System.Linq;
using BLModel = HCRGUniversity.Core.BL.Model;
using DLModel = HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.BL.Implementation
{
    public class UserCardDetailImpl : IUserCardDetail
    {
        private readonly IUserCardDetailRepository _userCardDetailRepository;
        public UserCardDetailImpl(IUserCardDetailRepository userCardDetailRepository)
        {
            _userCardDetailRepository = userCardDetailRepository;
        }
        public int addUserCardDetail(DLModel.UserCardDetail userCardDetail)
        {
            return _userCardDetailRepository.Add((DLModel.UserCardDetail)new DLModel.UserCardDetail().InjectFrom(userCardDetail)).UserCardDetailID;
        }

        public int updateUserCardDetail(DLModel.UserCardDetail userCardDetail)
        {
            return _userCardDetailRepository.Update((DLModel.UserCardDetail)new DLModel.UserCardDetail().InjectFrom(userCardDetail));
        }

        public DLModel.UserCardDetail getUserCardDetailByID(int id)
        {
            return (DLModel.UserCardDetail)new DLModel.UserCardDetail().InjectFrom(_userCardDetailRepository.GetById(id));
        }

        public BLModel.Paged.UserCardDetail getUserCardDetailByUserID(int userID, int skip, int take)
        {
            return new BLModel.Paged.UserCardDetail
            {
                TotalCount = _userCardDetailRepository.GetAll(rk => rk.UserID == userID).Count(),
                UserCardDetails = _userCardDetailRepository.GetAll(rk => rk.UserID == userID).Skip(skip).Take(take).Select(rk => (DLModel.UserCardDetail)new DLModel.UserCardDetail().InjectFrom(rk)).ToList()
            };
        }
    }
}
