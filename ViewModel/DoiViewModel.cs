using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using adc.Model;

namespace adc.ViewModel
{
    public class DoiViewModel : BaseViewModel
    {
        private string _TenNguoiDung;
        public string TenNguoiDung { get => _TenNguoiDung; set { _TenNguoiDung = value; OnPropertyChanged(); } }
        private string _Email;
        public string Email { get => _Email; set { _Email = value; OnPropertyChanged(); } }
        private string _MatKhau;
        public string MatKhau { get => _MatKhau; set { _MatKhau = value; OnPropertyChanged(); } }
        private string _DonViHanhChinhID;
        public string DonViHanhChinhID { get => _DonViHanhChinhID; set { _DonViHanhChinhID = value; OnPropertyChanged(); } }
        private int? _VaiTroID;
        public int? VaiTroID { get => _VaiTroID; set { _VaiTroID = value; OnPropertyChanged(); } }

        public ICommand ChangeCommand { get; set; }

        public DoiViewModel()
        {
            ChangeCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                if (TenNguoiDung != null && Email != null && MatKhau != null && DonViHanhChinhID != null)
                {
                    LoginWindow loginWindow = new LoginWindow();
                    var LoginVM = loginWindow.DataContext as LoginViewModel;
                    var nd = DataProvider.Ins.DB.NguoiDung.Where(x => x.Email == LoginVM.Email).SingleOrDefault();
                    nd.TenNguoiDung = TenNguoiDung;
                    nd.Email = Email;
                    nd.MatKhau = MatKhau;
                    nd.DonViHanhChinhID = DonViHanhChinhID;
                    DataProvider.Ins.DB.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            });
        }
    }
}
