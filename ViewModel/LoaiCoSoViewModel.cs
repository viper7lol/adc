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
        private ObservableCollection<LoaiCoSo> _LoaiCoSoList;
        public ObservableCollection<LoaiCoSo> LoaiCoSoList { get => _LoaiCoSoList; set { _LoaiCoSoList = value; OnPropertyChanged(); } }

        private LoaiCoSo _SelectedLoaiCoSo;
        public LoaiCoSo SelectedLoaiCoSo
        {
            get => _SelectedLoaiCoSo;
            set
            {
                _SelectedLoaiCoSo = value;
                OnPropertyChanged();
                if(SelectedLoaiCoSo != null)
                {
                    ID = SelectedLoaiCoSo.ID;
                    TenLoaiCoSo = SelectedLoaiCoSo.TenLoaiCoSo;
                }
            }
        }

        private int _ID;
        public int ID { get => _ID; set {  _ID = value; OnPropertyChanged(); } }
        private string _TenLoaiCoSo;
        public string TenLoaiCoSo { get => _TenLoaiCoSo; set { _TenLoaiCoSo = value; OnPropertyChanged(); } }

        public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand EditCommand { get; set; }  

        public LoaiCoSoViewModel()
        {
            LoaiCoSoList = new ObservableCollection<LoaiCoSo>(DataProvider.Ins.DB.LoaiCoSo);
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
                var lcs = new LoaiCoSo() { ID = ID, TenLoaiCoSo = TenLoaiCoSo};
                if (TenLoaiCoSo != null)
                {
                    DataProvider.Ins.DB.LoaiCoSo.Add(lcs);
                    DataProvider.Ins.DB.SaveChanges();
                    LoaiCoSoList.Add(lcs);
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
                    if (string.IsNullOrEmpty(TenLoaiCoSo))
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
                var loaics = DataProvider.Ins.DB.LoaiCoSo.Where(x => x.ID == SelectedLoaiCoSo.ID).SingleOrDefault();
                loaics.ID = ID;
                loaics.TenLoaiCoSo = TenLoaiCoSo;
                DataProvider.Ins.DB.SaveChanges();
            });
            DeleteCommand = new RelayCommand<object>((p) =>
            {
                MainWindow mainWindow = new MainWindow();
                var MainVM = mainWindow.DataContext as MainViewModel;
                if (MainVM.isadmin)
                {
                    if (string.IsNullOrEmpty(TenLoaiCoSo))
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
                var ten = SelectedLoaiCoSo;
                if(SelectedLoaiCoSo != null)
                {
                    LoaiCoSoList.Remove(SelectedLoaiCoSo);
                    DataProvider.Ins.DB.LoaiCoSo.Remove(ten);
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
