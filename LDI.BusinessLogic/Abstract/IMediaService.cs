using LDI.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LDI.BusinessLogic.Abstract
{
    public interface IMediaService
    {

        bool Add(Media data);
        bool Delete(int id);
        ICollection<Media> GetMediaByContent(int lectureId);
        bool Update(Media data);
        Media GetMedia(int id);

    }
}
