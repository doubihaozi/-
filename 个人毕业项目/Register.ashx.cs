using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 个人毕业项目
{
    /// <summary>
    /// Register 的摘要说明
    /// </summary>
    public class Register : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            string name = context.Request.Params["LoginName"];
            string pwd = context.Request.Params["Password"];
            string username = context.Request.Params["Name"];

            try
            {
                Model.Customer customer = new Model.Customer();
                customer.LoginName = name;
                customer.Password = pwd;
                customer.UserName = username;
                if(BLL.CustomerBLL.InsertCustomer(customer)>0)
                {
                    context.Response.Write(1);
                    return;
                }
                else
                {
                    context.Response.Write(0);
                    return;
                }
            }
            catch
            {
                throw;
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