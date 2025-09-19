using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Terminplaner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        private DateTime _currentDate = new DateTime(2025, 1, 1);

        public MainWindow()
        {
            InitializeComponent();
            DateDisplayButton.Content = _currentDate.ToString("dd.MM.yyyy");
            UpdateDateDisplay();
        }

        private void PreviousDate_Click(object sender, RoutedEventArgs e)
        {
            _currentDate = _currentDate.AddDays(-1);
            UpdateDateDisplay();
        }

        private void NextDate_Click(object sender, RoutedEventArgs e)
        {
            _currentDate = _currentDate.AddDays(1);
            UpdateDateDisplay();
        }

        
        private void DateDisplay_Click(object sender, RoutedEventArgs e)
        {
            DatePickerControl.Visibility = Visibility.Visible;
            DatePickerControl.IsDropDownOpen = true;
        }

        private void DatePickerControl_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DatePickerControl.SelectedDate.HasValue)
            {
                _currentDate = DatePickerControl.SelectedDate.Value;
                UpdateDateDisplay();
                DatePickerControl.Visibility = Visibility.Collapsed;
            }
        }


        private void UpdateDateDisplay()
        {
            DateDisplayButton.Content = _currentDate.ToString("dd.MM.yyyy");
        }
    }

}