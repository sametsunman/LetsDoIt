using LDI.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LDI.Model
{
    public class Media : Base
    {
        public MediaType Type { get; set; }

        public string Path { get; set; }

        [DataType(DataType.Duration)]
        public DateTime Duration { get; set; }

        public int ContentID { get; set; }

    }
}
