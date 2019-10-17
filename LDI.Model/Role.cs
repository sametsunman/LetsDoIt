using System;
using System.Collections.Generic;
using System.Text;

namespace LDI.Model
{
    public class Role : Base
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public IList<UserRole> UserRoles { get; set; }
    }
}
