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
    
    public partial class Bus_Talk_Items
    {
        public long Item_ID { get; set; }
        public long Internal_Agency_ID { get; set; }
        public Nullable<long> Parent_Item_ID { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public Nullable<int> Miles_Reward { get; set; }
        public System.DateTime From_Date { get; set; }
        public System.DateTime To_Date { get; set; }
    }
}