using System.Collections.Generic;
using Timelogger.Entities;
using Timelogger.Repository;

namespace Timelogger
{
    public class ProjectsManager
    {
        private IBaseRepository<Project> _projectRepository;

        public ProjectsManager(IBaseRepository<Project> baseRepository)
        {
            _projectRepository = baseRepository;
        }

        public Project GetProject(int id)
        {
            return _projectRepository.GetById(id);
        }

        public List<Project> GetAllProjects()
        {
            return _projectRepository.GetAll();
        }

        public void AddTimeRegistration(Project project, User user, int time)
        {

        }
    }
}
