using Timelogger.Entities;

namespace Timelogger.Repository
{
    public class ProjectRepository : BaseRepotitory<Project>, IProjectRepository
    {
        public ProjectRepository(ApiContext apiContext) : base(apiContext)
        {

        }
    }
}
