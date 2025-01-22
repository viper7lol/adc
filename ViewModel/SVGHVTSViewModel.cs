using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using adc.Model;

namespace adc.ViewModel
{
    public class SVGHVTSViewModel:BaseViewModel
    {
        private ObservableCollection<SinhVatGayHaiVaTuoiSau> _SVGHVTSList;
        public ObservableCollection<SinhVatGayHaiVaTuoiSau> SVGHVTSList { get => _SVGHVTSList; set { _SVGHVTSList = value; OnPropertyChanged(); } }
        public SVGHVTSViewModel()
        {
            SVGHVTSList = new ObservableCollection<SinhVatGayHaiVaTuoiSau>(DataProvider.Ins.DB.SinhVatGayHaiVaTuoiSau);
        }
    }
}
