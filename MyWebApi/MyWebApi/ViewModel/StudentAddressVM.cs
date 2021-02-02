using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebApi.ViewModel
{
    public class StudentAddressVM
    {
        public int id { get; set; }
        public Nullable<int> studentId { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public Nullable<int> cityId { get; set; }
        public Nullable<int> stateId { get; set; }
    }
}