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
    
    public partial class ThuocBVTV
    {
        public int ID { get; set; }
        public string TenThuoc { get; set; }
        public string LoaiThuoc { get; set; }
        public Nullable<System.DateTime> NgaySanXuat { get; set; }
        public Nullable<System.DateTime> NgayHetHan { get; set; }
        public Nullable<int> CoSoID { get; set; }
    
        public virtual CoSo CoSo { get; set; }
    }
}
