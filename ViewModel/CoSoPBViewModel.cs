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
    public class CoSoPBViewModel : BaseViewModel
    {
        private ObservableCollection<CoSoPB> _CoSoList;
        public ObservableCollection<CoSoPB> CoSoList { get => _CoSoList; set { _CoSoList = value; OnPropertyChanged(); } }
        private CoSoPB _SelectedCoSo;
        public CoSoPB SelectedCoSo
        {
            get => _SelectedCoSo;
            set
            {
                _SelectedCoSo = value;
                OnPropertyChanged();
                if (SelectedCoSo != null)
                {
                    MaCoSo = SelectedCoSo.MaCoSo;
                    TenCoSo = SelectedCoSo.TenCoSo;
                    DiaChi = SelectedCoSo.DiaChi;
                    MaHanhChinh = SelectedCoSo.MaHanhChinh;
                }
            }
        }
        private int _MaCoSo;
        public int MaCoSo { get => _MaCoSo; set { _MaCoSo = value; OnPropertyChanged(); } }
        private string _TenCoSo;
        public string TenCoSo { get => _TenCoSo; set { _TenCoSo = value; OnPropertyChanged(); } }
        private string _DiaChi;
        public string DiaChi { get => _DiaChi; set { _DiaChi = value; OnPropertyChanged(); } }
        private string _MaHanhChinh;
        public string MaHanhChinh { get => _MaHanhChinh; set { _MaHanhChinh = value; OnPropertyChanged(); } }

        public ICommand AddCommand { get; set; }
        public CoSoPBViewModel()
        {
            CoSoList = new ObservableCollection<CoSoPB>(DataProvider.Ins.DB.CoSoPB);
            AddCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(TenCoSo) || string.IsNullOrEmpty(DiaChi) || string.IsNullOrEmpty(MaHanhChinh))
                {
                    return false;
                }
                var cosolist = DataProvider.Ins.DB.CoSoPB.Where(x => x.MaCoSo == MaCoSo);
                if (cosolist == null || cosolist.Count() != 0)
                {
                    return false;
                }
                return true;

            }, (P) =>
            {
                var coso = new CoSoPB() { MaCoSo = MaCoSo, TenCoSo = TenCoSo, DiaChi = DiaChi, MaHanhChinh = MaHanhChinh };
                DataProvider.Ins.DB.CoSoPB.Add(coso);
                DataProvider.Ins.DB.SaveChanges();
                CoSoList.Add(coso);
            });
        }
    }
}
