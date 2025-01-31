using System.Windows;
using LiveCharts;
using LiveCharts.Wpf;
using System.Windows.Media;

namespace adc.View
{
    public partial class ThongKeVungTrong : Window
    {
        public ThongKeVungTrong()
        {
            InitializeComponent();
            DataContext = new PieChartViewModel();
        }
    }

    public class PieChartViewModel
    {
        public SeriesCollection SeriesCollection { get; set; }

        public PieChartViewModel()
        {
            // Dữ liệu mẫu với màu sắc đặc biệt cho "Vùng trồng cây ăn quả" màu đỏ
            SeriesCollection = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "Vùng trồng cây ăn quả",
                    Values = new ChartValues<double> {30},
                    DataLabels = true,
                    Fill = new SolidColorBrush(Color.FromRgb(255, 0, 0)) // Red color for Fruit Planting Area
                },
                new PieSeries
                {
                    Title = "Vùng trồng rau củ quả",
                    Values = new ChartValues<double> {20},
                    DataLabels = true,
                    Fill = new SolidColorBrush(Color.FromRgb(34, 139, 34)) // Bold Forest Green
                },
                new PieSeries
                {
                    Title = "Vùng trồng hoa và cây cảnh",
                    Values = new ChartValues<double> {25},
                    DataLabels = true,
                    Fill = new SolidColorBrush(Color.FromRgb(255, 140, 0)) // Bold Orange
                },
                new PieSeries
                {
                    Title = "Vùng trồng dược liệu",
                    Values = new ChartValues<double> {15},
                    DataLabels = true,
                    Fill = new SolidColorBrush(Color.FromRgb(0, 128, 255)) // Bold Deep Sky Blue
                },
                new PieSeries
                {
                    Title = "Vùng trồng cây công nghiệp ngắn ngày",
                    Values = new ChartValues<double> {10},
                    DataLabels = true,
                    Fill = new SolidColorBrush(Color.FromRgb(255, 215, 0)) // Bold Gold
                }
            };
        }
    }
}
