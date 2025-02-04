using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using adc.Model;
using System.Windows.Input;
using System.Windows;

namespace adc.ViewModel
{
    public class LoaiCoSoViewModel:BaseViewModel
    {
        private ObservableCollection<CoSoThuocBVTV> _CoSoList;
        public ObservableCollection<CoSoThuocBVTV> CoSoList { get => _CoSoList; set { _CoSoList = value; OnPropertyChanged(); } }

        private CoSoThuocBVTV _SelectedCoSoT;
        public CoSoThuocBVTV SelectedCoSoT
        {
            get => _SelectedCoSoT;
            set
            {
                _SelectedCoSoT = value;
                OnPropertyChanged();
                if(SelectedCoSoT != null)
                {
                    MaCoSo = SelectedCoSoT.MaCoSo;
                    TenCoSo = SelectedCoSoT.TenCoSo;
                    DiaChi = SelectedCoSoT.DiaChi;
                    NgayCapGiayPhep = SelectedCoSoT?.NgayCapGiayPhep;
                    LoaiCoSoID = SelectedCoSoT.LoaiCoSoID;
                    MaHanhChinh = SelectedCoSoT.MaHanhChinh;
                }
            }
        }

        private int _MaCoSo;
        public int MaCoSo { get => _MaCoSo; set { _MaCoSo = value; OnPropertyChanged(); } }
        private string _TenCoSo;
        public string TenCoSo { get => _TenCoSo; set { _TenCoSo = value; OnPropertyChanged(); } }
        private string _DiaChi;
        public string DiaChi { get => _DiaChi; set { _DiaChi = value; OnPropertyChanged(); } }
        private DateTime? _NgayCapGiayPhep;
        public DateTime? NgayCapGiayPhep { get => _NgayCapGiayPhep; set { _NgayCapGiayPhep = value; OnPropertyChanged(); } }
        private int? _LoaiCoSoID;
        public int? LoaiCoSoID { get => _LoaiCoSoID; set { _LoaiCoSoID = value; OnPropertyChanged(); } }
        private string _MaHanhChinh;
        public string MaHanhChinh { get => _MaHanhChinh; set { _MaHanhChinh = value; OnPropertyChanged(); } }

        public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand EditCommand { get; set; }  

        public LoaiCoSoViewModel()
        {
            CoSoList = new ObservableCollection<CoSoThuocBVTV>(DataProvider.Ins.DB.CoSoThuocBVTV);
            AddCommand = new RelayCommand<object>((p) =>
            {
                MainWindow mainWindow = new MainWindow();
                var MainVM = mainWindow.DataContext as MainViewModel;
                if (MainVM.isadmin)
                {
                    return true;
                }
                return false;
            }, (p) =>
            {
                var lcs = new CoSoThuocBVTV() { MaCoSo = MaCoSo, TenCoSo = TenCoSo, DiaChi = DiaChi, NgayCapGiayPhep = NgayCapGiayPhep, LoaiCoSoID = LoaiCoSoID, MaHanhChinh = MaHanhChinh };
                if (TenCoSo != null && DiaChi != null && NgayCapGiayPhep != null && MaHanhChinh != null && LoaiCoSoID != 0)
                {
                    DataProvider.Ins.DB.CoSoThuocBVTV.Add(lcs);
                    DataProvider.Ins.DB.SaveChanges();
                    CoSoList.Add(lcs);
                }
                else
                {
                    MessageBox.Show("Vui lòng điền đẩy đủ thông tin !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            });
            EditCommand = new RelayCommand<object>((p) =>
            {
                MainWindow mainWindow = new MainWindow();
                var MainVM = mainWindow.DataContext as MainViewModel;
            if (MainVM.isadmin)
            {
                if (string.IsNullOrEmpty(TenCoSo) || string.IsNullOrEmpty(DiaChi) || NgayCapGiayPhep == null || string.IsNullOrEmpty(MaHanhChinh) || LoaiCoSoID == 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                return false;
            }, (p) =>
            {
                var loaics = DataProvider.Ins.DB.CoSoThuocBVTV.Where(x => x.TenCoSo == SelectedCoSoT.TenCoSo).SingleOrDefault();
                loaics.MaCoSo = MaCoSo;
                loaics.TenCoSo = TenCoSo;
                loaics.DiaChi = DiaChi;
                loaics.NgayCapGiayPhep = NgayCapGiayPhep;
                loaics.MaHanhChinh = MaHanhChinh;
                loaics.LoaiCoSoID = LoaiCoSoID;
                DataProvider.Ins.DB.SaveChanges();
            });
            DeleteCommand = new RelayCommand<object>((p) =>
            {
                MainWindow mainWindow = new MainWindow();
                var MainVM = mainWindow.DataContext as MainViewModel;
                if (MainVM.isadmin)
                {
                    if (string.IsNullOrEmpty(TenCoSo) || string.IsNullOrEmpty(DiaChi) || NgayCapGiayPhep == null || string.IsNullOrEmpty(MaHanhChinh) || LoaiCoSoID == 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                return false;
            }, (p) =>
            {
                var ten = SelectedCoSoT;
                if(SelectedCoSoT != null)
                {
                    CoSoList.Remove(SelectedCoSoT);
                    DataProvider.Ins.DB.CoSoThuocBVTV.Remove(ten);
                    DataProvider.Ins.DB.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu để xóa", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            });
        }
    }
}
