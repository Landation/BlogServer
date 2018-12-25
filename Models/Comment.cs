using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Comment : IEntity
    {
        /// <summary>
        /// 评论文章的ID
        /// </summary>
        public string PostId{ get; set; }

        /// <summary>
        /// 0 代表默认留言
        /// </summary>
        public int Pid { get; set; } = 0;
        public string Content { get; set; }
        public int Likes { get; set; } = 0;
        public RemoteInfo Remote { get; set; }
        public AuthorInfo Author { get; set; } = new AuthorInfo();

    }
}
