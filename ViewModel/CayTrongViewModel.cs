﻿using System;
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
    public class CayTrongViewModel:MainViewModel
    {
        private ObservableCollection<GiongCayTrong> _GiongCayTrongList;
        public ObservableCollection<GiongCayTrong> GiongCayTrongList { get => _GiongCayTrongList; set { _GiongCayTrongList = value; OnPropertyChanged(); } }
        private GiongCayTrong _SelectedGiongCayTrong;
        public GiongCayTrong SelectedGiongCayTrong
        {
            get => _SelectedGiongCayTrong;
            set
            {
                _SelectedGiongCayTrong = value;
                OnPropertyChanged();
                if (SelectedGiongCayTrong != null)
                {
                    TenGiongCay = SelectedGiongCayTrong.TenGiongCay;
                    LoaiCayTrongID = SelectedGiongCayTrong.LoaiCayTrongID;
                    MoTa = SelectedGiongCayTrong.MoTa;
                    VungTrongID = SelectedGiongCayTrong.VungTrongID;
                }
            }
        }
        private string _TenGiongCay;
        public string TenGiongCay { get => _TenGiongCay; set { _TenGiongCay = value; OnPropertyChanged(); } }
        private int? _LoaiCayTrongID;
        public int? LoaiCayTrongID { get => _LoaiCayTrongID; set { _LoaiCayTrongID = value; OnPropertyChanged(); } }
        private string _MoTa;
        public string MoTa { get => _MoTa; set { _MoTa = value; OnPropertyChanged(); } }
        private int? _VungTrongID;
        public int? VungTrongID { get => _VungTrongID; set { _VungTrongID = value; OnPropertyChanged(); } }

        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public CayTrongViewModel()
        {
            GiongCayTrongList = new ObservableCollection<GiongCayTrong>(DataProvider.Ins.DB.GiongCayTrong);
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
                var giongcaytrong = new GiongCayTrong() {TenGiongCay = TenGiongCay, LoaiCayTrongID = LoaiCayTrongID, MoTa = MoTa, VungTrongID = VungTrongID };
                if (TenGiongCay != null && LoaiCayTrongID != 0 && MoTa != null && VungTrongID != 0)
                {
                    DataProvider.Ins.DB.GiongCayTrong.Add(giongcaytrong);
                    DataProvider.Ins.DB.SaveChanges();
                    GiongCayTrongList.Add(giongcaytrong);
                }
                else
                {
                    MessageBox.Show("Vui lòng điền đẩy đủ thông tin !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            );
            EditCommand = new RelayCommand<object>((p) =>
            {
                MainWindow mainWindow = new MainWindow();
                var MainVM = mainWindow.DataContext as MainViewModel;
                if (MainVM.isadmin)
                {
                    if (string.IsNullOrEmpty(TenGiongCay) || string.IsNullOrEmpty(MoTa) || LoaiCayTrongID == 0 || VungTrongID == 0)
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
                var giongcaytrong = DataProvider.Ins.DB.GiongCayTrong.Where(x => x.TenGiongCay == SelectedGiongCayTrong.TenGiongCay).SingleOrDefault();
                giongcaytrong.TenGiongCay = TenGiongCay;
                giongcaytrong.LoaiCayTrongID = LoaiCayTrongID;
                giongcaytrong.VungTrongID = VungTrongID;
                giongcaytrong.MoTa = MoTa;
                DataProvider.Ins.DB.SaveChanges();
            });
            SearchCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                string searchTen = TenGiongCay;
                int? searchLoaiCay = LoaiCayTrongID;
                int? searchVungTrong = VungTrongID;
                if (searchTen != null && searchLoaiCay > 0 && searchVungTrong > 0)
                {
                    foreach (var item in GiongCayTrongList)
                    {
                        if (item.TenGiongCay.Contains(searchTen) && item.LoaiCayTrongID.Equals(searchLoaiCay) && item.VungTrongID.Equals(searchVungTrong)) SelectedGiongCayTrong = item;
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy kết quả nào.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            });
            DeleteCommand = new RelayCommand<object>((p) =>
            {
                MainWindow mainWindow = new MainWindow();
                var MainVM = mainWindow.DataContext as MainViewModel;
                if (MainVM.isadmin)
                {
                    if (string.IsNullOrEmpty(TenGiongCay) || string.IsNullOrEmpty(MoTa) || LoaiCayTrongID == 0 || VungTrongID == 0)
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
                var giongcay = SelectedGiongCayTrong;
                if (SelectedGiongCayTrong != null)
                {
                    GiongCayTrongList.Remove(SelectedGiongCayTrong);
                    DataProvider.Ins.DB.GiongCayTrong.Remove(giongcay);
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
