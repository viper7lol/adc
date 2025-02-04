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
    public class CoSoPBViewModel : BaseViewModel
    {
        private ObservableCollection<CoSoPB> _CoSoList;
        public ObservableCollection<CoSoPB> CoSoList { get => _CoSoList; set { _CoSoList = value; OnPropertyChanged(); } }
        private CoSoPB _SelectedCoSo;
        public CoSoPB SelectedCoSo
        {
            get => _SelectedCoSo;
            set
            {
                _SelectedCoSo = value;
                OnPropertyChanged();
                if (SelectedCoSo != null)
                {
                    MaCoSo = SelectedCoSo.MaCoSo;
                    TenCoSo = SelectedCoSo.TenCoSo;
                    DiaChi = SelectedCoSo.DiaChi;
                    MaHanhChinh = SelectedCoSo.MaHanhChinh;
                }
            }
        }
        private int _MaCoSo;
        public int MaCoSo { get => _MaCoSo; set { _MaCoSo = value; OnPropertyChanged(); } }
        private string _TenCoSo;
        public string TenCoSo { get => _TenCoSo; set { _TenCoSo = value; OnPropertyChanged(); } }
        private string _DiaChi;
        public string DiaChi { get => _DiaChi; set { _DiaChi = value; OnPropertyChanged(); } }
        private string _MaHanhChinh;
        public string MaHanhChinh { get => _MaHanhChinh; set { _MaHanhChinh = value; OnPropertyChanged(); } }
        private DateTime? _NgayCapGiayPhep;
        public DateTime? NgayCapGiayPhep { get => _NgayCapGiayPhep; set { _NgayCapGiayPhep = value; OnPropertyChanged(); } }
        private int? _LoaiCoSoID;
        public int? LoaiCoSoID { get => _LoaiCoSoID; set { _LoaiCoSoID = value; OnPropertyChanged(); } }

        public ICommand AddCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand EditCommand { get; set; }  
        public ICommand DeleteCommand { get; set; } 
        public CoSoPBViewModel()
        {
            CoSoList = new ObservableCollection<CoSoPB>(DataProvider.Ins.DB.CoSoPB);
            AddCommand = new RelayCommand<object>((p) =>
            {
                MainWindow mainWindow = new MainWindow();
                var MainVM = mainWindow.DataContext as MainViewModel;
                if (MainVM.isadmin)
                {
                    return true;
                }
                return false;

            }, (P) =>
            {
                var coso = new CoSoPB() { MaCoSo = MaCoSo, TenCoSo = TenCoSo, DiaChi = DiaChi, MaHanhChinh = MaHanhChinh, LoaiCoSoID = LoaiCoSoID, NgayCapGiayPhep = NgayCapGiayPhep };
                if (TenCoSo != null && DiaChi != null && MaHanhChinh != null && LoaiCoSoID != 0 && NgayCapGiayPhep != null)
                {
                    DataProvider.Ins.DB.CoSoPB.Add(coso);
                    DataProvider.Ins.DB.SaveChanges();
                    CoSoList.Add(coso);
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
                    if (string.IsNullOrEmpty(MaHanhChinh) || string.IsNullOrEmpty(TenCoSo) || string.IsNullOrEmpty(DiaChi) || MaCoSo == 0 || LoaiCoSoID == 0 || NgayCapGiayPhep == null)
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
                var cosopb = DataProvider.Ins.DB.CoSoPB.Where(x=>x.MaCoSo == SelectedCoSo.MaCoSo).SingleOrDefault();
                cosopb.MaCoSo = MaCoSo;
                cosopb.TenCoSo = TenCoSo;
                cosopb.LoaiCoSoID = LoaiCoSoID;
                cosopb.DiaChi = DiaChi;
                cosopb.MaHanhChinh = MaHanhChinh;
                cosopb.NgayCapGiayPhep = NgayCapGiayPhep;
                DataProvider.Ins.DB.SaveChanges();
            });
            DeleteCommand = new RelayCommand<object>((p) =>
            {

                MainWindow mainWindow = new MainWindow();
                var MainVM = mainWindow.DataContext as MainViewModel;
                if (MainVM.isadmin)
                {
                    if (string.IsNullOrEmpty(MaHanhChinh) || string.IsNullOrEmpty(TenCoSo) || string.IsNullOrEmpty(DiaChi) || MaCoSo == 0 || LoaiCoSoID == 0 || NgayCapGiayPhep == null)
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
                var tencosopb = SelectedCoSo;
                if (SelectedCoSo != null)
                {
                    CoSoList.Remove(SelectedCoSo);
                    DataProvider.Ins.DB.CoSoPB.Remove(tencosopb);
                    DataProvider.Ins.DB.SaveChanges();
                }
                else {
                    MessageBox.Show("Không có dữ liệu để xóa", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            });
            SearchCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) => { 
                string searchTen = TenCoSo;
                string searchDC = DiaChi;
                string searchMa = MaHanhChinh;
                DateTime? searchNgay = NgayCapGiayPhep;
                int? searchID = LoaiCoSoID;
                if (searchMa != null || searchTen != null || searchID > 0 || searchNgay != null || searchDC != null)
                {
                    foreach (var item in CoSoList)
                    {
                        if (item.MaHanhChinh.Contains(searchMa) || item.TenCoSo.Contains(searchTen) || item.LoaiCoSoID.Equals(searchID) || item.NgayCapGiayPhep.Equals(searchNgay) || item.DiaChi.Contains(searchDC)) SelectedCoSo = item;
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy kết quả nào.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            });
        }
    }
}
