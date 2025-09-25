using System;

namespace Terminplaner
{
    public class Appointment
    {
        public string id { get; set; }
        public string name { get; set; }
        public DateOnly date { get; set; }
        public TimeOnly startTime { get; set; }
        public TimeOnly endTime { get; set; }
        
        public Appointment(string name, DateOnly date, TimeOnly startTime, TimeOnly endTime)
        {
            this.id = Guid.NewGuid().ToString("N");
            this.name = name;
            this.date = date;
            this.startTime = startTime;
            this.endTime = endTime;
        }
    }
}