using LDI.Core;
using LDI.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LDI.DataAccess.Abstract
{
    public interface IContentRepo : IRepository<Content>
    {
        Task<IList<Content>> GetByChannel(int ChannelID);
        Task<IList<Content>> GetByCategory(int CategoryID);
    }
}
