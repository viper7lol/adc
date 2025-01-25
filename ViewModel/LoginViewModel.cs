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
            MatKhau = "";
            Email = "";
            LoginCommand = new RelayCommand<Window>((p)=> { return true; }, (p) => { Login(p); });
            CloseCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { p.Close(); });
            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { MatKhau = p.Password; });
            SignUpCommand = new RelayCommand<Window>((p) => {
                return true;
            }, (p) => {
                signup su = new signup();
                su.ShowDialog();
                IsLogin = true;
                if (IsLogin)
                {
                    p.Close();
                }
                 
            });
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

            var accCount = DataProvider.Ins.DB.NguoiDung.Where(x => x.Email == Email && x.MatKhau == MatKhau).Count();

            if (accCount > 0)
            {
                IsLogin = true;
                p.Close();
            }
            else
            {
                IsLogin = false;
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!");
            }
        }
    }
}
