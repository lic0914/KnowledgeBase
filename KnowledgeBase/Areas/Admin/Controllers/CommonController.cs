using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UEditor.Core;

namespace KnowledgeBase.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CommonController : Controller
    {
        private readonly UEditorService _ueditorService;
        public CommonController(UEditorService ueditorService)
        {
            this._ueditorService = ueditorService;
        }
        public IActionResult UEditor()
        {
            return View();
        }

        //如果是API，可以按MVC的方式特别指定一下API的URI
        [HttpGet, HttpPost]
        public ContentResult UEUpload()
        {
            var response = _ueditorService.UploadAndGetResponse(HttpContext);
            return Content(response.Result, response.ContentType);
        }

        public IActionResult Editormd()
        {
            return View();
        }
    }
}