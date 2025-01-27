using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using adc.Model;
using Microsoft.EntityFrameworkCore;

namespace adc.ViewModel
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=LAPTOP-ULJ4Q7AM\\KTPMUD20241;Initial Catalog=QuanLyTrongTrot;Persist Security Info=True;User ID=mailinh;Encrypt=True;Trust Server Certificate=True");
        }
        public virtual DbSet<CapDoHanhChinh> CapDoHanhChinh { get; set; }
        public virtual DbSet<NguoiDung> NguoiDung { get; set; }
    }
}
