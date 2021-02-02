using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebApi.ViewModel
{
    public class TeacherVM
    {
        public int teacherId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public Nullable<int> standardId { get; set; }
    }
}