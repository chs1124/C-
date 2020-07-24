using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace DAL
{
    public class MysqlHelper
    {
        public static readonly string connString=
           ConfigurationManager.ConnectionStrings["AppsSqlServer"].ToString();
        //增删改
        public static int Update(string sql) {
            MySqlConnection conn = new MySqlConnection(connString);
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            try
            {
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally {
                conn.Close();
            }
        }

        //单一查询
        public static object GetSingleResult(string sql) {
            MySqlConnection conn = new MySqlConnection(connString);
            MySqlCommand cmd = new MySqlCommand(sql,conn);
            try
            {
                conn.Open();
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally {
                conn.Close();
            }
        }
        //结果集的查询
        public static MySqlDataReader GetReader(string sql) {
            MySqlConnection conn = new MySqlConnection(connString);
            MySqlCommand cmd = new MySqlCommand(sql,conn);

            try
            {
                conn.Open();
                return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                  conn.Close();
                throw ex;
            }
            finally {
            
            }
        }

    }
}
