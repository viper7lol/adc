using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using adc.Model;

namespace adc.ViewModel
{
    public class LSTCViewModel:BaseViewModel
    {
        private ObservableCollection<LichSuTruyCap> _LSTCList;
        public ObservableCollection<LichSuTruyCap> LSTCList { get => _LSTCList; set { _LSTCList = value; OnPropertyChanged(); } }
        public LSTCViewModel()
        {
            LSTCList = new ObservableCollection<LichSuTruyCap>(DataProvider.Ins.DB.LichSuTruyCap);
        }
        public void GhiLichSu(int userId, string moTaHanhDong)
        {
            var lichSu = new LichSuTruyCap
            {
                UserID = userId,
                ThoiGianTruyCap = DateTime.Now,
                MoTaHanhDong = moTaHanhDong
            };

            // Thêm vào DB
            DataProvider.Ins.DB.LichSuTruyCap.Add(lichSu);
            DataProvider.Ins.DB.SaveChanges();

            // Cập nhật danh sách để hiển thị ngay lập tức
            LSTCList.Add(lichSu);
        }

    }
}
