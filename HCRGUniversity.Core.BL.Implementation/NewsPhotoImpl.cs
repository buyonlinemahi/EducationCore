using HCRGUniversity.Core.Data;
using Omu.ValueInjecter;
using System.Collections.Generic;
using System.Linq;
using DLModel = HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.BL.Implementation
{
    public class NewsPhotoImpl : INewsPhoto
    {
         private readonly INewsPhotoRepository _newsPhotoRepository;

          public NewsPhotoImpl(INewsPhotoRepository newsPhotoRepository)
        {
            _newsPhotoRepository = newsPhotoRepository;

        }

          public int AddNewsPhoto(DLModel.NewsPhoto newsPhoto)
          {
              return _newsPhotoRepository.Add((DLModel.NewsPhoto)new DLModel.NewsPhoto().InjectFrom(newsPhoto)).NewsPhotoID;
          }

          public int UpdateNewsPhoto(DLModel.NewsPhoto newsPhoto)
          {
              return _newsPhotoRepository.Update((DLModel.NewsPhoto)new DLModel.NewsPhoto().InjectFrom(newsPhoto));
          }

          public void DeleteNewsPhoto(int newsPhotoID)
          {
              _newsPhotoRepository.Delete(_newsPhotoRepository.GetById(newsPhotoID));
          }

          public DLModel.NewsPhoto GetNewsPhotoByID(int newsPhotoID)
          {
              return (DLModel.NewsPhoto)new DLModel.NewsPhoto().InjectFrom(_newsPhotoRepository.GetById(newsPhotoID));
          }

          public IEnumerable<DLModel.NewsPhoto> getAllNewsPhoto()
          {
              IEnumerable<DLModel.NewsPhoto> _newsPhoto = _newsPhotoRepository.GetAll().Select(newsPhoto => new DLModel.NewsPhoto().InjectFrom(newsPhoto)).Cast<DLModel.NewsPhoto>().OrderBy(newsPhoto => newsPhoto.NewsPhotoID).ToList();
              return _newsPhoto;
          }
          public IEnumerable<DLModel.NewsPhoto> getAllNewsPhotoByNewsID(int newsID)
          {
              IEnumerable<DLModel.NewsPhoto> _newsPhoto = _newsPhotoRepository.GetAll(newsPhoto => newsPhoto.NewsID == newsID).Select(newsPhoto => new DLModel.NewsPhoto().InjectFrom(newsPhoto)).Cast<DLModel.NewsPhoto>().OrderBy(newsPhoto => newsPhoto.NewsPhotoID).ToList();
              return _newsPhoto;
          }
    }
}
