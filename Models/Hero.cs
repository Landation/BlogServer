using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Hero : IEntity
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public AuthorInfo Author { get; set; } = new AuthorInfo();
        /// <summary>
        /// 状态  0 待审核，1 审核通过， 2 审核不通过
        /// </summary>
        public int State { get; set; } = 1;
        public RemoteInfo Remote { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;

    }
}
