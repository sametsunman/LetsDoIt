using LDI.BusinessLogic.Abstract;
using LDI.DataAccess.Abstract;
using LDI.DataAccess.Concrete;
using LDI.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LDI.BusinessLogic.Concrete
{
    public class MediaManager : IMediaService
    {

        IMediaRepo mediaRepo;

        public MediaManager(IMediaRepo _mediaRepo)
        {

            mediaRepo = _mediaRepo;

        }

        public bool Add(Media data)
        {

            return mediaRepo.Add(data);

        }

        public bool Delete(int id)
        {
            return mediaRepo.Delete(id);
        }

        public Media GetMedia(int id)
        {
            return mediaRepo.Get(x => x.ID == id);
        }

        public ICollection<Media> GetMediaByContent(int contentID)
        {
            return mediaRepo.GetList(x => x.ContentID == contentID);
        }

        public bool Update(Media data)
        {
            return mediaRepo.Update(data);
        }
    }
}
