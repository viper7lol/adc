using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using adc.Model;

namespace adc.ViewModel
{
    public class VungTrongViewModel:BaseViewModel
    {
            private ObservableCollection<VungTrong> _VungTrongList;
            public ObservableCollection<VungTrong> VungTrongList { get => _VungTrongList; set { _VungTrongList = value; OnPropertyChanged(); } }
        public VungTrongViewModel()
        {
            VungTrongList = new ObservableCollection<VungTrong>(DataProvider.Ins.DB.VungTrong);
        }
    }
}
