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
        private string _Email;
        public string Email { get => _Email; set { _Email = value; OnPropertyChanged(); } }
        private string _MatKhau;
        public string MatKhau { get => _MatKhau; set { _MatKhau = value; OnPropertyChanged(); } }

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

            var account = DataProvider.Ins.DB.NguoiDung.Where(x => x.Email == Email && x.MatKhau == MatKhau && x.VaiTroID == 1).Count();
            var account2 = DataProvider.Ins.DB.NguoiDung.Where(x=>x.Email == Email && x.MatKhau == MatKhau && x.VaiTroID == 2).Count();
            if (account > 0 && account2 == 0)
            {
                IsLogin = true;
                IsAdmin = true;
                p.Close();
            }
            if(account2 > 0 && account == 0)
            {
                IsLogin = true;
                IsAdmin = false;
                p.Close();
            }
            if(account == 0 &&  account2 == 0)
            {
                IsLogin = false;
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!");
            }
        }
    }
}
