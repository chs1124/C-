using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using MySql.Data.MySqlClient;


namespace DAL
{
    public class SysadminService
    {
        public SysAdmin AdminLogin(SysAdmin objAdmin) {
            string sql = "select AdminName from Admins where LoginId='{0}' and LoginPwd='{1}'";
            sql = string.Format(sql,objAdmin.LoginId,objAdmin.LoginPwd);
            try
            {
                MySqlDataReader objReader = MysqlHelper.GetReader(sql);
                if (objReader.Read())
                {
                    objAdmin.AdminName = objReader["AdminName"].ToString();
                    objReader.Close();
                }
                else {
                    objAdmin = null;
                }
            }
            catch (Exception ex) {
                throw new Exception("应用程序和数据库出现问题" + ex.Message);
            }
            return objAdmin;
        }
    }
}
