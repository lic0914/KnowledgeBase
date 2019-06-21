using System;
using System.Collections;
using System.Collections.Generic;

namespace KnowledgeBase.Domain.Entity
{
    public class Tag
    {
        public int Id { get; set; }
        /// <summary>
        /// ²©¿ÍId
        /// </summary>
        public int PostId { get; set; }
        /// <summary>
        /// ±êÇ©Ãû³Æ
        /// </summary>
        public string Name { get; set; }


    }
}