using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts.DTO
{
   public class HeroDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public AuthorInfo Author { get; set; } = new AuthorInfo();
    }
}
