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
    public class ThuocBVTVViewModel : MainViewModel
    {
        private ObservableCollection<ThuocBVTV> _ThuocBVTVList;
        public ObservableCollection<ThuocBVTV> ThuocBVTVList { get => _ThuocBVTVList; set { _ThuocBVTVList = value; OnPropertyChanged(); } }

        private ThuocBVTV _SelectedThuocBVTV;
        public ThuocBVTV SelectedThuocBVTV
        {
            get => _SelectedThuocBVTV;
            set
            {
                _SelectedThuocBVTV = value;
                OnPropertyChanged();
                if (SelectedThuocBVTV != null)
                {
                    ID = SelectedThuocBVTV.ID;
                    TenThuoc = SelectedThuocBVTV.TenThuoc;
                    LoaiThuoc = SelectedThuocBVTV.LoaiThuoc;
                    MoTa = SelectedThuocBVTV.MoTa;
                    NgaySanXuat = SelectedThuocBVTV.NgaySanXuat;
                    NgayHetHan = SelectedThuocBVTV.NgayHetHan;
                }
            }
        }

        private int _ID;
        public int ID { get => _ID; set { _ID = value; OnPropertyChanged(); } }
        private string _TenThuoc;
        public string TenThuoc { get => _TenThuoc; set { _TenThuoc = value; OnPropertyChanged(); } }
        private string _LoaiThuoc;
        public string LoaiThuoc { get => _LoaiThuoc; set { _LoaiThuoc = value; OnPropertyChanged(); } }
        private string _MoTa;
        public string MoTa { get => _MoTa; set { _MoTa = value; OnPropertyChanged(); } }
        private DateTime? _NgaySanXuat;
        public DateTime? NgaySanXuat { get => _NgaySanXuat; set { _NgaySanXuat = value; OnPropertyChanged(); } }
        private DateTime? _NgayHetHan;
        public DateTime? NgayHetHan { get => _NgayHetHan; set { _NgayHetHan = value; OnPropertyChanged(); } }

        public ICommand SearchCommand { get; set; }
        public ICommand AddCommand { get; set; }    
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ThuocBVTVViewModel()
        {
            ThuocBVTVList = new ObservableCollection<ThuocBVTV>(DataProvider.Ins.DB.ThuocBVTV);
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
                var thuoc = new ThuocBVTV() { ID = ID, TenThuoc = TenThuoc, LoaiThuoc = LoaiThuoc, MoTa = MoTa, NgaySanXuat = NgaySanXuat, NgayHetHan = NgayHetHan };
                if (TenThuoc != null && LoaiThuoc != null && MoTa != null && NgaySanXuat != null && NgayHetHan != null)
                {
                    DataProvider.Ins.DB.ThuocBVTV.Add(thuoc);
                    DataProvider.Ins.DB.SaveChanges();
                    ThuocBVTVList.Add(thuoc);
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
                    if (string.IsNullOrEmpty(TenThuoc) || string.IsNullOrEmpty(LoaiThuoc) || string.IsNullOrEmpty(MoTa) || NgaySanXuat == null || NgayHetHan == null)
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
                var thuocbvtv = DataProvider.Ins.DB.ThuocBVTV.Where(x => x.TenThuoc == SelectedThuocBVTV.TenThuoc).SingleOrDefault();
                thuocbvtv.ID = ID;
                thuocbvtv.TenThuoc = TenThuoc;
                thuocbvtv.LoaiThuoc = LoaiThuoc;
                thuocbvtv.MoTa = MoTa;
                thuocbvtv.NgaySanXuat = NgaySanXuat;
                thuocbvtv.NgayHetHan = NgayHetHan;
                DataProvider.Ins.DB.SaveChanges();
            });
            DeleteCommand = new RelayCommand<object>((p) =>
            {
                MainWindow mainWindow = new MainWindow();
                var MainVM = mainWindow.DataContext as MainViewModel;
                if (MainVM.isadmin)
                {
                    if (string.IsNullOrEmpty(TenThuoc) || string.IsNullOrEmpty(LoaiThuoc) || string.IsNullOrEmpty(MoTa) || NgaySanXuat == null || NgayHetHan == null)
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
                var tenthuoc = SelectedThuocBVTV;
                if(SelectedThuocBVTV != null)
                {
                    ThuocBVTVList.Remove(SelectedThuocBVTV);
                    DataProvider.Ins.DB.ThuocBVTV.Remove(tenthuoc);
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
                string searchTen = TenThuoc;
                string searchMa = LoaiThuoc;
                DateTime? searchNgay = NgaySanXuat;
                DateTime? searchNgay2 = NgayHetHan;
                if (searchMa != null || searchTen != null || searchNgay != null || searchNgay2 != null)
                {
                    foreach (var item in ThuocBVTVList)
                    {
                        if (item.TenThuoc.Contains(searchTen) || item.LoaiThuoc.Contains(searchMa) || item.NgaySanXuat.Equals(searchNgay) || item.NgayHetHan.Equals(searchNgay2) ) SelectedThuocBVTV = item;
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
