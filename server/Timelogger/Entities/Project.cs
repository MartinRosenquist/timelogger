using System.Collections.Generic;

namespace Timelogger.Entities
{
	public class Project
	{
		public int Id { get; set; }
		public string Name { get; set; }
        public string Deadline { get; set; }
        public Customer Customer { get; set; }
        public State State { get; set; }
        public List<TimeRegistration> TimeRegistrations { get; set; }
    }
}
