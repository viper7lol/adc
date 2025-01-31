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
    public partial class ThongKeThuocBVTV : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        // Properties for the chart
        public SeriesCollection SeriesCollection { get; set; }
        public List<string> Labels { get; set; }
        public Func<double, string> Formatter { get; set; }

        public ThongKeThuocBVTV()
        {
            InitializeComponent();

            // Updated Data for each entity (using consistent and realistic data trends)
            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Công ty TNHH Thuốc BVTV Bắc Ninh",
                    Values = new ChartValues<double> { 13500, 14200, 15000, 14800, 15500, 16000, 15800, 16200 },
                    Stroke = new SolidColorBrush(Color.FromRgb(255, 99, 71)), // Tomato Red
                    Fill = Brushes.Transparent,
                    PointGeometry = DefaultGeometries.Circle,
                    PointGeometrySize = 8,
                    StrokeThickness = 2
                },
                new LineSeries
                {
                    Title = "Cửa hàng Thuốc BVTV Hiệp Phát",
                    Values = new ChartValues<double> { 22500, 23500, 24500, 26000, 27000, 28000, 27500, 29000 },
                    Stroke = new SolidColorBrush(Color.FromRgb(60, 179, 113)), // Medium Sea Green
                    Fill = Brushes.Transparent,
                    PointGeometry = DefaultGeometries.Circle,
                    PointGeometrySize = 8,
                    StrokeThickness = 2
                },
                new LineSeries
                {
                    Title = "Chi nhánh Công ty CP BVTV Trung ương 2 - Bắc Ninh",
                    Values = new ChartValues<double> { 16500, 17000, 16800, 16200, 16000, 17500, 18000, 18500 },
                    Stroke = new SolidColorBrush(Color.FromRgb(100, 149, 237)), // Cornflower Blue
                    Fill = Brushes.Transparent,
                    PointGeometry = DefaultGeometries.Circle,
                    PointGeometrySize = 8,
                    StrokeThickness = 2
                },
                new LineSeries
                {
                    Title = "Cửa hàng BVTV Minh Phát",
                    Values = new ChartValues<double> { 19000, 20000, 19500, 19800, 19000, 20500, 21000, 21500 },
                    Stroke = new SolidColorBrush(Color.FromRgb(255, 165, 0)), // Orange
                    Fill = Brushes.Transparent,
                    PointGeometry = DefaultGeometries.Circle,
                    PointGeometrySize = 8,
                    StrokeThickness = 2
                },
                new LineSeries
                {
                    Title = "Công ty TNHH BVTV Hoàng Gia",
                    Values = new ChartValues<double> { 12500, 13000, 14000, 13700, 14500, 15000, 15500, 16000 },
                    Stroke = new SolidColorBrush(Color.FromRgb(138, 43, 226)), // Blue Violet
                    Fill = Brushes.Transparent,
                    PointGeometry = DefaultGeometries.Circle,
                    PointGeometrySize = 8,
                    StrokeThickness = 2
                },
                new LineSeries
                {
                    Title = "Cửa hàng Thuốc BVTV Hòa Phát",
                    Values = new ChartValues<double> { 11500, 12000, 12500, 13000, 13500, 14000, 14500, 15000 },
                    Stroke = new SolidColorBrush(Color.FromRgb(255, 105, 180)), // Hot Pink
                    Fill = Brushes.Transparent,
                    PointGeometry = DefaultGeometries.Circle,
                    PointGeometrySize = 8,
                    StrokeThickness = 2
                },
                new LineSeries
                {
                    Title = "Công ty TNHH Thuốc BVTV Phú An",
                    Values = new ChartValues<double> { 12500, 13000, 12000, 11800, 13000, 13500, 13800, 14000 },
                    Stroke = new SolidColorBrush(Color.FromRgb(255, 105, 180)), // Hot Pink
                    Fill = Brushes.Transparent,
                    PointGeometry = DefaultGeometries.Circle,
                    PointGeometrySize = 8,
                    StrokeThickness = 2
                },
                 new LineSeries
                {
                    Title = "Cửa hàng BVTV Bắc Nam",
                    Values = new ChartValues<double> { 12000, 12300, 12600, 12900, 13200, 13400, 13700, 14000 },
                    Stroke = new SolidColorBrush(Color.FromRgb(255, 182, 193)), // Light Pink
                    Fill = Brushes.Transparent,
                    PointGeometry = DefaultGeometries.Circle,
                    PointGeometrySize = 8,
                    StrokeThickness = 2
                },
            };

            // List of establishments
            Labels = new List<string>
            {
                "2024-01", "2024-02", "2024-03", "2024-04", "2024-05", "2024-06",
                "2024-07", "2024-08", "2024-09", "2024-10", "2024-11", "2024-12"
            };

            // Formatter for Y-axis
            Formatter = value => value.ToString("N0");

            // Set DataContext for binding
            DataContext = this;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
