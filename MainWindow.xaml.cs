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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace adc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private bool GiongCayTrongMoRong = false;
        private bool HanhChinhMoRong = false;
        private bool PhanBonMoRong = false;
        private bool ThuocbvtvMoRong = false;
        private bool HeThongMoRong = false;
        private bool TaiKhoanMoRong = false;

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			MyBorder.Background = new ImageBrush(new BitmapImage(new Uri("pack://apllication:,,,/Resources/33.png")));
		}

		private void HanhChinhButton_Click(object sender, RoutedEventArgs e)
        {
            //doi trang thai
            HanhChinhMoRong = !HanhChinhMoRong;
            HanhChinhConButton.Visibility = HanhChinhMoRong ? Visibility.Visible : Visibility.Collapsed;
			MyBorder.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Resources/1.jpg")));
		}
        private void GiongCayTrongButton_Click(object sender, RoutedEventArgs e)
        {
            GiongCayTrongMoRong = !GiongCayTrongMoRong;
            GiongCayTrongConButton.Visibility = GiongCayTrongMoRong ? Visibility.Visible : Visibility.Collapsed;
			MyBorder.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Resources/1.jpg")));
		}
        private void PhanBonButton_Click(object sender, RoutedEventArgs e)
        {
            PhanBonMoRong = !PhanBonMoRong;
            PhanBonConButton.Visibility = PhanBonMoRong ? Visibility.Visible : Visibility.Collapsed;
			MyBorder.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Resources/1.jpg")));
		}
        private void ThuocbvtvButton_Click(object sender, RoutedEventArgs e)
        {
            ThuocbvtvMoRong = !ThuocbvtvMoRong;
            ThuocbvtvButton.Visibility = ThuocbvtvMoRong ? Visibility.Visible : Visibility.Collapsed;
			MyBorder.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Resources/1.jpg")));
		}
        private void HeThongButton_Click(object sender, RoutedEventArgs e)
        {
            HeThongMoRong = !HeThongMoRong;
            HeThongButton.Visibility = HeThongMoRong ? Visibility.Visible : Visibility.Collapsed;
			MyBorder.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Resources/1.jpg")));
		}
        private void TaiKhoanButton_Click(object sender, RoutedEventArgs e)
        {
            TaiKhoanMoRong = !TaiKhoanMoRong;
            TaiKhoanButton.Visibility = TaiKhoanMoRong ? Visibility.Visible : Visibility.Collapsed;
			MyBorder.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Resources/1.jpg")));
		}

		
	}
}
