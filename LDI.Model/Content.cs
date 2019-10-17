using System;
using System.Collections.Generic;
using System.Text;

namespace LDI.Model
{
    public class Content : Base
    {
        public string Title { get; set; }

        public string Description { get; set; }
        
        public double Rating { get; set; }

        public long Views  { get; set; }

        public ICollection<Media> MediaCollection { get; set; }

        public int CategoryID { get; set; }

        public int ChannelID { get; set; }


    }
}
