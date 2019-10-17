using LDI.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LDI.BusinessLogic.Abstract
{
    public interface IChannelService
    {

        bool Add(Channel data);
        bool Update(Channel data);
        bool Delete(int id);

        ICollection<Channel> GetList(Expression<Func<Channel, bool>> filter = null);
        Channel Get(Expression<Func<Channel, bool>> filter);

    }
}
