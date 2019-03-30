using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace KnowledgeBase.Areas.Tools
{
    [Area("Tools")]
    public class HomeController : Controller
    {
       
        public IActionResult Index()
        {
            return RedirectToAction("object_To_object");
        }
        [HttpGet]
        public IActionResult object_To_object()
        {
                return View();
        }
        [HttpPost]
        public IActionResult object_To_object(string old,int type)
        {
            ViewBag.Old = old;
         

            if (!CheckValue(old))
            {
                ModelState.AddModelError("", "格式错误");
                return View();
            }
                

            Regex reg = new Regex(@"public\s+\w+\s+\w+");
            var matches= reg.Matches(old);//public type xxxx 
            if(matches.Count<=0)
            {
                ModelState.AddModelError("", "格式错误");
                return View();
            }

            try
            {

                ViewBag.ToObj = ConvertToObject(type, matches);
            }
            catch (Exception)
            {

                ModelState.AddModelError("", "格式错误");
            }

            return View();
        }
        private bool CheckValue(string value)
        {
            return value.Contains("public")
                && value.Contains("class")
                && value.Contains("{")
                && value.Contains("}")
                && value.Contains("get")
                && value.Contains("set");
        }
        private string ConvertToObject(int type, MatchCollection matches)
        {
                StringBuilder sb = new StringBuilder();
            if (type == 0)
            {
                sb.Append("new ToObject")
                    .AppendLine()
                    .Append("{")
                    .AppendLine();
                foreach (var match in matches.Where(e => !e.Value.Contains("class")))
                {
                    var propertyName = Regex.Split(match.Value, @"\s+")[2];
                    sb.Append("        ").Append(propertyName).Append("=").Append("object.").Append(propertyName).Append(",").AppendLine();
                }
                sb = sb.Remove(sb.Length - 1, 1);
                sb.Append("}");
            }
            else
            {
                sb.Append("var toObject = new ToObect();").AppendLine();
                foreach (var match in matches.Where(e => !e.Value.Contains("class")))
                {
                    var propertyName = Regex.Split(match.Value, @"\s+")[2];
                    sb.Append("object.").Append(propertyName).Append(" = ").Append("toObject.").Append(propertyName).Append(";").AppendLine();
                }
            }

            return sb.ToString();
        }
    }
}