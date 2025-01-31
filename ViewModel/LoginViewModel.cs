using adc.Model;
using adc.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace adc.ViewModel
{
   public class LoginViewModel : BaseViewModel
    {
        public bool IsLogin { get; set; }
        public bool IsAdmin { get; set; }
        private string _UserName;
        public string Email { get => _UserName; set { _UserName = value; OnPropertyChanged(); } }
        private string _Password;
        public string MatKhau { get => _Password; set { _Password = value; OnPropertyChanged(); } }

        public ICommand CloseCommand { get; set; }
        public ICommand LoginCommand { get; set; }
        public ICommand PasswordChangedCommand { get; set; }
        public ICommand SignUpCommand { get; set; }
        // mọi thứ xử lý sẽ nằm trong này
        public LoginViewModel()
        {
            IsLogin = false;
            IsAdmin = false;
            MatKhau = "";
            Email = "";
            LoginCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                Login(p);
            });
            CloseCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { p.Close(); });
            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { MatKhau = p.Password; });
            SignUpCommand = new RelayCommand<Window>((p) =>
            {
                return true;
            }, (p) =>
            {
                if (p == null) return;
                signup su = new signup();
                su.ShowDialog();
            });

        }
        public bool DangNhap(string email, string matKhau)
        {
            var user = DataProvider.Ins.DB.NguoiDung.FirstOrDefault(u => u.Email == email && u.MatKhau == matKhau);
            if (user != null)
            {
                // Ghi lại lịch sử truy cập
                LSTCViewModel lstcVM = new LSTCViewModel();
                lstcVM.GhiLichSu(user.ID, "Người dùng đã đăng nhập.");

                return true;
            }
            return false;
        }

        void Login(Window p)
        {
            if (p == null)
                return;

            /*
             admin
             admin

            staff
            staff
             */

            var account1 = DataProvider.Ins.DB.NguoiDung.Where(x => x.Email == Email && x.MatKhau == MatKhau && x.VaiTroID == 1);
            var account2 = DataProvider.Ins.DB.NguoiDung.Where(x => x.Email == Email && x.MatKhau == MatKhau && x.VaiTroID != 1);
            if (account1 != null)
            {
                IsLogin = true;
                IsAdmin = true;
                p.Close();
            }
            if (account2 != null) { 
                IsLogin = true;
                IsAdmin = false;
                p.Close();
            }
            if(account1 == null && account2 == null)
            {
                IsLogin = false;
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!");
            }
        }
    }
}
