namespace Timelogger.Entities
{
    public class TimeRegistration
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int Time { get; set; }

    }
}
