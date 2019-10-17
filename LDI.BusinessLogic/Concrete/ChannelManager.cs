using LDI.BusinessLogic.Abstract;
using LDI.DataAccess.Abstract;
using LDI.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace LDI.BusinessLogic.Concrete
{
    public class ChannelManager : IChannelService
    {

        IChannelRepo channelRepo;

        public ChannelManager(IChannelRepo _channelRepo)
        {
            channelRepo = _channelRepo;
        }

        public bool Add(Channel data)
        {
            return channelRepo.Add(data);
        }

        public bool Delete(int id)
        {
            return channelRepo.Delete(id);
        }

        public Channel Get(Expression<Func<Channel, bool>> filter)
        {
            return channelRepo.Get(filter);
        }

        public ICollection<Channel> GetList(Expression<Func<Channel, bool>> filter = null)
        {
            return channelRepo.GetList(filter);
        }

        public bool Update(Channel data)
        {
            return channelRepo.Update(data);
        }
    }
}
