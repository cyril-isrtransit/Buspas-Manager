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
    
    public partial class Questionnaries_Items
    {
        public long Item_ID { get; set; }
        public Nullable<long> Parent_Item_ID { get; set; }
        public long Quest_ID { get; set; }
        public int Item_Type { get; set; }
        public string Icon_URL { get; set; }
        public string Item_Description { get; set; }
        public Nullable<bool> Is_Mandatory { get; set; }
        public Nullable<int> Suverity { get; set; }
        public Nullable<int> Max_Selections { get; set; }
        public Nullable<int> Selection_Start { get; set; }
        public Nullable<int> Selection_End { get; set; }
        public string Option_1 { get; set; }
        public string Option_2 { get; set; }
        public string Option_3 { get; set; }
        public string Option_4 { get; set; }
        public string Option_5 { get; set; }
        public string Option_6 { get; set; }
        public string Option_7 { get; set; }
        public string Option_8 { get; set; }
        public string Option_9 { get; set; }
        public string Option_10 { get; set; }
    
        public virtual Questionnaires Questionnaires { get; set; }
    }
}
