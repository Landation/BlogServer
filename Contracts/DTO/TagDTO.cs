using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts.DTO
{
   public class TagDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Descript { get; set; }

        /// <summary>
        /// 标签的文章数目
        /// </summary>
        public int Count { get; set; }
    }

}
