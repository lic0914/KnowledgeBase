using System;
using System.Collections.Generic;
using System.Text;


namespace KnowledgeBase.Infrastracture
{
    //[System.ComponentModel.DataAnnotations.Schema.Table("DocTypes")] 
    public class DocType:BaseEntity
    {
        public string Name { get; set; }

    }
}