using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using adc.Model;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows;
using Microsoft.Identity.Client;
using System.Runtime.InteropServices.WindowsRuntime;


namespace adc.ViewModel
{
    public class CDHCViewModel:MainViewModel
    {
        private ObservableCollection<CapDoHanhChinh> _CapDoList;
        public ObservableCollection<CapDoHanhChinh> CapDoList { get => _CapDoList; set {  _CapDoList = value; OnPropertyChanged(); } }

        private CapDoHanhChinh _SelectedCapDo;
        public CapDoHanhChinh SelectedCapDo
        {
            get => _SelectedCapDo;
            set
            {
                _SelectedCapDo = value;
                OnPropertyChanged();
                if (SelectedCapDo != null)
                {
                    TenCapDo = SelectedCapDo.TenCapDo; 
                }
            }
        }      
        private string _TenCapDo;
        public string TenCapDo { get => _TenCapDo; set { _TenCapDo = value; OnPropertyChanged(); } }
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public CDHCViewModel() {
            CapDoList = new ObservableCollection<CapDoHanhChinh>(DataProvider.Ins.DB.CapDoHanhChinh);
            AddCommand = new RelayCommand<Window>((p) =>
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
                    var capdo = new CapDoHanhChinh() { TenCapDo = TenCapDo };
                if (TenCapDo != null)
                {
                    DataProvider.Ins.DB.CapDoHanhChinh.Add(capdo);
                    DataProvider.Ins.DB.SaveChanges();
                    CapDoList.Add(capdo);
                }
                else
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            });
            EditCommand = new RelayCommand<object>((p) =>
            {
                MainWindow mainWindow = new MainWindow();
                var MainVM = mainWindow.DataContext as MainViewModel;
                if (MainVM.isadmin)
                {
                    if (string.IsNullOrEmpty(TenCapDo))
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
                var capdohanhchinh = DataProvider.Ins.DB.CapDoHanhChinh.Where(x => x.ID == SelectedCapDo.ID).SingleOrDefault();
                capdohanhchinh.TenCapDo = TenCapDo;
                DataProvider.Ins.DB.SaveChanges();
            });
            DeleteCommand = new RelayCommand<object>((p) =>
            {
                MainWindow mainWindow = new MainWindow();
                var MainVM = mainWindow.DataContext as MainViewModel;
                if (MainVM.isadmin)
                {
                    if (string.IsNullOrEmpty(TenCapDo))
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
                var tencapdo = SelectedCapDo;
                CapDoList.Remove(SelectedCapDo);
                DataProvider.Ins.DB.CapDoHanhChinh.Remove(tencapdo);
                DataProvider.Ins.DB.SaveChanges();
            });
            SearchCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                string searchName = TenCapDo;
                if(searchName != null)
                {
                    foreach(var item in CapDoList)
                    {
                        if(item.TenCapDo.Contains(searchName)) SelectedCapDo = item;
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
