using Timelogger.Repository;

namespace Timelogger
{
    public interface IRepositoryWrapper
    {
        ICustomerRepository Customer { get; }
        IProjectRepository Project { get; }
        ITimeRegistrationRepository TimeRegistration { get; }
        void Save();
    }
}
