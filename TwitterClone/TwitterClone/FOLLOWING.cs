//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TwitterClone
{
    using System;
    using System.Collections.Generic;
    
    public partial class FOLLOWING
    {
        public int follow_id { get; set; }
        public string user_id { get; set; }
        public string following_id { get; set; }
    
        public virtual PERSON PERSON { get; set; }
    }
}
