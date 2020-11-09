using Timelogger.Entities;

namespace Timelogger.Repository
{
    public class CustomerRepository : BaseRepotitory<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApiContext apiContext) :base(apiContext)
        {

        }
    }
}
