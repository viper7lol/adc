using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using adc.Model;

namespace adc.ViewModel
{
    public class dangkyViewModel:BaseViewModel
    {
        public bool IsSignUp { get; set; }
        private string _UserName;
        public string TenNguoiDung { get => _UserName; set { _UserName = value; OnPropertyChanged(); } }
        private string _Email;
        public string Email { get => _Email; set {  _Email = value; OnPropertyChanged(); } }
        private string _Password;
        public string MatKhau { get => _Password; set {  _Password = value; OnPropertyChanged(); } }
        public int VaiTroID { get; set; }
        public byte TrangThai {  get; set; }

        public ICommand SignUpCommand { get; set; }
        public ICommand PasswordChangedCommand { get; set; }
        public ICommand LoginCommand { get; set; }
   
        public dangkyViewModel() {
            IsSignUp = false;
            SignUpCommand = new RelayCommand<Window>((p) =>
            {
                return true;
            }, (p) =>
            {
                SignUp(p);
            });
            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { MatKhau = p.Password; });
            LoginCommand = new RelayCommand<Window>((p) =>
            {
                return true;
            }, (p) =>
            {
                if (p == null) return;
                p.Close();
            });
        }
        void SignUp(Window p) {
            if (p == null) return;
            if (TenNguoiDung != null && Email != null && MatKhau != null)
            {
                var tk = new NguoiDung() { Email = Email, TenNguoiDung = TenNguoiDung, MatKhau = MatKhau, VaiTroID = 2, TrangThai = 1};
                DataProvider.Ins.DB.NguoiDung.Add(tk);
                DataProvider.Ins.DB.SaveChanges();
                MessageBox.Show("Đăng ký thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Đăng ký không thành công! Vui lòng đăng ký lại", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
