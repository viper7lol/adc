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
    
    public partial class CoSoThuocBVTV
    {
        public int MaCoSo { get; set; }
        public string TenCoSo { get; set; }
        public string DiaChi { get; set; }
        public Nullable<System.DateTime> NgayCapGiayPhep { get; set; }
        public Nullable<int> LoaiCoSoID { get; set; }
        public string MaHanhChinh { get; set; }
    
        public virtual LoaiCoSo LoaiCoSo { get; set; }
        public virtual DonViHanhChinh DonViHanhChinh { get; set; }
    }
}
