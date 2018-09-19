
using System.Web;

namespace Microsoft.AspNetCore.Mvc
{
    public class BaseController:Controller
    {
        public JsonResult JsonData(object obj)
        {
            //string json = JsonHelper.Serialize(obj);
            return base.Json(obj);
        }

        public JsonResult SuccessData(object data = null)
        {
            Result result = new Result("ok", data: data);
            return this.JsonData(result);
        }
        public JsonResult SuccessMsg(string msg = null)
        {
            Result result = new Result("ok",msg);
            return this.JsonData(result);
        }
        public JsonResult AddSuccessData(object data, string msg = "添加成功")
        {
            Result result = new Result("ok", msg, data);
            return this.JsonData(result);
        }
        public JsonResult AddSuccessMsg(string msg = "添加成功")
        {
            return this.SuccessMsg(msg);
        }
        public JsonResult UpdateSuccessMsg(string msg = "更新成功")
        {
            return this.SuccessMsg(msg);
        }
        public JsonResult DeleteSuccessMsg(string msg = "删除成功")
        {
            return this.SuccessMsg(msg);
        }
        public JsonResult FailedMsg(string msg = null)
        {
            Result retResult = new Result("error", msg);
            return this.JsonData(retResult);
        }
    }
}
