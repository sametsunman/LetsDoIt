using System;
using System.Collections.Generic;
using System.Text;

namespace LDI.Model
{
    public class UserChannel
    {
        public int ChannelID { get; set; }
        public Channel Channel { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
    }
}
