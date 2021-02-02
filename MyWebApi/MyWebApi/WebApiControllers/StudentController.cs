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
    }
}
