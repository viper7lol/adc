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
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-J7UA5U3P;Initial Catalog=QuanLyTrongTrot;Integrated Security=True");
        }
        public DbSet<CapDoHanhChinh> CapDoHanhChinh { get; set; }
    }
}
