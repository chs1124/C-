using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class StudentService
    {
        public List<student> GetStudentByClass(string className) {
            string sql = "select a.* from students a,studentclass b where a.ClassId=b.ClassId and b.ClassName like '%{0}%'";
            sql = string.Format(sql,className);  

            MySqlDataReader objReader= MysqlHelper.GetReader(sql);
            List<student> list = new List<student>();
            while (objReader.Read()) {
                list.Add(new student
                {
                    StudentId = Convert.ToInt32(objReader["StudentId"]),
                    StudentName = objReader["StudentName"].ToString(),
                    Gender = objReader["Gender"].ToString(),
                    //Birthday = Convert.ToDateTime(objReader["Birthday"]),
                    //CardNo = objReader["CardNo"].ToString(),
                    //StudentIdNo=objReader["StudentIdNo"].ToString(),
                    //PhoneNumber=objReader["PhoneNumber"].ToString(),
                    //StudentAddress=objReader["StudentAddress"].ToString()
                });
            }
            objReader.Close();
            return list;
        }

        //单一查询--详细信息
        public student GetStudentById(string studentId) {

            string sql = "select * from students where studentId=" + studentId;
            MySqlDataReader objReader = MysqlHelper.GetReader(sql);

            student objStudent = null;
            if (objReader.Read()) {
                objStudent = new student()
                {
                    StudentId = Convert.ToInt32(objReader["StudentId"]),
                    StudentName = objReader["StudentName"].ToString(),
                    Gender = objReader["Gender"].ToString(),
                    Birthday = Convert.ToDateTime(objReader["Birthday"]),
                    CardNo = objReader["CardNo"].ToString(),
                    StudentIdNo = objReader["StudentIdNo"].ToString(),
                    PhoneNumber = objReader["PhoneNumber"].ToString(),
                    StudentAddress = objReader["StudentAddress"].ToString(),
                    Age = Convert.ToInt16(objReader["Age"]),
                    ClassId = Convert.ToInt32(objReader["ClassId"])
                };
            }
            objReader.Close();
            return objStudent;
        }

        //修改
        public int ModifyStudent(student objStudent) {
            //编写sql语句
            StringBuilder sqlB = new StringBuilder();
            sqlB.Append("update students set studentName='{0}',Gender='{1}',Birthday='{2}',");
            sqlB.Append("studentIdNo='{3}',PhoneNumber='{4}',studentAddress='{5}',classId={6} ");
            sqlB.Append(" where studentId={7}");
            //解析对象
             string sql = string.Format(sqlB.ToString(),objStudent.StudentName,objStudent.Gender,objStudent.Birthday,
                 objStudent.StudentIdNo,objStudent.PhoneNumber,objStudent.StudentAddress,
                 objStudent.ClassId,objStudent.StudentId);
            try
            {
                return Convert.ToInt32(MysqlHelper.Update(sql));
            }
            catch (MySqlException ex)
            {
                throw new Exception("数据库操作异常:" + ex.Message);
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        //添加
        public int AddStudent(student objStudent) {

            //编写语句
            StringBuilder sqlB = new StringBuilder();
            sqlB.Append("INSERT INTO students(StudentId, StudentName, Gender, Birthday, StudentIdNo, Age,PhoneNumber,StudentAddress,CardNo,ClassId) VALUES");
            sqlB.Append("('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')");
            string sql = string.Format(sqlB.ToString(),objStudent.StudentId, objStudent.StudentName, 
                objStudent.Gender, objStudent.Birthday, objStudent.StudentIdNo, objStudent.Age, objStudent.PhoneNumber, 
                objStudent.StudentAddress, objStudent.CardNo, objStudent.ClassId);
            try {
                return Convert.ToInt32(MysqlHelper.Update(sql));
            }
            catch (MySqlException ex)
            {
                throw new Exception("数据库操作异常:" + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        //删除
        public int DeleteStudent(string studentId) {
            String sql = "delete from students where studentId='{0}'";
            sql = string.Format(sql, studentId);
            try
            {
                return Convert.ToInt32(MysqlHelper.Update(sql));
            }
            catch (MySqlException ex)
            {
                throw new Exception("数据库操作异常:" + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
