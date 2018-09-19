using System;
using System.Collections.Generic;
using System.Text;

namespace KnowledgeBase.Infrastracture
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreateTime { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; }

    }
}
