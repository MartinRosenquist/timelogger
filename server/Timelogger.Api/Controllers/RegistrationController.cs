using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Timelogger.Entities;

namespace Timelogger.Api.Controllers
{
    [Route("api/[controller]")]
    public class RegistrationController : Controller
    {
        private IRepositoryWrapper _repository;

        public RegistrationController(IRepositoryWrapper repositoryWrapper)
        {
            _repository = repositoryWrapper;
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] TimeRegistration timeRegistration)
        {
            if (timeRegistration == null)
                return ValidationProblem();

            try
            {
                var result = _repository.Project.GetByCondition(x => x.Id == timeRegistration.ProjectId, x => x.TimeRegistrations).First(x => x.Id == timeRegistration.ProjectId);

                if (result.IsFinished)
                    return BadRequest("Can't add registration to completed project");
                
                result.TimeRegistrations.Add(timeRegistration);

                _repository.Project.Update(result);
                _repository.Save();

                if (result == null)
                    return NotFound();

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
