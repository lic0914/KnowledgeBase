using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KnowleageBase.ViewModel;
using KnowledgeBase.Infrastracture;
using Microsoft.AspNetCore.Mvc;

namespace KnowledgeBase.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WikiController : BaseController
    {
        DocTypeService doctypeSvc;
        public WikiController(DataContext ctx)
        {
            doctypeSvc = new DocTypeService(ctx);
        }
        public IActionResult DocType()
        {
           
           var vm = doctypeSvc.GetAll();
            return View(vm);
        }
        [HttpGet]
        public IActionResult OperDocType(SignId signId)
        {
            var vm = doctypeSvc.GetById((int)signId.Id);
            return SuccessData(vm);
        }
        [HttpPost]
        public async Task<IActionResult> OperDocType(DocType doc)
        {
            if (doc.Id == 0)
            {
               await doctypeSvc.Add(doc);
                return AddSuccessMsg();
            }
            else
            {
                await doctypeSvc.Update(doc.Id, doc.Name);
                return UpdateSuccessMsg();
            }
        }
        [HttpPost]
        public async Task<IActionResult> DelDocType(SignId signId)
        {
                await doctypeSvc.SoftDeleted((int)signId.Id);
                return DeleteSuccessMsg();
        }
        ///// <summary>
        ///// 文档类型-导航设置
        ///// </summary>
        ///// <returns></returns>
        //public IActionResult Navigation()
        //{
        //    var vm = new List<NavigationViewModel>();

        //    return View(vm);
        //}
        //[HttpPost]
        //public IActionResult Navigation(NavigationViewModel model)
        //{
        //    return AddSuccessMsg();
        //}
        //public IActionResult AddArticle(EditType type=EditType.UEditor)
        //{
        //    ViewBag.type = type;
        //    return View();
        //}


    }
}