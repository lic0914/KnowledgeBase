using System;
using System.Collections;
using System.Collections.Generic;

namespace KnowledgeBase.Domain.Entity
{
    public class Tag
    {
        public int Id { get; set; }
        /// <summary>
        /// ����Id
        /// </summary>
        public int PostId { get; set; }
        /// <summary>
        /// ��ǩ����
        /// </summary>
        public string Name { get; set; }


    }
}