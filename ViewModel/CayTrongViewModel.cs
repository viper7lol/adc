using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using adc.Model;
using System.Windows.Input;

namespace adc.ViewModel
{
    public class CayTrongViewModel:BaseViewModel
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
                    MaCayTrong = SelectedGiongCayTrong.MaCayTrong;
                    TenGiongCay = SelectedGiongCayTrong.TenGiongCay;
                    LoaiCayTrongID = SelectedGiongCayTrong.LoaiCayTrongID;
                    MoTa = SelectedGiongCayTrong.MoTa;
                    VungTrongID = SelectedGiongCayTrong.VungTrongID;
                }
            }
        }
        private int _MaCayTrong;
        public int MaCayTrong { get => _MaCayTrong; set { _MaCayTrong= value; OnPropertyChanged(); } }
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
        public CayTrongViewModel()
        {
            GiongCayTrongList = new ObservableCollection<GiongCayTrong>(DataProvider.Ins.DB.GiongCayTrongs);
            AddCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                var giongcaytrong = new GiongCayTrong() { MaCayTrong = MaCayTrong, TenGiongCay = TenGiongCay, LoaiCayTrongID = LoaiCayTrongID, MoTa = MoTa, VungTrongID = VungTrongID };
                DataProvider.Ins.DB.GiongCayTrongs.Add(giongcaytrong);
                DataProvider.Ins.DB.SaveChanges();
                GiongCayTrongList.Add(giongcaytrong);
            }
            );
            EditCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(TenGiongCay) || string.IsNullOrEmpty(MoTa))
                {
                    return false;
                }
                var giongcaylist = DataProvider.Ins.DB.GiongCayTrongs.Where(x => x.TenGiongCay == TenGiongCay);
                if (giongcaylist != null || giongcaylist.Count() != 0)
                {
                    return true;
                }
                return true;
            }, (p) =>
            {
                var giongcaytrong = DataProvider.Ins.DB.DonViHanhChinhs.Where(x => x.MaDonVi == SelectedDonVi.MaDonVi).SingleOrDefault();
                donvihanhchinh.MaDonVi = MaDonVi;
                donvihanhchinh.TenDonVi = TenDonVi;
                donvihanhchinh.CapDoID = CapDoID;
                DataProvider.Ins.DB.SaveChanges();
            });
        }
    }
}
