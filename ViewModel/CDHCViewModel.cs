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


namespace adc.ViewModel
{
    public class CDHCViewModel:LoginViewModel
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
            AddCommand = new RelayCommand<object>((p) =>
            {
                if (IsAdmin) {
                    return true;
                }
                else
                {
                    return false;
                }
            }, (p) =>
            {
                var capdo = new CapDoHanhChinh() { TenCapDo = TenCapDo };
                DataProvider.Ins.DB.CapDoHanhChinh.Add(capdo);
                DataProvider.Ins.DB.SaveChanges();
                CapDoList.Add(capdo);
            });
            EditCommand = new RelayCommand<object>((p) =>
            {

                if (string.IsNullOrEmpty(TenCapDo))
                {
                    return false;
                }
                var capdolist = DataProvider.Ins.DB.CapDoHanhChinh.Where(x => x.TenCapDo == TenCapDo);
                if (capdolist != null || capdolist.Count() != 0)
                {
                    return true;
                }
                return true;
            }, (p) =>
            {
                var capdohanhchinh = DataProvider.Ins.DB.CapDoHanhChinh.Where(x => x.ID == SelectedCapDo.ID).SingleOrDefault();
                capdohanhchinh.TenCapDo = TenCapDo;
                DataProvider.Ins.DB.SaveChanges();
            });
            DeleteCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(TenCapDo))
                {
                    return false;
                }
                var capdolist = DataProvider.Ins.DB.CapDoHanhChinh.Where(x => x.TenCapDo == TenCapDo);
                if (capdolist != null || capdolist.Count() != 0)
                {
                    return true;
                }
                return true;
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
