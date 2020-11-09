namespace Timelogger.Entities
{
    /// <summary>
    /// Represents a Time Registration
    /// </summary>
    public class TimeRegistration
    {
        public int Id { get; set; }

        public int ProjectId { get; set; }

        public int Time { get; set; }
    }
}
