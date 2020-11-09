using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Timelogger.Entities;

namespace Timelogger.Repository
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
			SeedDatabase();
        }

        public DbSet<Project> Projects { get; set; }

        private void SeedDatabase()
        {
			var testProject1 = new Project
			{
				Id = 1,
				Name = "e-conomic Interview",
				Deadline = DateTime.Parse("09-11-2020"),
				Customer = new Customer { Name = "Calin", Company = "Visma" },
				IsFinished = false,
				TimeRegistrations = new List<TimeRegistration> { new TimeRegistration { ProjectId = 1, Time = 300 } }
			};

			var testProject2 = new Project
			{
				Id = 2,
				Name = "Front-end Website",
				Deadline = DateTime.Parse("08-11-2020"),
				Customer = new Customer { Name = "Kris", Company = "ZBC" },
				IsFinished = true,
				TimeRegistrations = new List<TimeRegistration>()
			};

			Projects.Add(testProject1);
			Projects.Add(testProject2);

			SaveChanges();
		}
    }
}
