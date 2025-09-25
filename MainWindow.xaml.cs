using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Terminplaner
{
    public partial class MainWindow : Window
    {
        private DateTime currentDate;
        private Button _selectedButton;

        private void UpdateAppointmentList()
        {
            AppointmentListBox.Items.Clear();
            var appointments = Terminplaner.repository.AppointmentRepository.GetAppointmentsByDate(DateOnly.FromDateTime(currentDate));
            foreach (var appt in appointments)
            {
                AppointmentListBox.Items.Add($"{appt.name} \t {appt.startTime:hh\\:mm} - {appt.endTime:hh\\:mm}");
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            currentDate = DateTime.Today;
            UpdateMonthYearHeader();
            SelectedDateHeader.Text = currentDate.ToString("dd.MM.yyyy");
            BuildCalendar(currentDate);
            UpdateAppointmentList();
            PrevMonthButton.Click += PrevMonthButton_Click;
            NextMonthButton.Click += NextMonthButton_Click;
            CreateAppointmentButton.Click += CreateAppointmentButton_Click;
        }

        private void UpdateMonthYearHeader()
        {
            MonthYearHeader.Text = currentDate.ToString("MMMM • yyyy");
        }

        private void BuildCalendar(DateTime month)
        {
            for (int i = CustomCalendar.Children.Count - 1; i >= 7; i--)
            {
                if (CustomCalendar.Children[i] is Button)
                    CustomCalendar.Children.RemoveAt(i);
            }

            var currentDayOfMonth = new DateTime(month.Year, month.Month, 1);
            _selectedButton = null;

            for (int i = 1; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if ((int)currentDayOfMonth.DayOfWeek == j && currentDayOfMonth.Month == month.Month)
                    {
                        var btn = new Button
                        {
                            Content = currentDayOfMonth.Day.ToString(),
                            Margin = new Thickness(2),
                            HorizontalAlignment = HorizontalAlignment.Stretch,
                            VerticalAlignment = VerticalAlignment.Stretch,
                            Background = Brushes.White
                        };
                        
                        var buttonDate = currentDayOfMonth;
                        btn.Click += (s, e) => DayClicked(buttonDate, btn);

                        int row = i + 1;
                        int col = j;
                        Grid.SetRow(btn, row);
                        Grid.SetColumn(btn, col);
                        CustomCalendar.Children.Add(btn);

                        if (buttonDate.Date == DateTime.Today)
                        {
                            btn.Background = Brushes.DodgerBlue;
                            btn.Foreground = Brushes.White;
                            _selectedButton = btn;
                        }

                        currentDayOfMonth = currentDayOfMonth.AddDays(1);
                    }
                }
            }
        }

        private void DayClicked(DateTime date, Button btn)
        {
            if (_selectedButton != null)
            {
                _selectedButton.Background = Brushes.White;
                _selectedButton.Foreground = Brushes.Black;
            }

            btn.Background = Brushes.DodgerBlue;
            btn.Foreground = Brushes.White;
            _selectedButton = btn;

            currentDate = date;
            SelectedDateHeader.Text = date.ToString("dd.MM.yyyy");
            UpdateAppointmentList();
        }

        private void PrevMonthButton_Click(object sender, RoutedEventArgs e)
        {
            currentDate = currentDate.AddMonths(-1);
            UpdateMonthYearHeader();
            BuildCalendar(currentDate);
            UpdateAppointmentList();
        }

        private void NextMonthButton_Click(object sender, RoutedEventArgs e)
        {
            currentDate = currentDate.AddMonths(1);
            UpdateMonthYearHeader();
            BuildCalendar(currentDate);
            UpdateAppointmentList();
        }

        private void CreateAppointmentButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new AppointmentCreatorWindow();
            dialog.Owner = this;
            dialog.ShowDialog();
        }
    }
}
