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
    
    public partial class Questionary_Report
    {
        public long Response_ID { get; set; }
        public Nullable<System.DateTime> Report_Time { get; set; }
        public Nullable<System.DateTime> Occour_Time { get; set; }
        public string Bus_Number { get; set; }
        public string Driver_Name { get; set; }
        public string Line_Number { get; set; }
        public string Direction { get; set; }
        public string Comments { get; set; }
        public string Session_ID { get; set; }
        public string Lat { get; set; }
        public string Lon { get; set; }
    
        public virtual Questionary_Report_Items Questionary_Report_Items { get; set; }
    }
}
