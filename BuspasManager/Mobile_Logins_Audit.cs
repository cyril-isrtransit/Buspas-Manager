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
    
    public partial class Mobile_Logins_Audit
    {
        public long Session_Id { get; set; }
        public long Login_ID { get; set; }
        public System.DateTime Start_Time { get; set; }
        public Nullable<System.DateTime> Finish_Time { get; set; }
        public string IMEI { get; set; }
        public string APP_ID { get; set; }
        public Nullable<System.DateTime> Last_Transaction_Time { get; set; }
        public Nullable<double> Last_Lat { get; set; }
        public Nullable<double> Last_Lon { get; set; }
        public Nullable<System.DateTime> Last_Position_Update_Time { get; set; }
    }
}
