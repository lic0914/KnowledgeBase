using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Kb.Web.LoopMap
{
    public static class LoopObjExtension
    {
        public static List<T> ToLoopChild<T>(this IEnumerable<T> source) where T : AbstractLoop<T>, new()
        {
            var root = new T();
            LoopLoadNode(source, root);
            return root.SubItem;
        }
        private static void LoopLoadNode<T>(IEnumerable<T> data, T curItem, int pid = 0) where T : AbstractLoop<T>, new()
        {
            var subItems = data.Where(e => e.ParentId == pid);
            curItem.SubItem.AddRange(subItems);
            foreach (var item in subItems)
            {
                LoopLoadNode(data, item, item.Id);
            }
        }
        public static List<T> ToLoopList<T>(this IEnumerable<T> source) where T : AbstractLoop
        {
            var data = new List<T>();
            LoopList(data, source);
            return data;
        }
        private static void LoopList<T>(List<T> data, IEnumerable<T> source, int pid = 0, int level = 0) where T : AbstractLoop
        {
            foreach (var item in source.Where(e => e.ParentId == pid))
            {
                if (item.ParentId == 0)
                    level = 0;
                item.Name = Repeat(item.Name, level);
                item.Tag = level;
                data.Add(item);
                LoopList(data, source, item.Id, ++level);
            }
        }
        private static string Repeat(string name, int level)
        {
            if (level == 0)
                return name;
            string root = "┗";
            for (int i = 0; i < level; i++)
            {
                name = $"━━━{name}";
            }
            return root + name;
        }

    }
}
