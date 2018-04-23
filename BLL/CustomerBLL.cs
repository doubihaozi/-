using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace BLL
{
    public class CustomerBLL
    {
        public static int InsertCustomer(Customer cus)
        {
            //Encryption(cus.Password);
            return DAL.CustomerDAL.InsertCustomers(cus);
        }

        public static Customer GetCustomer(string LoginName,string Password)
        {
        //    Password = Encryption(Password);
            if(new Rule.CustomerRule().TestInsert(LoginName))
            {
                return new Customer() {  UserName = "用户名错误！" };
            }

            List<Customer> Login = CustomerDAL.GetCustomers("where [LoginName]='" + LoginName + "'and [Password]='" + Password + "'");
            if (Login.Count != 1)
            {
                return new Customer() { LoginName = "密码错误！" };
            }
            else
                return Login[0];
        }
        /// 方法:对密码进行MD5加密
        /// </summary>
        /// <param name="pwd">原始密码</param>
        /// <returns>加密后的密码</returns>
        private static string Encryption(string pwd)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(pwd);
            bytes = md5.ComputeHash(bytes);
            return BitConverter.ToString(bytes);
        }
    }

}
