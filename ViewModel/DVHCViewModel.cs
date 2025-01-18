using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using adc.Model;
using System.Windows.Input;
using System.Windows;
using adc.View;

namespace adc.ViewModel
{
    public class DVHCViewModel : BaseViewModel
    {
        private ObservableCollection<DonViHanhChinh> _DonViList;
        public ObservableCollection<DonViHanhChinh> DonViList { get => _DonViList; set { _DonViList = value; OnPropertyChanged(); } }
        private DonViHanhChinh _SelectedDonVi;
        public DonViHanhChinh SelectedDonVi
        {
            get => _SelectedDonVi;
            set
            {
                _SelectedDonVi = value;
                OnPropertyChanged();
                if (SelectedDonVi != null)
                {
                    MaDonVi = SelectedDonVi.MaDonVi;
                    TenDonVi = SelectedDonVi.TenDonVi;
                    CapDoID = SelectedDonVi.CapDoID;
                    CapTrenID = SelectedDonVi.CapTrenID;
                }
                
            }
        }
        private string _MaDonVi;
        public string MaDonVi { get => _MaDonVi; set { _MaDonVi = value; OnPropertyChanged(); } }
        private string _TenDonVi;
        public string TenDonVi { get => _TenDonVi; set { _TenDonVi = value; OnPropertyChanged(); } }
        private int _CapDoID;
        public int CapDoID { get => _CapDoID; set { _CapDoID = value; OnPropertyChanged(); } }
        private string _CapTrenID;
        public string CapTrenID { get => _CapTrenID; set { _CapTrenID = value; OnPropertyChanged(); } }

        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public DVHCViewModel()
        {
            DonViList = new ObservableCollection<DonViHanhChinh>(DataProvider.Ins.DB.DonViHanhChinh);
            AddCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                var donvi = new DonViHanhChinh() { MaDonVi = MaDonVi, TenDonVi = TenDonVi, CapDoID = CapDoID, CapTrenID = CapTrenID };
                DataProvider.Ins.DB.DonViHanhChinh.Add(donvi);
                DataProvider.Ins.DB.SaveChanges();
                DonViList.Add(donvi);
            }
            );
            EditCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(MaDonVi) || string.IsNullOrEmpty(TenDonVi) || string.IsNullOrEmpty(CapTrenID))
                {
                    return false;
                }
                var donvilist = DataProvider.Ins.DB.DonViHanhChinh.Where(x => x.MaDonVi == MaDonVi);
                if (donvilist != null || donvilist.Count() != 0)
                {
                    return true;
                }
                return true;
            }, (p) =>
            {
                var donvihanhchinh = DataProvider.Ins.DB.DonViHanhChinh.Where(x => x.MaDonVi == SelectedDonVi.MaDonVi).SingleOrDefault();
                donvihanhchinh.MaDonVi = MaDonVi;
                donvihanhchinh.TenDonVi = TenDonVi;
                donvihanhchinh.CapDoID = CapDoID;
                DataProvider.Ins.DB.SaveChanges();
            });
            SearchCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) => {
                string searchMa = MaDonVi;
                string searchTen = TenDonVi;
                int searchCapDo = CapDoID;
                if (searchMa != null &&searchTen != null &&searchCapDo > 0) {
                    foreach (var item in DonViList) {
                        if (item.MaDonVi.Contains(searchMa) && item.TenDonVi.Contains(searchTen) && item.CapDoID.Equals(searchCapDo)) SelectedDonVi = item;
                    }
                } else
                {
                    MessageBox.Show("Không tìm thấy kết quả nào.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            });
        }
    }
}
