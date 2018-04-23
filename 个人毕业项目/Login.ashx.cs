using System;
using System.Collections.Generic;
using System.Web;
using BLL;
using Model;
using System.Runtime.Serialization.Json;



namespace 个人毕业项目
{
    /// <summary>
    /// Login 的摘要说明
    /// </summary>
    public class Login : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            
            context.Response.ContentType = "text/plain";
            string name = context.Request.Params["LoginName"];
            string pwd = context.Request.Params["Password"];
            Customer customer = CustomerBLL.GetCustomer(name, pwd);
            try
            {
                context.Session["User"] = customer;
                context.Response.Write(1);
                return;
            }
            catch
            {
                context.Response.Write(0);
                return;
            }
            
        }
        
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}