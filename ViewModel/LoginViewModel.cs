﻿using adc.Model;
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
            var accCount1 = DataProvider.Ins.DB.NguoiDung.Where(x => x.Email == Email && x.MatKhau == MatKhau && x.VaiTroID == 1);
            var accCount2 = DataProvider.Ins.DB.NguoiDung.Where(x => x.Email == Email && x.MatKhau == MatKhau && x.VaiTroID == 2);
            MatKhau = "";
            Email = "";
            LoginCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                if (p == null)
                    return;

                /*
                 admin
                 admin

                staff
                staff
                 */

                if (accCount1 != null)
                {
                    IsLogin = true;
                    IsAdmin = true;
                    p.Close();
                }
                else
                {
                    IsLogin = false;
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu!");
                }
                if (accCount2 != null)
                {
                    IsLogin = true;
                    IsAdmin = false;
                    p.Close();
                }
                else
                {
                    IsLogin = false;
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu!");
                }
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

            var accCount = DataProvider.Ins.DB.NguoiDung.Where(x => x.Email == Email && x.MatKhau == MatKhau);
            var admin = DataProvider.Ins.DB.NguoiDung.Where(x => x.VaiTroID == 1);
            if (accCount != null)
            {
                IsLogin = true;
                if(accCount == admin) { IsAdmin = true; }
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
