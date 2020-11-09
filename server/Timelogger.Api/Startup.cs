using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using Timelogger.Entities;
using Timelogger.Repository;
using System;
using System.Collections.Generic;

namespace Timelogger.Api
{
	public class Startup
	{
		private readonly IWebHostEnvironment _environment;
		public IConfigurationRoot Configuration { get; }

		public Startup(IWebHostEnvironment env)
		{
			_environment = env;

			var builder = new ConfigurationBuilder()
				.SetBasePath(env.ContentRootPath)
				.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
				.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
				.AddEnvironmentVariables();
			Configuration = builder.Build();
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			// Add framework services.
			services.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase("e-conomic interview"));
			services.AddLogging(builder =>
			{
				builder.AddConsole();
				builder.AddDebug();
			});

			services.AddMvc(options => options.EnableEndpointRouting = false);

			if (_environment.IsDevelopment())
			{
				services.AddCors();
			}

			services.AddScoped<IBaseRepository<Project>, BaseRepotitory<Project>>();
			services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseCors(builder => builder
					.AllowAnyMethod()
					.AllowAnyHeader()
					.SetIsOriginAllowed(origin => true)
					.AllowCredentials());
			}

			app.UseMvc();


			var serviceScopeFactory = app.ApplicationServices.GetService<IServiceScopeFactory>();
			using (var scope = serviceScopeFactory.CreateScope())
			{
				//SeedDatabase(scope);
			}
		}

		private static void SeedDatabase(IServiceScope scope)
		{
			var context = scope.ServiceProvider.GetService<ApiContext>();

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

			context.Projects.Add(testProject1);
			context.Projects.Add(testProject2);

			context.SaveChanges();
		}
	}
}