using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;

namespace adc.ViewModel
{
    /// <summary>
    /// Lớp BaseViewModel triển khai INotifyPropertyChanged để hỗ trợ ràng buộc thuộc tính trong mô hình MVVM.
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Kích hoạt sự kiện PropertyChanged để thông báo cho giao diện người dùng về sự thay đổi thuộc tính.
        /// </summary>
        /// <param name="propertyName">Tên của thuộc tính bị thay đổi.</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Cập nhật giá trị của thuộc tính và kích hoạt sự kiện PropertyChanged nếu giá trị thay đổi.
        /// </summary>
        /// <typeparam name="T">Kiểu của thuộc tính.</typeparam>
        /// <param name="field">Trường (biến) lưu giá trị thuộc tính.</param>
        /// <param name="value">Giá trị mới cho thuộc tính.</param>
        /// <param name="propertyName">Tên của thuộc tính.</param>
        /// <returns>True nếu giá trị đã thay đổi; ngược lại là False.</returns>
        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }

    /// <summary>
    /// Lớp RelayCommand được sử dụng để xử lý các lệnh trong mô hình MVVM.
    /// </summary>
    /// <typeparam name="T">Kiểu của tham số lệnh.</typeparam>
     class RelayCommand<T> : ICommand
    {
        private readonly Predicate<T> _canExecute;
        private readonly Action<T> _execute;

        public RelayCommand(Predicate<T> canExecute, Action<T> execute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");
            _canExecute = canExecute;
            _execute = execute;
        }

        /// <summary>
        /// Xác định liệu lệnh có thể thực thi hay không.
        /// </summary>
        /// <param name="parameter">Tham số của lệnh.</param>
        /// <returns>True nếu lệnh có thể thực thi; ngược lại là False.</returns>
        public bool CanExecute(object parameter)
        {
            try
            {
                return _canExecute == null || _canExecute((T)parameter);
            }
            catch
            {
                return true; // Xử lý lỗi chuyển đổi kiểu tham số một cách an toàn
            }
        }

        /// <summary>
        /// Thực thi lệnh.
        /// </summary>
        /// <param name="parameter">Tham số của lệnh.</param>
        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }

        /// <summary>
        /// Sự kiện xảy ra khi các thay đổi ảnh hưởng đến việc lệnh có thể thực thi hay không.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}