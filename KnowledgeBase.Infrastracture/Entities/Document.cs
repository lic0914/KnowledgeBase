using System;
using System.Collections;
using System.Collections.Generic;

namespace KnowledgeBase.Infrastracture
{
    public class Document : BaseEntity
    {
        public string Content { get; set; }
        public virtual List<DocumentTag> DocumentTags { get; set; } = new List<DocumentTag>();
    }
}