using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{

   public class Project:IEntity
    {
        /// <summary>
        /// 项目标题
        /// </summary>
        //[BsonElement("title")]
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

        /// <summary>
        /// 项目发布时间
        /// </summary>
        public DateTime CreateAt { get; set; } = DateTime.Now;

        /// <summary>
        /// 项目最后修改时间
        /// </summary>
        public DateTime UpdateAt { get; set; }= DateTime.Now;
    }
}
