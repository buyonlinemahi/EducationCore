using System.Collections.Generic;
using HCRGUniversity.Core.Data.Model;
namespace HCRGUniversity.Core.BL
{
    public interface INewsPhoto
    {
        int AddNewsPhoto(NewsPhoto newsPhoto);
        int UpdateNewsPhoto(NewsPhoto newsPhoto);
        void DeleteNewsPhoto(int newsPhotoID);
        NewsPhoto GetNewsPhotoByID(int newsPhotoID);
        IEnumerable<NewsPhoto> getAllNewsPhoto();
        IEnumerable<NewsPhoto> getAllNewsPhotoByNewsID(int newsID);
    }
}
