//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BuspasManager
{
    using System;
    using System.Collections.Generic;
    
    public partial class Questionary_Report_Items
    {
        public long Response_ID { get; set; }
        public string Session_ID { get; set; }
        public string Question_ID { get; set; }
        public string Item_ID { get; set; }
        public string Value { get; set; }
    
        public virtual Questionary_Report Questionary_Report { get; set; }
    }
}
