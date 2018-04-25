using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using Model;

namespace DAL
{
    public class CustomerDAL
    {
        public static List<Customer> GetCustomers()
        {
            
            List<Customer> customers = new List<Customer>();
            Customer customer = null;
            if(SQLHelp.OpenConnection())
            {
                SqlDataReader dr = SQLHelp.ExecReader("select * from Users ", CommandType.Text);
                if (dr!=null)
                {
                    while(dr.Read())
                        {
                            customer = new Customer();
                            customer.ID = (int)dr["ID"];
                            customer.LoginName = dr["LoginName"].ToString();
                            customer.Password = dr["Password"].ToString();
                            customer.UserName = dr["UserName"].ToString();  
                            customers.Add(customer);
                        }
                    SQLHelp.CloseConnection();                   
                }
            }
            return customers; 
        }

        public static int InsertCustomers(Customer cus)
        {
            string sql = "insert into Users values(@LoginName,@Password,@UserName)";
            SqlParameter[] p =
            {
                new SqlParameter("@LoginName",cus.LoginName),
                new SqlParameter("@Password",cus.Password),
                new SqlParameter("@UserName",cus.UserName)
            };
            return SQLHelp.ExecQuery(sql,CommandType.Text,p);
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
