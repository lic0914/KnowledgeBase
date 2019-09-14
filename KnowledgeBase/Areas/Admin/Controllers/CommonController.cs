using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace KnowledgeBase.Areas.Admin.Controllers
{
    [Area("admin")]
    public class CommonController : Controller
    {
       public IActionResult index()
        {
            return Content("admin/common/index");
        }
    }
}