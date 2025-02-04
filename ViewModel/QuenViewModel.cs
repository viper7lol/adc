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
    public class QuenViewModel : BaseViewModel
    {
        private string _Email;
        public string Email { get => _Email; set { _Email = value; OnPropertyChanged(); } }
        private string _MatKhauMoi;
        public string MatKhauMoi { get => _MatKhauMoi; set { _MatKhauMoi = value; OnPropertyChanged(); } }
        public ICommand LoginCommand { get; set; }
        public ICommand LayCommand { get; set; }
        public ICommand PasswordChangedCommand { get; set; }
        public QuenViewModel()
        {
            LoginCommand = new RelayCommand<Window>((p) =>
            {
                return true;
            }, (p) =>
            {
                if (p == null) return;
                p.Close();
            });
            LayCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                Quen(p);
            });
            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { MatKhauMoi = p.Password; });
        }
        void Quen(Window window)
        {
            if (window == null) return;
            if (Email != null && MatKhauMoi != null)
            {
                var tk = DataProvider.Ins.DB.NguoiDung.Where(x => x.Email == Email).SingleOrDefault();
                tk.MatKhau = MatKhauMoi;
                DataProvider.Ins.DB.SaveChanges();
                MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Đổi mật khẩu không thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
