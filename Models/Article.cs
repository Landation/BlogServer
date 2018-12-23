using System;

namespace Models
{
    public class Article:IEntity
    {

        /// <summary>
        /// 文章标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 关键字
        /// </summary>
        public string Keyword { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Descript { get; set; }

        /// <summary>
        /// 标签
        /// </summary>
        public string Tag { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 编辑内容
        /// </summary>
        public string EditContent { get; set; }

        /// <summary>
        /// 状态 1 发布  2草稿
        /// </summary>
        public int State { get; set; } = 1;

        /// <summary>
        /// 文章公开状态 1 公开 2 私密
        /// </summary>
        public int Publish { get; set; } = 1;

        /// <summary>
        /// 缩略图
        /// </summary>
        public string Thumb { get; set; }

        /// <summary>
        /// 文章分类
        /// 1 文章 2 代码 3民谣
        /// </summary>
        public int Type { get; set; } = 1;

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateAt { get; set; } = DateTime.Now;

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime UpdateAt { get; set; } = DateTime.Now;

        /// <summary>
        /// 其他信息
        /// </summary>

        public MetaInfo Meta { get; set; } = new MetaInfo();

        public class MetaInfo {
            /// <summary>
            /// 浏览数
            /// </summary>
            public int Views { get; set; } = 0;

            /// <summary>
            /// 点赞数
            /// </summary>
            public int Likes { get; set; } = 0;

            /// <summary>
            /// 评论数
            /// </summary>
            public int Comments { get; set; } = 0;
        }

    }
}
