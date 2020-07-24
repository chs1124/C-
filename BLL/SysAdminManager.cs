using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;
using System.Web;

namespace BLL
{
    public class SysAdminManager
    {
        private SysadminService objAdminService = new SysadminService();
        public SysAdmin AdminLogin(SysAdmin objAdmin) {
            objAdmin = objAdminService.AdminLogin(objAdmin);
            if (objAdmin != null) {
                //登陆对象保存session
                HttpContext.Current.Session["CurrentAdmin"]=objAdmin;
            }
            return objAdmin;
        }
    }
}
