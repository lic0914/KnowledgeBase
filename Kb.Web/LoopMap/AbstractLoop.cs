using System;
using System.Collections.Generic;
using System.Text;

namespace Kb.Web.LoopMap
{
    public abstract class AbstractLoop<T>
    {
        public int Id { get; set; }
        public List<T> SubItem { get; set; } = new List<T>();
        public int ParentId { get; set; }
    }
    public abstract class AbstractLoop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }
        public object Tag { get; set; }
    }
}
