using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;

namespace adc.View
{
    public partial class ThongKeCay : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        // Các thuộc tính cho biểu đồ
        public SeriesCollection SeriesCollection { get; set; }
        public List<string> Labels { get; set; }
        public Func<double, string> Formatter { get; set; }

        public ThongKeCay()
        {
            InitializeComponent();

            // Khởi tạo dữ liệu cho biểu đồ 3 cột ghép
            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Giống cây chính",
                    Values = new ChartValues<double> { 2000, 1500, 1800, 1200, 1700, 2500, 3000, 5000 },
                    Fill = new SolidColorBrush(Colors.Red) // Màu cho cột giống cây chính
                },
                new ColumnSeries
                {
                    Title = "Giống lưu hành",
                    Values = new ChartValues<double> { 1500, 1300, 1600, 900, 1200, 2200, 2500, 4500 },
                    Fill = new SolidColorBrush(Colors.Green) // Màu cho cột giống lưu hành
                },
                new ColumnSeries
                {
                    Title = "Cây/Vườn đầu dòng",
                    Values = new ChartValues<double> { 800, 1000, 700, 500, 900, 1500, 2000, 3500 },
                    Fill = new SolidColorBrush(Colors.Blue) // Màu cho cột cây/vườn đầu dòng
                }
            };

            // Khởi tạo dữ liệu Labels cho trục X
            Labels = new List<string> { "Bắc Ninh", "Yên Phong", "Quế Võ", "Tiên Du", "Từ Sơn", "Thuận Thành", "Gia Bình", "Lương Tài" };

            // Định dạng nhãn cho trục Y (ví dụ định dạng thành tiền tệ)
            Formatter = value => value.ToString("C");

            // Gán DataContext để binding dữ liệu trong XAML
            DataContext = this;
        }

        // Phương thức thông báo khi có sự thay đổi của thuộc tính
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}