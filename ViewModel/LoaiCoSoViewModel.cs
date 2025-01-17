using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using adc.Model;

namespace adc.ViewModel
{
    public class LoaiCoSoViewModel:BaseViewModel
    {
        private ObservableCollection<LoaiCoSo> _LoaiCoSoList;
        public ObservableCollection<LoaiCoSo> LoaiCoSoList { get => _LoaiCoSoList; set { _LoaiCoSoList = value; OnPropertyChanged(); } }
        public LoaiCoSoViewModel()
        {
            LoaiCoSoList = new ObservableCollection<LoaiCoSo>(DataProvider.Ins.DB.LoaiCoSo);
        }
    }
}
