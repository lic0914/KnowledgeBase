using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace KnowledgeBase.Domain.Entity
{
    public class Post 
    {

        

        public int Id  { get; set; }
        public int ClassifyId { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 缩略图
        /// </summary>
        public string Thumb { get; set; }
        /// <summary>
        /// 简介
        /// </summary>
        public string Brief { get; set; }
        public string Content { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }=DateTime.Now;
        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime? PostTime { get; set; }
        /// <summary>
        /// 是否置顶
        /// </summary>
        public bool IsTop { get; set; }
        /// <summary>
        /// 保存：0，发布：1
        /// </summary>
        public int State { get; set; }
        
    }
}