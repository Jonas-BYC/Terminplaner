namespace Terminplaner.repository;

public class AppointmentRepository
{
    private static List<Appointment> _appointments = new List<Appointment>();

    public static void AddAppointment(Appointment appointment)
    {
        _appointments.Add(appointment);
    }

    public static void RemoveAppointment(string id)
    {
        var appointment = _appointments.FirstOrDefault(a => a.id == id);
        if (appointment != null)
        {
            _appointments.Remove(appointment);
        }
    }

    public static List<Appointment> GetAppointmentsByDate(DateOnly date)
    {
        return _appointments.Where(a => a.date == date).ToList();
    }
}