using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;

namespace BLL
{
    public class StudentManager
    {
        public List<student> GetStudentByClass(string className) {
            return new StudentService().GetStudentByClass(className);
        }

        public student GetStudentById(string studentId) {
            return new StudentService().GetStudentById(studentId);
        }

        public int ModifyStudent(student objstudent) {
            return new StudentService().ModifyStudent(objstudent);
        }

        public int AddStudent(student objstudent) {
            return new StudentService().AddStudent(objstudent);
        }

        public int DeleteStudent(string studentId) {
            return new StudentService().DeleteStudent(studentId);
        }
    }
}
