using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using adc.Model;

namespace adc.ViewModel
{
    public class VietGapViewModel:BaseViewModel
    {
        private ObservableCollection<CoSoATTP> _CoSoList;
        public ObservableCollection<CoSoATTP> CoSoList { get => _CoSoList; set { _CoSoList = value; OnPropertyChanged(); } }
        public VietGapViewModel() {
            CoSoList = new ObservableCollection<CoSoATTP>(DataProvider.Ins.DB.CoSoATTP);
        }
    }
}
