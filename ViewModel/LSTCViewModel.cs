using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using adc.Model;

namespace adc.ViewModel
{
    public class LSTCViewModel:BaseViewModel
    {
        private ObservableCollection<LichSuTruyCap> _LSTCList;
        public ObservableCollection<LichSuTruyCap> LSTCList { get => _LSTCList; set { _LSTCList = value; OnPropertyChanged(); } }
        public LSTCViewModel()
        {
            LSTCList = new ObservableCollection<LichSuTruyCap>(DataProvider.Ins.DB.LichSuTruyCap);
        }
    }
}
