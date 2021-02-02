using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyWebApi.ViewModel
{
    public class StudentVM
    {
        [Key]
        public Nullable<int> studentId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public Nullable<int> standardId { get; set; }

        public StudentAddressVM studentAddress { get; set; }
        public StandardVM standard { get; set; }
    }
}