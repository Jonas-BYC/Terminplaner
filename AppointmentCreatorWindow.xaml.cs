using System.Windows;
using Terminplaner.repository;

namespace Terminplaner
{
    public partial class AppointmentCreatorWindow : Window
    {
        public string AppointmentName => NameBox.Text;
        public DateTime AppointmentDate => DatePickerBox.SelectedDate ?? DateTime.Today;
        public TimeSpan StartTime => TimeSpan.Parse((string)StartTimeCombo.SelectedItem);
        public TimeSpan EndTime => TimeSpan.Parse((string)EndTimeCombo.SelectedItem);

        public AppointmentCreatorWindow()
        {
            InitializeComponent();
            FillTimeCombos();
            OkButton.Click += OkButton_Click;
            CancelButton.Click += (s, e) => DialogResult = false;
        }

        private void FillTimeCombos()
        {
            for (int h = 0; h < 24; h++)
            {
                for (int m = 0; m < 60; m += 15)
                {
                    string time = $"{h:D2}:{m:D2}";
                    StartTimeCombo.Items.Add(time);
                    EndTimeCombo.Items.Add(time);
                }
            }
            StartTimeCombo.SelectedIndex = 32;
            EndTimeCombo.SelectedIndex = 36;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(AppointmentName) || StartTimeCombo.SelectedItem == null || EndTimeCombo.SelectedItem == null || DatePickerBox.SelectedDate == null)
            {
                MessageBox.Show("Bitte alle Felder ausfüllen.", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            DialogResult = true;
            var appointment = new Appointment(
                AppointmentName,
                DateOnly.FromDateTime(AppointmentDate),
                TimeOnly.FromTimeSpan(StartTime),
                TimeOnly.FromTimeSpan(EndTime)
            );
            AppointmentRepository.AddAppointment(appointment);
        }
    }
}
