using System;
using System.Collections;
using System.Collections.Generic;

namespace KnowledgeBase.Infrastracture
{
    public class Tag:BaseEntity
    {
        public int DocTypeId { get; set; }
        public string Name { get; set; }
        public virtual DocType DocType { get; set; }
        public virtual List<DocumentTag> DocumentTags { get; set; } = new List<DocumentTag>();

    }
}