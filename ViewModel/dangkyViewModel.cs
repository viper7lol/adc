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
        public dangkyViewModel() {
            SignUpCommand = new RelayCommand<Page>((p) =>
            {
                return true;
            }, (p) =>
            {
                SignUp(p);
            });
            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { MatKhau = p.Password; });
        }
        void SignUp(Page p) {
            if (p == null) return;
            if (string.IsNullOrEmpty(TenNguoiDung) || string.IsNullOrEmpty(MatKhau) || string.IsNullOrEmpty(Email))
            {
                var tk = new NguoiDung() { TenNguoiDung = _UserName, Email = _Email, MatKhau = _Password, VaiTroID = 2, TrangThai = 1 };
                DataProvider.Ins.DB.NguoiDung.Add(tk);
                DataProvider.Ins.DB.SaveChanges();
            }
            else
            {
                MessageBox.Show("Đăng ký không thành công! Vui lòng đăng ký lại", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
