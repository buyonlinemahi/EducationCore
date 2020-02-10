using System.Collections.Generic;
using HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.BL
{
   public interface INewsVideo
    {
       int AddNewsVideo(NewsVideo newsVideo);
       int UpdateNewsVideo(NewsVideo newsVideo);
       void DeleteNewsVideo(int newsVideoID);
       NewsVideo GetNewsVideoByID(int newsVideoID);
       NewsVideo GetNewsVideoByNewsID(int newsID);
        IEnumerable<NewsVideo> getAllNewsVideo();
    }
}
