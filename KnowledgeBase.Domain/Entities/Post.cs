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
        /// ����
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// ����ͼ
        /// </summary>
        public string Thumb { get; set; }
        /// <summary>
        /// ���
        /// </summary>
        public string Brief { get; set; }
        public string Content { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime CreateTime { get; set; }=DateTime.Now;
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime? PostTime { get; set; }
        /// <summary>
        /// �Ƿ��ö�
        /// </summary>
        public bool IsTop { get; set; }
        /// <summary>
        /// ���棺0��������1
        /// </summary>
        public int State { get; set; }
        
    }
}