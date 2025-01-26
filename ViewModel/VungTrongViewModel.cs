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
    public class VungTrongViewModel:BaseViewModel
    {
            private ObservableCollection<VungTrong> _VungTrongList;
            public ObservableCollection<VungTrong> VungTrongList { get => _VungTrongList; set { _VungTrongList = value; OnPropertyChanged(); } }
        private VungTrong _SelectedVungTrong;
        public VungTrong SelectedVungTrong
        {
            get => _SelectedVungTrong;
            set
            {
                _SelectedVungTrong = value;
                OnPropertyChanged();
                if (SelectedVungTrong != null)
                {
                    ID = SelectedVungTrong.ID;
                    TenVungTrong = SelectedVungTrong.TenVungTrong;
                    MoTa = SelectedVungTrong.MoTa;
                    MaVungTrongID = SelectedVungTrong.MaVungTrongID;
                }
            }
        }

        private int _ID;
        public int ID { get => _ID; set {  _ID = value; OnPropertyChanged(); } }
        private string _TenVungTrong;
        public string TenVungTrong { get => _TenVungTrong; set { _TenVungTrong = value; OnPropertyChanged(); } }
        private string _MoTa;
        public string MoTa { get => _MoTa; set { _MoTa = value; OnPropertyChanged(); } }
        private string _MaVungTrongID;
        public string MaVungTrongID { get => _MaVungTrongID; set { _MaVungTrongID= value; OnPropertyChanged(); } }
        
        public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public VungTrongViewModel()
        {
            VungTrongList = new ObservableCollection<VungTrong>(DataProvider.Ins.DB.VungTrong);
            AddCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                var vungtrong = new VungTrong() { ID = ID, TenVungTrong = TenVungTrong, MoTa = MoTa, MaVungTrongID = MaVungTrongID};
                DataProvider.Ins.DB.VungTrong.Add(vungtrong);
                DataProvider.Ins.DB.SaveChanges();
                VungTrongList.Add(vungtrong);
            }
           );
            EditCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(TenVungTrong) || string.IsNullOrEmpty(MoTa))
                {
                    return false;
                }
                var vunglist = DataProvider.Ins.DB.VungTrong.Where(x => x.TenVungTrong == TenVungTrong);
                if (vunglist != null || vunglist.Count() != 0)
                {
                    return true;
                }
                return true;
            }, (p) =>
            {
                SelectedVungTrong.TenVungTrong = TenVungTrong;
                SelectedVungTrong.MaVungTrongID = MaVungTrongID;
                SelectedVungTrong.MoTa = MoTa;
                DataProvider.Ins.DB.SaveChanges();
            });
            SearchCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                string searchTen = TenVungTrong;
                string searchMa = MaVungTrongID;
                if (searchTen != null && searchMa != null)
                {
                    foreach (var item in VungTrongList)
                    {
                        if (item.TenVungTrong.Contains(searchTen) && item.MaVungTrongID.Contains(searchMa)) SelectedVungTrong = item;
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy kết quả nào.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            });
            DeleteCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(TenVungTrong))
                {
                    return false;
                }
                var vungtronglist = DataProvider.Ins.DB.VungTrong.Where(x => x.TenVungTrong == TenVungTrong);
                if (vungtronglist != null || vungtronglist.Count() != 0)
                {
                    return true;
                }
                return true;
            }, (p) =>
            {
                
                if (SelectedVungTrong != null)
                {
                    var vungtrong = SelectedVungTrong;
                    VungTrongList.Remove(SelectedVungTrong);
                    DataProvider.Ins.DB.VungTrong.Remove(vungtrong);
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
