using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts.DTO
{
    
    public class CommentDTO
    {
        public string Id { get; set; }
        public string PostId { get; set; }
        public int Pid { get; set; } = 0;
        public string Content { get; set; }
        public int Likes { get; set; } = 0;
        public AuthorInfo Author { get; set; }
    }
}
