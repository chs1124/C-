using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using BLL;

namespace StudentMangaerMvc.Controllers
{
    public class SysAdminController : Controller
    {
        // GET: SysAdmin
        public ActionResult Index()
        {
            return View("Login");
        }

        public ActionResult Login()
        {
            //接收数据
            SysAdmin objAdmin = new SysAdmin()
            {
                LoginId = Convert.ToInt32(Request.Params["loginId"]),
                LoginPwd = Request.Params["loginPwd"].ToString().Trim()

            };
            //调用业务逻辑
            objAdmin = new SysAdminManager().AdminLogin(objAdmin);
            if (objAdmin != null)
            {
                ViewData["info"] = "欢迎" + objAdmin.AdminName;
            }
            else
            {
                ViewData["info"] = "用户名或密码错误";
            }
            //
            return View("Login");
        }
    }
}