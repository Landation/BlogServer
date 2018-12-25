using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{

    public class Reply : IEntity
    {
        public string PostId { get; set; }
        public string Cid { get; set; }
        public AuthorInfo From { get; set; }
        public AuthorInfo To { get; set; }
        public string Content { get; set; }
        public string Likes { get; set; }

        public RemoteInfo Remote { get; set; }

        /// <summary>
        /// 状态 0待审核 1通过正常 2不通过
        /// </summary>
        public int State { get; set; } = 1;
        public DateTime CreateAt = DateTime.Now;
        public DateTime UpdateAt = DateTime.Now;


    }
}
