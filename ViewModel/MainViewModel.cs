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
        public ICommand BanDoCommand { get; set; }
		public ICommand DoiCommand { get; set; }
		public ICommand LogoutCommand	{ get; set; }
		public ICommand VietGapCommand { get; set; }

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
				cdhc.Left = 300;
				cdhc.Top = 35;
				cdhc.ShowDialog();
			}
);

			DonViHanhChinhCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
			{
				DonViHanhChinhView dvhc = new DonViHanhChinhView();
				dvhc.Left = 300;
				dvhc.Top = 35; 
				dvhc.ShowDialog();
			}
			);

			CayTrongCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
			{
				CayTrongView ct = new CayTrongView();
				ct.Left = 300;
				ct.Top = 35;
				ct.ShowDialog();
			}
			);

			VungTrongCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
			{
				VungTrongView vt = new VungTrongView();
				vt.Left = 300;
				vt.Top = 35;
				vt.ShowDialog();
			}
			);

			PhanloaiPBCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
			{
				PhanBonView ph = new PhanBonView();
				ph.Left = 300;
				ph.Top = 35; 
				ph.ShowDialog();
			}
			);

			CosoPBCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
			{
				CoSoPBView co = new CoSoPBView();
				co.Left = 300;
				co.Top = 35; // Đổi vị trí
				co.ShowDialog();
			}
			);

			PhanLoaiThuocBVTVCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
			{
				ThuocBVTVView thuoc = new ThuocBVTVView();
				thuoc.Left = 300;
				thuoc.Top = 35;
				thuoc.ShowDialog();
			}
			);

			CosoThuocBVTVCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
			{
				CoSoThuocBVTVView loaiCoSoView = new CoSoThuocBVTVView();
				loaiCoSoView.Left = 300;
				loaiCoSoView.Top = 35;
				loaiCoSoView.ShowDialog();
			}
			);

			SVGHVTSCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
			{
				SinhVatGayHaiTuoiSauView sv = new SinhVatGayHaiTuoiSauView();
				sv.Left = 300;
				sv.Top = 35;
				sv.ShowDialog();
			}
			);

			QLNDCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
			{
				QuanLyNguoiDungView ql = new QuanLyNguoiDungView();
				ql.Left = 300;
				ql.Top = 35; 
				ql.ShowDialog();
			}
			);

			LSTCCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
			{
				LichSuTruyCapView ls = new LichSuTruyCapView();
				ls.Left = 300;
				ls.Top = 35;
				ls.ShowDialog();
			}
			);

			BanDoCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
			{
				BanDoPhanBo1 bd = new BanDoPhanBo1();
				bd.Left = 300;
				bd.Top = 35;
				bd.ShowDialog();
			}
			);
			DoiCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
			{
				Chinh_sua_thong_tin ch = new Chinh_sua_thong_tin();
				ch.Left = 300;
				ch.Top = 35;
				ch.ShowDialog();
			});
			LogoutCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
			{
				p.Close();
			});
			VietGapCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
			{
				CoSoVietGap cs = new CoSoVietGap();
				cs.Left = 300;
				cs.Top = 35;
                cs.ShowDialog();
            });
		}
	}
}
