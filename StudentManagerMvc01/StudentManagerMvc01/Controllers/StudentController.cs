using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Model;

namespace StudentManagerMvc01.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View("StudentManage");
        }

        //根据班级名称查询学员信息
        public ActionResult GetStuList() {
            //获取提交的数据
            string className = Request.Params["className"].Trim();
            //调用模型处理
            List<student> stuList = new StudentManager().GetStudentByClass(className);
            //保存数据
            ViewBag.ClassName = className;
            ViewBag.stuList = stuList;

            //返回视图
            return View("StudentManage");
        }

        //详细信息
        public ActionResult GetStudentDetail() {
            string studentId = Request.QueryString["studentId"];
            student objStudent = new StudentManager().GetStudentById(studentId);
            ViewData["objStudent"] = objStudent;
            return View("StudentDetail");
        }

        public ActionResult GetStudent()
        {
            string stuId = Request.QueryString["stuId"];
            student objStudent = new StudentManager().GetStudentById(stuId);

            return View("StudentEdit",objStudent);
        }

        //修改
        public ActionResult Edit()
        {
            //获取数据并封装
            student objStudent = new student()
            {
                StudentId = Convert.ToInt32(Request.Params["stuId"]),
                StudentName=Request.Params["stuName"],
                Gender=Request.Params["gender"],
                Birthday=Convert.ToDateTime(Request.Params["birthday"]),
                StudentIdNo=Request.Params["stuIdNo"],
                PhoneNumber=Request.Params["phoneNumber"],
                StudentAddress=Request.Params["stuAddress"],
                ClassId=Convert.ToInt32( Request.Params["classId"])
            };

            //调用业务逻辑
            int result = new StudentManager().ModifyStudent(objStudent);
            return Content("<script>alert('修改成功!');document.location='"+Url.Action("Index","Student")+"'</script>");
        }

        //添加
        public ActionResult StudentAdd(){

            student objStudent = new student();
            return View("StudentAdd", objStudent);
        }
        public ActionResult Add() {
            //接收前端数据
            student objStudent = new student()
            {
                StudentId = Convert.ToInt32(Request.Params["stuId"]),
                StudentName = Request.Params["stuName"],
                Gender = Request.Params["gender"],
                Birthday = Convert.ToDateTime(Request.Params["birthday"]),
                StudentIdNo = Request.Params["stuIdNo"],
                PhoneNumber = Request.Params["phoneNumber"],
                StudentAddress = Request.Params["stuAddress"],
                ClassId = Convert.ToInt32(Request.Params["classId"]),
                Age=Convert.ToInt32(Request.Params["age"]),
                CardNo=Request.Params["cardNo"]
            };
            //调用逻辑处理
            int result = new StudentManager().AddStudent(objStudent);
            return Content("<script>alert('添加成功!');document.location='" + Url.Action("Index", "Student") + "'</script>");
        }


        //删除
        public ActionResult DeleteStudent() {
            string stuId = Request.QueryString["stuId"];
            int result = new StudentManager().DeleteStudent(stuId);
            return Content("<script>alert('删除成功!');document.location='" + Url.Action("Index", "Student") + "'</script>");
        }
    }
}