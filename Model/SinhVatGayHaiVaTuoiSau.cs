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
    
    public partial class SinhVatGayHaiVaTuoiSau
    {
        public int ID { get; set; }
        public string TenSinhVat { get; set; }
        public string LoaiSinhVat { get; set; }
        public string TuoiSau { get; set; }
        public string CapDoPhoBien { get; set; }
        public string MoTa { get; set; }
        public Nullable<int> VungTrongID { get; set; }
    
        public virtual VungTrong VungTrong { get; set; }
    }
}
