using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
   public class Tag:IEntity
    {
        public string Name { get; set; }
        public string Descript { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; } = DateTime.Now;
        public int Sort { get; set; } = 0;
    }
}
