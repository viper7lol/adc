using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using adc.Model;

namespace adc.ViewModel
{
    public class CayTrongViewModel:BaseViewModel
    {
        private ObservableCollection<GiongCayTrong> _GiongCayTrongList;
        public ObservableCollection<GiongCayTrong> GiongCayTrongList { get => _GiongCayTrongList; set { _GiongCayTrongList = value; OnPropertyChanged(); } }
        public CayTrongViewModel()
        {
            GiongCayTrongList = new ObservableCollection<GiongCayTrong>(DataProvider.Ins.DB.GiongCayTrong);
        }
    }
}
