using System;
using System.Collections.Generic;

namespace Timelogger.Entities
{
    /// <summary>
    /// Represents a Project
    /// </summary>
    public class Project
	{
		public int Id { get; set; }

		public string Name { get; set; }

        public DateTime Deadline { get; set; }

        public Customer Customer { get; set; }

        public bool IsFinished { get; set; }

        public ICollection<TimeRegistration> TimeRegistrations { get; set; }
    }
}
