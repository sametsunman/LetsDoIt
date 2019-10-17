using LDI.BusinessLogic.Abstract;
using LDI.DataAccess.Abstract;
using LDI.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LDI.BusinessLogic.Concrete
{
    public class ContentManager : IContentService
    {

        IContentRepo contentRepo;

        public ContentManager(IContentRepo _contentRepo)
        {
            contentRepo = _contentRepo;
        }

        public bool Add(Content data)
        {
            return contentRepo.Add(data);
        }

        public bool Delete(int id)
        {
            return contentRepo.Delete(id);
        }

        public Content GetContent(int id)
        {
            return contentRepo.Get(x => x.ID==id);
        }

        public IList<Content> GetByChannel(int channelId)
        {
            return contentRepo.GetByChannel(channelId).Result;
        }

        public bool Update(Content data)
        {
            return contentRepo.Update(data);
        }

        public IList<Content> GetByCategory(int categoryId)
        {
            return contentRepo.GetByCategory(categoryId).Result;
        }
    }
}
