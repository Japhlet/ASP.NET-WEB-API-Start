//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyWebApi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class StudentAddress
    {
        public int id { get; set; }
        public Nullable<int> studentId { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public Nullable<int> cityId { get; set; }
        public Nullable<int> stateId { get; set; }
    
        public virtual City City { get; set; }
        public virtual State State { get; set; }
    }
}
