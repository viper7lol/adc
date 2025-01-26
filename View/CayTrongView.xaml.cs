using adc.ViewModel;
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

namespace adc.View
{
    /// <summary>
    /// Interaction logic for CayTrongView.xaml
    /// </summary>
    public partial class CayTrongView : Window
    {
        private CayTrongViewModel CTVM;
        public CayTrongView()
        {
            InitializeComponent();
            CTVM = new CayTrongViewModel();
            DataContext = CTVM;
            CTVM.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == nameof(CTVM.SelectedGiongCayTrong))
                {
                    if (CTVM.SelectedGiongCayTrong != null)
                    {
                        {
                            ListViewControll.ScrollIntoView(CTVM.SelectedGiongCayTrong);
                        }
                    }
                }
            };
        }
    }
}
