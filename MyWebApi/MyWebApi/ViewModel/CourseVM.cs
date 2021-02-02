using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebApi.ViewModel
{
    public class CourseVM
    {
        public int courseId { get; set; }
        public string courseName { get; set; }
        public string location { get; set; }
        public Nullable<int> teacherId { get; set; }
    }
}