namespace Timelogger.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ApiContext _apiContext;
        private ICustomerRepository _customer;
        private IProjectRepository _project;
        private ITimeRegistrationRepository _timeRegistration;

        public ICustomerRepository Customer
        {
            get
            {
                if (_customer == null)
                {
                    _customer = new CustomerRepository(_apiContext);
                }

                return _customer;
            }
        }

        public IProjectRepository Project
        {
            get
            {
                if (_project == null)
                {
                    _project = new ProjectRepository(_apiContext);
                }

                return _project;
            }
        }

        public ITimeRegistrationRepository TimeRegistration
        {
            get
            {
                if (_timeRegistration == null)
                {
                    _timeRegistration = new TimeRegistrationRepository(_apiContext);
                }

                return _timeRegistration;
            }
        }

        public RepositoryWrapper(ApiContext apiContext)
        {
            _apiContext = apiContext;
        }

        public void Save()
        {
            _apiContext.SaveChanges();
        }
    }
}
