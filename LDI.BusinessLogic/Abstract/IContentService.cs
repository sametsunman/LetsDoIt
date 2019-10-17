using LDI.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LDI.BusinessLogic.Abstract
{
    public interface IContentService
    {

        bool Add(Content data);
        bool Update(Content data);
        bool Delete(int id);
        IList<Content> GetByChannel(int channelId);
        IList<Content> GetByCategory(int categoryId);
        Content GetContent(int id);

    }
}
