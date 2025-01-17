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
    public class CoSoPBViewModel:BaseViewModel
    {
        private ObservableCollection<CoSo> _CoSoList;
        public ObservableCollection<CoSo> CoSoList { get => _CoSoList; set { _CoSoList = value; OnPropertyChanged(); } }
        private CoSo _SelectedCoSo;
        public CoSo SelectedCoSo { get => _SelectedCoSo; 
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
            CoSoList = new ObservableCollection<CoSo>(DataProvider.Ins.DB.CoSo);
            AddCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(TenCoSo) || string.IsNullOrEmpty(DiaChi) || string.IsNullOrEmpty(MaHanhChinh))
                {
                    return false;
                }
                var cosolist = DataProvider.Ins.DB.CoSo.Where(x => x.MaCoSo == MaCoSo);
                if(cosolist == null || cosolist.Count() != 0)
                {
                    return false;
                }
                return true;

            }, (P) => {
                var coso = new CoSo() { MaCoSo = MaCoSo, TenCoSo = TenCoSo, DiaChi = DiaChi, MaHanhChinh = MaHanhChinh };
                DataProvider.Ins.DB.CoSo.Add(coso);
                DataProvider.Ins.DB.SaveChanges();
                CoSoList.Add(coso);
            });
        }
    }
}
