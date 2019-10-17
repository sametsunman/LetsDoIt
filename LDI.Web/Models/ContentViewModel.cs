using LDI.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LDI.Web.Models
{
    public class ContentViewModel
    {

        public string Title { get; set; }

        public string Description { get; set; }

        public double Rating { get; set; }

        public long Views { get; set; }

        public string Category { get; set; }

        public string Channel { get; set; }

        public MediaType Type { get; set; }

        public string Path { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime Duration { get; set; }




    }
}
