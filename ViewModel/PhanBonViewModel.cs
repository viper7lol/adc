using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using adc.Model;

namespace adc.ViewModel
{
    public class PhanBonViewModel:BaseViewModel
    {
        private ObservableCollection<PhanBon> _PhanBonList;
        public ObservableCollection<PhanBon> PhanBonList { get => _PhanBonList; set { _PhanBonList = value; OnPropertyChanged(); } }
        public PhanBonViewModel()
        {
            PhanBonList = new ObservableCollection<PhanBon>(DataProvider.Ins.DB.PhanBon);
        }
    }
}
