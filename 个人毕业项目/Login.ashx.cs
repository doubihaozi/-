using System;
using System.Collections.Generic;
using System.Web;
using BLL;
using Model;
using System.Runtime.Serialization.Json;
using System.Linq;

namespace 个人毕业项目
{
    /// <summary>
    /// Login 的摘要说明
    /// </summary>
    public class Login : IHttpHandler,System.Web.SessionState.IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            
            context.Response.ContentType = "text/plain";
            string name = context.Request.Params["LoginName"];
            string pwd = context.Request.Params["Password"];
            context.Session["Users"] = null;
            Customer customer = null;
            try
            {
                customer =CustomerBLL.GetCustomer().Where(U => U.LoginName == name && U.Password == pwd).First();
                context.Session["Users"] = customer;
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