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
        public static int InsertCustomer(string ID,string LoginName,string Password)
        {
            Encryption(Password);
            return DAL.CustomerDAL.InsertCustomers(ID, LoginName, Password);
        }

        public static List<Customer> GetCustomer()
        {
            return DAL.CustomerDAL.GetCustomers();
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
