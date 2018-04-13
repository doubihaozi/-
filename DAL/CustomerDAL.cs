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
            SqlDataReader dr = DBHepler.ExecuteReader("select LoginName,Password form NFBook");
            List<Customer> customers = new List<Customer>();
            Customer customer = null;
            while(dr.Read())
            {
                customer = new Customer();
                customer.LoginName = dr["LoginName"].ToString();
                customer.Password = dr["Password"].ToString();
                customers.Add(customer);
            }
            dr.Close();
            return customers;
        }
        public static int InsertCustomers(string ID,string LoginName,string Password)
        {
            SqlParameter[] p =
            {
                new SqlParameter("@ID",ID),
                new SqlParameter("@LoginName",LoginName),
                new SqlParameter("@Password",Password)
            };
            return DBHepler.ExecuteNonQuery("insert into Customer(ID,LoginName,Password) vlaues(@ID,@LoginName,@Password)");
        }
    }
}
