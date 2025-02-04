using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using adc.Model;
using System.Windows.Input;
using System.Windows;

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

        private LichSuTruyCap _SelectedLichSuTruyCap;
        public LichSuTruyCap SelectedLichSuTruyCap { get => _SelectedLichSuTruyCap; set { 
                _SelectedLichSuTruyCap = value; OnPropertyChanged();
                if(SelectedLichSuTruyCap != null)
                {
                    ID = SelectedLichSuTruyCap.ID;
                    UserID = SelectedLichSuTruyCap.UserID;
                    ThoiGianTruyCap = SelectedLichSuTruyCap.ThoiGianTruyCap;
                    MoTaHanhDong = SelectedLichSuTruyCap.MoTaHanhDong;
                }
            } }
        public ICommand ClearCommand { get; set; }
        public LSTCViewModel()
        {
            MoTaHanhDong = "";
            LSTCList = new ObservableCollection<LichSuTruyCap>(DataProvider.Ins.DB.LichSuTruyCap);
            LoginWindow lg = new LoginWindow();
            var loginVM = lg.DataContext as LoginViewModel;
            if (loginVM.IsLogin)
            {
                if (loginVM.IsAdmin)
                {
                    var lichSu = new LichSuTruyCap
                    {
                        ID = ID + 1,
                        UserID = 1,
                        ThoiGianTruyCap = DateTime.Now,
                        MoTaHanhDong = "đã đăng nhập vào hệ thống"
                    };
                    DataProvider.Ins.DB.LichSuTruyCap.Add(lichSu);
                    LSTCList.Add(lichSu);
                }
                else
                {
                    var lichSu = new LichSuTruyCap
                    {
                        ID = ID + 1,
                        UserID = 2,
                        ThoiGianTruyCap = DateTime.Now,
                        MoTaHanhDong = "đã đăng nhập vào hệ thống"
                    };
                    DataProvider.Ins.DB.LichSuTruyCap.Add(lichSu);
                    LSTCList.Add(lichSu);
                }
            }
            ClearCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                var tennd = SelectedLichSuTruyCap;
                if (SelectedLichSuTruyCap != null)
                {
                    LSTCList.Remove(SelectedLichSuTruyCap);
                    DataProvider.Ins.DB.LichSuTruyCap.Remove(tennd);
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu để xóa", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            });
            MainWindow mw = new MainWindow();
            var MainVM = mw.DataContext as MainViewModel;
            if (MainVM.islogout)
            {
                if (MainVM.isadmin)
                {
                    var lichSu = new LichSuTruyCap
                    {
                        ID = ID = 1,
                        UserID = 1,
                        ThoiGianTruyCap = DateTime.Now,
                        MoTaHanhDong = "đã đăng xuát khỏi hệ thống"
                    };
                    DataProvider.Ins.DB.LichSuTruyCap.Add(lichSu);
                    LSTCList.Add(lichSu);
                }
                else
                {
                    var lichSu = new LichSuTruyCap
                    {
                        ID = ID + 1,
                        UserID = 2,
                        ThoiGianTruyCap = DateTime.Now,
                        MoTaHanhDong = "đã đăng xuât khỏi hệ thống"
                    };
                    DataProvider.Ins.DB.LichSuTruyCap.Add(lichSu);
                    LSTCList.Add(lichSu);
                }
            }
        }
    }
}
