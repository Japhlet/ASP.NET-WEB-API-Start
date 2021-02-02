using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebApi.ViewModel
{
    public class StateVM
    {
        public int stateId { get; set; }
        public string stateName { get; set; }
        public Nullable<int> cityId { get; set; }
    }
}