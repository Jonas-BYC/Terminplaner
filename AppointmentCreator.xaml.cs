using System.Windows;
using System.Windows.Controls;

namespace Terminplaner;

public partial class AppointmentCreator : Page
{
    private DateTime _currentDate = new DateTime(2025, 1, 1);
    
    public AppointmentCreator()
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