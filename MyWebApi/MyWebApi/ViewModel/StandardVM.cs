using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebApi.ViewModel
{
    public class StandardVM
    {
        public int standardId { get; set; }
        public string standardName { get; set; }
        public string description { get; set; }

        public ICollection<StudentVM> Students { get; set; }
    }
}