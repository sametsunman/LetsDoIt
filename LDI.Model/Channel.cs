using System;
using System.Collections.Generic;
using System.Text;

namespace LDI.Model
{
    public class Channel : Base
    {

        public string Name { get; set; }
    
        public string Description { get; set; }

        public string ImagePath { get; set; }

        public int AuthorID { get; set; }

        public IList<UserChannel> UserChannels { get; set; }


    }
}
