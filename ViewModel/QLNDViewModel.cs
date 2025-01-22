using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using adc.Model;

namespace adc.ViewModel
{
    public class QLNDViewModel:BaseViewModel
    {
        private ObservableCollection<NguoiDung> _NguoiDungList;
        public ObservableCollection<NguoiDung> NguoiDungList { get => _NguoiDungList; set { _NguoiDungList = value; OnPropertyChanged(); } }
        public QLNDViewModel()
        {
            NguoiDungList = new ObservableCollection<NguoiDung>(DataProvider.Ins.DB.NguoiDung);
        }
    }
}
