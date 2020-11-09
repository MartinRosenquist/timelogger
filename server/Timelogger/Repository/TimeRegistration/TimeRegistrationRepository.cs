using Timelogger.Entities;

namespace Timelogger.Repository
{
    public class TimeRegistrationRepository : BaseRepotitory<TimeRegistration>, ITimeRegistrationRepository
    {
        public TimeRegistrationRepository(ApiContext apiContext) : base(apiContext)
        {

        }
    }
}
