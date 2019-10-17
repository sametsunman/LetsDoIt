using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LDI.Model
{
    public class Category : Base
    {

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public int? ParentID { get; set; }

        public bool IsLeaf { get; set; }
    }
}
