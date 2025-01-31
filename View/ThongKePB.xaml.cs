using LiveCharts.Wpf;
using LiveCharts;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;
using System;

namespace adc.View
{
    public partial class ThongKePB : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public SeriesCollection SeriesCollection { get; set; }
        public List<string> Labels { get; set; }
        public Func<double, string> Formatter { get; set; }

        public ThongKePB()
        {
            InitializeComponent();

            // Dữ liệu thống kê cho từng cơ sở
            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Nhà máy Hà Gianh - Bắc Ninh",
                    Values = new ChartValues<double> { 15000, 12000, 13000, 11000, 14000, 16000, 15000, 14000, 15000, 13000, 14000, 15000 },
                    Fill = Brushes.Transparent,
                    Stroke = new SolidColorBrush(Color.FromRgb(255, 128, 128)), // Đỏ pastel
                    StrokeThickness = 2,
                    PointGeometry = DefaultGeometries.Circle,
                    PointGeometrySize = 10
                },
                new LineSeries
                {
                    Title = "SenAgri - Bắc Ninh",
                    Values = new ChartValues<double> { 25000, 22000, 21000, 23000, 24000, 27000, 26000, 25000, 26000, 24000, 25000, 26000 },
                    Fill = Brushes.Transparent,
                    Stroke = new SolidColorBrush(Color.FromRgb(128, 255, 128)), // Xanh lá pastel
                    StrokeThickness = 2,
                    PointGeometry = DefaultGeometries.Circle,
                    PointGeometrySize = 10
                },
                new LineSeries
                {
                    Title = "Nhà máy Phú Bình",
                    Values = new ChartValues<double> { 17000, 15000, 16000, 14000, 15000, 18000, 17000, 16000, 17000, 15000, 16000, 17000 },
                    Fill = Brushes.Transparent,
                    Stroke = new SolidColorBrush(Color.FromRgb(128, 179, 255)), // Xanh dương pastel
                    StrokeThickness = 2,
                    PointGeometry = DefaultGeometries.Circle,
                    PointGeometrySize = 10
                },
                new LineSeries
                {
                    Title = "Cường Thịnh",
                    Values = new ChartValues<double> { 18000, 16000, 15000, 17000, 16000, 19000, 18000, 17000, 18000, 16000, 17000, 18000 },
                    Fill = Brushes.Transparent,
                    Stroke = new SolidColorBrush(Color.FromRgb(255, 204, 128)), // Cam pastel
                    StrokeThickness = 2,
                    PointGeometry = DefaultGeometries.Circle,
                    PointGeometrySize = 10
                },
                new LineSeries
                {
                    Title = "Đại Thành",
                    Values = new ChartValues<double> { 13000, 11000, 12000, 10000, 13000, 15000, 14000, 13000, 14000, 12000, 13000, 14000 },
                    Fill = Brushes.Transparent,
                    Stroke = new SolidColorBrush(Color.FromRgb(204, 153, 255)), // Tím pastel
                    StrokeThickness = 2,
                    PointGeometry = DefaultGeometries.Circle,
                    PointGeometrySize = 10
                },
                new LineSeries
                {
                    Title = "Hoàng Minh",
                    Values = new ChartValues<double> { 12000, 10000, 11000, 9000, 11000, 13000, 12000, 11000, 12000, 10000, 11000, 12000 },
                    Fill = Brushes.Transparent,
                    Stroke = new SolidColorBrush(Color.FromRgb(255, 153, 204)), // Hồng pastel
                    StrokeThickness = 2,
                    PointGeometry = DefaultGeometries.Circle,
                    PointGeometrySize = 10
                }
            };

            Labels = new List<string>
            {
                "2024-01", "2024-02", "2024-03", "2024-04", "2024-05", "2024-06",
                "2024-07", "2024-08", "2024-09", "2024-10", "2024-11", "2024-12"
            };

            Formatter = value => value.ToString("N0");

            DataContext = this;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
