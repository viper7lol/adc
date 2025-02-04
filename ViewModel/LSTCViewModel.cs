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
        private string _MoTaHanhDong;
        public string MoTaHanhDong { get => _MoTaHanhDong; set { _MoTaHanhDong = value; OnPropertyChanged(); } }
        private int _ID;
        public int ID { get => _ID; set {  _ID = value; OnPropertyChanged(); } }
        private int? _UserID;
        public int? UserID { get => _UserID; set {  _UserID = value; OnPropertyChanged(); } }
        private DateTime? _ThoiGianTruyCap;
        public DateTime? ThoiGianTruyCap { get => _ThoiGianTruyCap; set { _ThoiGianTruyCap = value; OnPropertyChanged(); } }
        private ObservableCollection<LichSuTruyCap> _LSTCList;
        public ObservableCollection<LichSuTruyCap> LSTCList { get => _LSTCList; set { _LSTCList = value; OnPropertyChanged(); } }
        public LSTCViewModel()
        {
            MoTaHanhDong = "";
            LoginWindow lg = new LoginWindow();
            var loginVM = lg.DataContext as LoginViewModel;
            if (loginVM.IsLogin)
            {
                if (loginVM.IsAdmin)
                {
                    var lichSu = new LichSuTruyCap
                    {
                        UserID = 1,
                        ThoiGianTruyCap = DateTime.Now,
                        MoTaHanhDong = "đã đăng nhập vào hệ thống"
                    };
                    DataProvider.Ins.DB.LichSuTruyCap.Add(lichSu);
                    DataProvider.Ins.DB.SaveChanges();
                    LSTCList.Add(lichSu);
                }
                else
                {
                    var lichSu = new LichSuTruyCap
                    {
                        UserID = 2,
                        ThoiGianTruyCap = DateTime.Now,
                        MoTaHanhDong = "đã đăng nhập vào hệ thống"
                    };
                    DataProvider.Ins.DB.LichSuTruyCap.Add(lichSu);
                    DataProvider.Ins.DB.SaveChanges();
                    LSTCList.Add(lichSu);
                }
            }
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
