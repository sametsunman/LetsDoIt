using LDI.Core;
using System;
using System.ComponentModel;

namespace LDI.Model
{
    public class Base : IEntity
    {
        public int ID { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime? UpdateTime { get; set; }

        public DateTime? DeletedTime { get; set; }

        [DefaultValue(true)]
        public bool IsActive { get; set; }


    }
}
