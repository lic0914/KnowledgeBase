using KnowledgeBase.Models.enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace KnowledgeBase.Infrastracture
{
    public class Navigation : BaseEntity
    {
        public int DocTypeId { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }
        public  DocType DocType { get; set; }


    }
}
    