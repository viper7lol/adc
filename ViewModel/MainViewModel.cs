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

        public bool isadmin {  get; set; }  

        public MainViewModel()
        {
            isadmin = false;
            LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                Isloaded = true;
                if (p == null) return;
                p.Hide();
                LoginWindow _loginWindow = new LoginWindow();
                _loginWindow.ShowDialog();
                if (_loginWindow.DataContext == null) return;
                var loginVM = _loginWindow.DataContext as LoginViewModel;
                if(loginVM.IsLogin == true && loginVM.IsAdmin == true)
                {
                    p.Show();
                    isadmin = true;
                }
                if (loginVM.IsLogin == true && loginVM.IsAdmin == false)
                {
                    p.Show();
                    isadmin = false;
                }
                if (loginVM.IsLogin == false)
                {
                    p.Close();
                }
            });
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
