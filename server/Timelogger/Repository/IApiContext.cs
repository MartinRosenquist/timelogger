using Microsoft.EntityFrameworkCore;
using Timelogger.Entities;

namespace Timelogger.Repository
{
    public interface IApiContext
    {
        DbSet<Project> Projects { get; set; }
    }
}