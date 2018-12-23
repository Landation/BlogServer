using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts.DTO
{
   public class ProjectDTO
    {
        public string Id { get; set; }
        /// <summary>
        /// 项目标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 项目描述
        /// </summary>
        public string Descript { get; set; }

        /// <summary>
        /// 项目图标
        /// </summary>
        public string Icon { get; set; }

        public string View { get; set; }

        /// <summary>
        /// github 地址
        /// </summary>
        public string Github { get; set; }

    }
}
