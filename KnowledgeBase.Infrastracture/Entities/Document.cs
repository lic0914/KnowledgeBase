using System;
using System.Collections;
using System.Collections.Generic;

namespace KnowledgeBase.Infrastracture
{
    public class Document : BaseEntity
    {
        public int NavigationId { get; set; }
        public virtual Navigation Navigation { get; set; }
        public string Content { get; set; }
        public virtual List<DocumentTag> DocumentTags { get; set; } = new List<DocumentTag>();
    }
}