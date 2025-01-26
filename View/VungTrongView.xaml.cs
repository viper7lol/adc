using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using adc.ViewModel;

namespace adc.View
{
    /// <summary>
    /// Interaction logic for VungTrongView.xaml
    /// </summary>
    public partial class VungTrongView : Window
    {
        private VungTrongViewModel VTVM;
        public VungTrongView()
        {
            InitializeComponent();
            VTVM = new VungTrongViewModel();
            DataContext = VTVM;
            VTVM.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == nameof(VTVM.SelectedVungTrong))
                {
                    if (VTVM.SelectedVungTrong != null)
                    {
                        {
                            ListViewControll.ScrollIntoView(VTVM.SelectedVungTrong);
                        }
                    }
                }
            };
        }
    }
}
