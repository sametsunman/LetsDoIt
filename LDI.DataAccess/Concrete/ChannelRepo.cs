using LDI.Core;
using LDI.DataAccess.Abstract;
using LDI.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LDI.DataAccess.Concrete
{
    public class ChannelRepo : BaseRepo<Channel>, IChannelRepo
    {
        public ChannelRepo(Context context) : base(context)
        {
        }
    }
}
