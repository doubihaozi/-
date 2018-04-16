using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class DBHepler
    {
        static string strsql = ConfigurationManager.ConnectionStrings["SQL"].ConnectionString;
        static SqlConnection conn = new SqlConnection(strsql);
        
        static public void Open()
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
        }
        static public void Close()
        {
            if (conn.State != ConnectionState.Closed)
            {
                conn.Close();
            }
        }

        static public SqlDataReader ExecuteReader(string Quser, params SqlParameter[] p)
        {
            SqlDataReader dr = null;
            try
            {
                conn.Close();
                conn.Open();
                SqlCommand cmd = new SqlCommand(Quser, conn);
                if (p != null)
                {
                    cmd.Parameters.AddRange(p);
                }
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                throw;
            }
            return dr;
        }

        static public int ExecuteNonQuery(string Quser, params SqlParameter[] p)
        {
            int count = 0;
            try
            {
                conn.Close();
                conn.Open();
                SqlCommand cmd = new SqlCommand(Quser, conn);
                cmd.Parameters.AddRange(p);
                count = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            return count;

        }
        public static DataSet GetDataSet(string sql, CommandType commandType, params SqlParameter[] sqlParameter)
        {
            DataSet dataSet = new DataSet();
            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, conn);
                dataAdapter.SelectCommand.CommandType = commandType;
                if (sqlParameter != null)
                {
                    dataAdapter.SelectCommand.Parameters.AddRange(sqlParameter);
                }
                dataAdapter.Fill(dataSet);
            }
            catch (Exception)
            {
                throw;
            }
            return dataSet;
        }
    }
}
