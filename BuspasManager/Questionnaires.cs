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
    
    public partial class Questionnaires
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Questionnaires()
        {
            this.Questionnaries_Items = new HashSet<Questionnaries_Items>();
        }
    
        public long Quest_ID { get; set; }
        public int Quest_Type { get; set; }
        public Nullable<long> Quest_Provider { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> From_Date { get; set; }
        public Nullable<System.DateTime> To_Date { get; set; }
        public Nullable<int> Sex { get; set; }
        public Nullable<int> From_Age { get; set; }
        public Nullable<int> To_Age { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Questionnaries_Items> Questionnaries_Items { get; set; }
    }
}
