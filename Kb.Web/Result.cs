using System;

namespace System.Web
{
    public class Result
    {
        public Result(string s="",string m="",object data=null)
        {
            Status = s;
            Msg = m;
            Data = data;
        }
        public string Status { get; set; }
        public string Msg { get; set; }
        public object Data { get; set; }
    }
}
