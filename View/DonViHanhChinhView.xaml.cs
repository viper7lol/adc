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
    /// Interaction logic for DonViHanhChinhView.xaml
    /// </summary>
    public partial class DonViHanhChinhView : Window
    {
        private DVHCViewModel DVHCVM;
        public DonViHanhChinhView()
        {
            InitializeComponent();
            DVHCVM = new DVHCViewModel();
            DataContext = DVHCVM;
            DVHCVM.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == nameof(DVHCVM.SelectedDonVi))
                {
                    if (DVHCVM.SelectedDonVi != null)
                    {
                        {
                            ListViewControll.ScrollIntoView(DVHCVM.SelectedDonVi);
                        }
                    }
                }
            };
        }
    }
}
