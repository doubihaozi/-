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
        public static List<Customer> GetCustomers(string where=null)
        {
            SqlDataReader dr = SQLHelp.ExecReader("select ROW_NUMBER() over (Order by LoginName) as LoginName, *from Users ");
            List<Customer> customers = new List<Customer>();
            Customer customer = null;
            if (dr!=null)
            {
                while(dr.Read())
                    {
                        customer = new Customer();
                        customer.LoginName = dr["LoginName"].ToString();
                        customer.Password = dr["Password"].ToString();
                        customers.Add(customer);
                    }
                SQLHelp.CloseConnection();
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
    }
}
