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
    public class SVGHVTSViewModel:BaseViewModel
    {
        private ObservableCollection<SinhVatGayHaiVaTuoiSau> _SVGHVTSList;
        public ObservableCollection<SinhVatGayHaiVaTuoiSau> SVGHVTSList { get => _SVGHVTSList; set { _SVGHVTSList = value; OnPropertyChanged(); } }

        private SinhVatGayHaiVaTuoiSau _SelectedSVGHVTS;
        public SinhVatGayHaiVaTuoiSau SelectedSVGHVTS
        {
            get => _SelectedSVGHVTS;
            set
            {
                _SelectedSVGHVTS = value;
                OnPropertyChanged();
                if(SelectedSVGHVTS != null)
                {
                    ID = SelectedSVGHVTS.ID;
                    TenSinhVat = SelectedSVGHVTS.TenSinhVat;
                    LoaiSinhVat = SelectedSVGHVTS.LoaiSinhVat;
                    TuoiSau = SelectedSVGHVTS.TuoiSau;
                    CapDoPhoBien = SelectedSVGHVTS.CapDoPhoBien;
                    MoTa = SelectedSVGHVTS.MoTa;
                    VungTrongID = SelectedSVGHVTS?.VungTrongID;
                }
            }
        }

        private int _ID;
        public int ID { get => _ID; set {  _ID = value; OnPropertyChanged(); } }
        private string _TenSinhVat;
        public string TenSinhVat { get => _TenSinhVat; set { _TenSinhVat = value; OnPropertyChanged(); } }
        private string _LoaiSinhVat;
        public string LoaiSinhVat { get => _LoaiSinhVat; set { _LoaiSinhVat = value; OnPropertyChanged(); } }
        private string _TuoiSau;
        public string TuoiSau { get => _TuoiSau; set { _TuoiSau = value; OnPropertyChanged(); } }
        private string _CapDoPhoBien;
        public string CapDoPhoBien { get => _CapDoPhoBien; set { _CapDoPhoBien = value; OnPropertyChanged(); } }
        private string _MoTa;
        public string MoTa { get => _MoTa; set { _MoTa = value; OnPropertyChanged(); } }
        private int? _VungTrongID;
        public int? VungTrongID { get => _VungTrongID; set { _VungTrongID = value; OnPropertyChanged(); } }

        public ICommand AddCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public SVGHVTSViewModel()
        {
            SVGHVTSList = new ObservableCollection<SinhVatGayHaiVaTuoiSau>(DataProvider.Ins.DB.SinhVatGayHaiVaTuoiSau);
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
                var svts = new SinhVatGayHaiVaTuoiSau() { ID = ID, TenSinhVat =TenSinhVat, LoaiSinhVat = LoaiSinhVat, TuoiSau = TuoiSau, CapDoPhoBien = CapDoPhoBien, MoTa = MoTa, VungTrongID = VungTrongID };
                if (TenSinhVat != null && LoaiSinhVat != null && TuoiSau != null && CapDoPhoBien != null && MoTa != null && VungTrongID != 0)
                {
                    DataProvider.Ins.DB.SinhVatGayHaiVaTuoiSau.Add(svts);
                    DataProvider.Ins.DB.SaveChanges();
                    SVGHVTSList.Add(svts);
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
                    if (string.IsNullOrEmpty(TenSinhVat) || string.IsNullOrEmpty(LoaiSinhVat) || string.IsNullOrEmpty(TuoiSau) || string.IsNullOrEmpty(MoTa) || string.IsNullOrEmpty(CapDoPhoBien) || VungTrongID == 0)
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
                var svgh = DataProvider.Ins.DB.SinhVatGayHaiVaTuoiSau.Where(x => x.TenSinhVat == SelectedSVGHVTS.TenSinhVat).SingleOrDefault();
                svgh.ID = ID;
                svgh.TenSinhVat = TenSinhVat;
                svgh.LoaiSinhVat = LoaiSinhVat;
                svgh.TuoiSau = TuoiSau;
                svgh.CapDoPhoBien = CapDoPhoBien;
                svgh.MoTa = MoTa;
                svgh.VungTrongID = VungTrongID;
                DataProvider.Ins.DB.SaveChanges();
            });
            DeleteCommand = new RelayCommand<object>((p) =>
            {
                MainWindow mainWindow = new MainWindow();
                var MainVM = mainWindow.DataContext as MainViewModel;
                if (MainVM.isadmin)
                {
                    if (string.IsNullOrEmpty(TenSinhVat) || string.IsNullOrEmpty(LoaiSinhVat) || string.IsNullOrEmpty(TuoiSau) || string.IsNullOrEmpty(MoTa) || string.IsNullOrEmpty(CapDoPhoBien) || VungTrongID == 0)
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
                var sv = SelectedSVGHVTS;
                if (SelectedSVGHVTS != null)
                {
                    SVGHVTSList.Remove(SelectedSVGHVTS);
                    DataProvider.Ins.DB.SinhVatGayHaiVaTuoiSau.Remove(sv);
                    DataProvider.Ins.DB.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu để xóa", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            });
            SearchCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                string searchTen = TenSinhVat;
                string searchLoai = LoaiSinhVat;
                string searchCD = CapDoPhoBien;
                string searchTS = TuoiSau;
                int? searchID = VungTrongID;
                if (searchTen != null || searchID > 0 || searchLoai != null || searchCD != null || searchTS != null)
                {
                    foreach (var item in SVGHVTSList)
                    {
                        if (item.TenSinhVat.Contains(searchTen) || item.LoaiSinhVat.Contains(searchLoai) || item.VungTrongID.Equals(searchID) || item.CapDoPhoBien.Contains(searchCD) || item.TuoiSau.Contains(searchTS)) SelectedSVGHVTS = item;
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
