using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using adc.Model;

namespace adc.ViewModel
{
    public class ThuocBVTVViewModel:BaseViewModel
    {
        private ObservableCollection<ThuocBVTV> _ThuocBVTVList;
        public ObservableCollection<ThuocBVTV> ThuocBVTVList { get => _ThuocBVTVList; set { _ThuocBVTVList = value; OnPropertyChanged(); } }
        public ThuocBVTVViewModel()
        {
            ThuocBVTVList = new ObservableCollection<ThuocBVTV>(DataProvider.Ins.DB.ThuocBVTV);
        }
    }
}
