using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using adc.Model;
using System.Windows.Input;
using System.Configuration;
using System.Windows;

namespace adc.ViewModel
{
    public class QLNDViewModel:BaseViewModel
    {
        private ObservableCollection<NguoiDung> _NguoiDungList;
        public ObservableCollection<NguoiDung> NguoiDungList { get => _NguoiDungList; set { _NguoiDungList = value; OnPropertyChanged(); } }

        private NguoiDung _SelectedNguoiDung;
        public NguoiDung SelectedNguoiDung
        {
            get => _SelectedNguoiDung;
            set
            {
                _SelectedNguoiDung = value; OnPropertyChanged();
                if (SelectedNguoiDung != null)
                {
                    ID = SelectedNguoiDung.ID;
                    TenNguoiDung = SelectedNguoiDung.TenNguoiDung;
                    Email = SelectedNguoiDung.Email;
                    MatKhau = SelectedNguoiDung.MatKhau;
                    VaiTroID = SelectedNguoiDung.VaiTroID;
                    TrangThai = SelectedNguoiDung.TrangThai;
                    DonViHanhChinhID = SelectedNguoiDung.DonViHanhChinhID;
                }
            }
        }

        public int ID { get; set; }
        private string _TenNguoiDung;
        public string TenNguoiDung { get => _TenNguoiDung; set { _TenNguoiDung = value; OnPropertyChanged(); } }
        private string _Email;
        public string Email { get => _Email; set { _Email = value; OnPropertyChanged(); } }
        private string _MatKhau;
        public string MatKhau { get => _MatKhau; set { _MatKhau = value; OnPropertyChanged(); } }
        private int? _VaiTroID;
        public int? VaiTroID { get => _VaiTroID; set { _VaiTroID = value; OnPropertyChanged(); } }
        private byte _TrangThai;
        public byte TrangThai { get => _TrangThai; set { _TrangThai = value; OnPropertyChanged(); } }
        private string _DonViHanhChinhID;
        public string DonViHanhChinhID { get => _DonViHanhChinhID; set { _DonViHanhChinhID = value; OnPropertyChanged(); } }

        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public QLNDViewModel()
        {
            NguoiDungList = new ObservableCollection<NguoiDung>(DataProvider.Ins.DB.NguoiDung);
            EditCommand = new RelayCommand<object>((p) =>
            {
                MainWindow mainWindow = new MainWindow();
                var MainVM = mainWindow.DataContext as MainViewModel;
                if (MainVM.isadmin)
                {
                    if (string.IsNullOrEmpty(TenNguoiDung) || string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(MatKhau) || VaiTroID == 0 || TrangThai == 0 || string.IsNullOrEmpty(DonViHanhChinhID))
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
                var nd = DataProvider.Ins.DB.NguoiDung.Where(x => x.TenNguoiDung == SelectedNguoiDung.TenNguoiDung).SingleOrDefault();
                nd.ID = ID;
                nd.TenNguoiDung = TenNguoiDung;
                nd.Email = Email;
                nd.MatKhau = MatKhau;
                nd.VaiTroID = VaiTroID;
                nd.TrangThai = TrangThai;
                nd.DonViHanhChinhID = DonViHanhChinhID;
                DataProvider.Ins.DB.SaveChanges();
            });
            DeleteCommand = new RelayCommand<object>((p) =>
            {
                MainWindow mainWindow = new MainWindow();
                var MainVM = mainWindow.DataContext as MainViewModel;
                if (MainVM.isadmin)
                {
                    if (string.IsNullOrEmpty(TenNguoiDung) || string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(MatKhau) || VaiTroID == 0 || TrangThai == 0 || string.IsNullOrEmpty(DonViHanhChinhID))
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
                var tennd = SelectedNguoiDung;
                if (SelectedNguoiDung != null)
                {
                    NguoiDungList.Remove(SelectedNguoiDung);
                    DataProvider.Ins.DB.NguoiDung.Remove(tennd);
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
                string searchTen = TenNguoiDung;
                string searchE = Email;
                if (searchTen != null || searchE != null)
                {
                    foreach (var item in NguoiDungList)
                    {
                        if (item.TenNguoiDung.Contains(searchTen) || item.Email.Contains(searchE)) SelectedNguoiDung = item;
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
