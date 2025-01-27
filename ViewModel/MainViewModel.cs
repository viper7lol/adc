using adc.View;
using Microsoft.Identity.Client;
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
    public class MainViewModel:BaseViewModel
    {
        public bool Isloaded = false;
        public ICommand LoadedWindowCommand { get; set; }
        public ICommand DonViHanhChinhCommand { get; set; }
        public ICommand CapDoHanhChinhCommand { get; set; }
        public ICommand CayTrongCommand { get; set; }
        public ICommand VungTrongCommand { get; set; }
        public ICommand PhanloaiPBCommand { get; set; }
        public ICommand CosoPBCommand { get; set; }
        public ICommand PhanLoaiThuocBVTVCommand { get; set; }
        public ICommand CosoThuocBVTVCommand { get; set; }
        public ICommand SVGHVTSCommand { get; set; }
        public ICommand QLNDCommand { get; set; }
        public ICommand LSTCCommand { get; set; }
        private LoginViewModel _loginVM;
        public LoginViewModel LoginVM { get => _loginVM; set => SetProperty(ref _loginVM, value); }


        public MainViewModel()
        {
            LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                Isloaded = true;
                if (p == null) return;
                p.Hide();
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.ShowDialog();
                if (loginWindow.DataContext == null) return;
                _loginVM = loginWindow.DataContext as LoginViewModel;
                if (LoginVM.IsLogin)
                {
                    p.Show();
                }
                else
                {
                    p.Close();
                }
            });
            LoginVM = _loginVM;
            CapDoHanhChinhCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                CapDoHanhChinhView cdhc = new CapDoHanhChinhView();
                cdhc.ShowDialog();
            }
            );
            DonViHanhChinhCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                DonViHanhChinhView dvhc = new DonViHanhChinhView();
                dvhc.ShowDialog();
            }
            );
            CayTrongCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                CayTrongView ct = new CayTrongView();
                ct.ShowDialog();
            }
            );
            VungTrongCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                VungTrongView vt = new VungTrongView();
                vt.ShowDialog();
            }
            );
            PhanloaiPBCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                PhanBonView ph = new PhanBonView();
                ph.ShowDialog();
            }
            );
            CosoPBCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                CoSoPBView co = new CoSoPBView();
                co.ShowDialog();
            }
            );
            PhanLoaiThuocBVTVCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                ThuocBVTVView thuoc = new ThuocBVTVView();
                thuoc.ShowDialog();
            }
            );
            CosoThuocBVTVCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                LoaiCoSoView loaiCoSoView = new LoaiCoSoView();
                loaiCoSoView.ShowDialog();
            }
            );
            SVGHVTSCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                SinhVatGayHaiTuoiSauView sv = new SinhVatGayHaiTuoiSauView();
                sv.ShowDialog();
            }
            );
            QLNDCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                QuanLyNguoiDungView ql = new QuanLyNguoiDungView();
                ql.ShowDialog();
            }
            );
            LSTCCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                LichSuTruyCapView ls = new LichSuTruyCapView();
                ls.ShowDialog();
            });
        }
    }
}
