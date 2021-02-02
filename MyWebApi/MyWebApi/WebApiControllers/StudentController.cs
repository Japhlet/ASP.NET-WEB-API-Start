using MyWebApi.Models;
using MyWebApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyWebApi.WebApiControllers
{
    public class StudentController : ApiController
    {
        public StudentController() {}
        
        public IHttpActionResult GetAllStudents()
        {
            IList<StudentVM> students = null;

            using (var db = new Db())
            {
                students = db.Student.Select(s => new StudentVM()
                {
                    studentId = s.studentId,
                    firstName = s.firstName,
                    lastName = s.lastName
                }).ToList<StudentVM>();
            }

            if (students.Count == 0)
            {
                return NotFound();
            }

            return Ok(students);
        }

        public IHttpActionResult GetStudentById(int id)
        {
            StudentVM student = null;

            using (var db = new Db())
            {
                student = db.Student.Include("StudentAddress")
                    .Where(s => s.studentId == id)
                    .Select(s => new StudentVM()
                    {
                        studentId = s.studentId,
                        firstName = s.firstName,
                        lastName = s.lastName
                    }).FirstOrDefault<StudentVM>();
            }

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        public IHttpActionResult GetAllStudents(string name)
        {
            IList<StudentVM> students = null;

            using (var db = new Db())
            {
                students = db.Student
                    .Where(s => s.firstName.ToLower() == name.ToLower())
                    .Select(s => new StudentVM()
                    {
                        studentId = s.studentId,
                        firstName = s.firstName,
                        lastName = s.lastName                        
                    }).ToList<StudentVM>();
            }

            if (students.Count == 0)
            {
                return NotFound();
            }

            return Ok(students);
        }

        public IHttpActionResult GetAllStudentsInSameStandard(int standardId)
        {
            IList<StudentVM> students = null;

            using (var db = new Db())
            {
                students = db.Student.Include("Standard").Where(s => s.standardId == standardId)
                            .Select(s => new StudentVM()
                            {
                                studentId = s.studentId,
                               firstName = s.firstName,
                               lastName = s.lastName,

                                standard = new StandardVM()
                                {
                                    standardId = s.Standard.standardId,
                                    standardName = s.Standard.standardName
                                }
                            }).ToList<StudentVM>();
            }

            if (students.Count == 0)
            {
                return NotFound();
            }

            return Ok(students);
        }
    }
}
