using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
using BLL;
using System.Runtime.Serialization.Json;

namespace 个人毕业项目
{
    /// <summary>
    /// UserLogin 的摘要说明
    /// </summary>
    public class UserLogin : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            Customer customer = (Customer)context.Session["Users"];
            context.Response.Write(customer.UserName);
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