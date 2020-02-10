using HCRGUniversity.Core.Data;
using Omu.ValueInjecter;
using System.Collections.Generic;
using System.Linq;
using DLModel = HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.BL.Implementation
{
    public class NewsVideoImpl : INewsVideo
    {
          private readonly INewsVideoRepository _newsVideoRepository;

          public NewsVideoImpl(INewsVideoRepository newsVideoRepository)
        {
            _newsVideoRepository = newsVideoRepository;

        }

          public int AddNewsVideo(DLModel.NewsVideo newsVideo)
          {
              return _newsVideoRepository.Add((DLModel.NewsVideo)new DLModel.NewsVideo().InjectFrom(newsVideo)).NewsVideoID;
          }

          public int UpdateNewsVideo(DLModel.NewsVideo newsVideo)
          {
              return _newsVideoRepository.Update((DLModel.NewsVideo)new DLModel.NewsVideo().InjectFrom(newsVideo));
          }

          public void DeleteNewsVideo(int newsVideoID)
          {
              _newsVideoRepository.Delete(_newsVideoRepository.GetById(newsVideoID));
          }

          public DLModel.NewsVideo GetNewsVideoByID(int newsVideoID)
          {
              return (DLModel.NewsVideo)new DLModel.NewsVideo().InjectFrom(_newsVideoRepository.GetById(newsVideoID));
          }

          public IEnumerable<DLModel.NewsVideo> getAllNewsVideo()
          {
              IEnumerable<DLModel.NewsVideo> _newsVideo = _newsVideoRepository.GetAll().Select(newsVideo => new DLModel.NewsVideo().InjectFrom(newsVideo)).Cast<DLModel.NewsVideo>().OrderBy(newsVideo => newsVideo.NewsVideoID).ToList();
              return _newsVideo;
          }

          public DLModel.NewsVideo GetNewsVideoByNewsID(int newsID)
          {
              return (DLModel.NewsVideo)new DLModel.NewsVideo().InjectFrom(_newsVideoRepository.GetAll(newsVideo => newsVideo.NewsID == newsID).FirstOrDefault());
          }
    }
}
