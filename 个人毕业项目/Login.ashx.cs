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
            string name = context.Request.Params["Name"];
            string pwd = context.Request.Params["Pwd"];
            List<Customer> customers = CustomerBLL.GetCustomer();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Customer));
            ser.WriteObject(context.Response.OutputStream, customers);
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