//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace adc.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class BanDoPhanBo
    {
        public int ID { get; set; }
        public Nullable<int> CoSoID { get; set; }
        public Nullable<decimal> KinhDo { get; set; }
        public Nullable<decimal> ViDo { get; set; }
        public Nullable<int> KhuSVID { get; set; }
    
        public virtual CoSoPB CoSoPB { get; set; }
        public virtual VungTrong VungTrong { get; set; }
    }
}
