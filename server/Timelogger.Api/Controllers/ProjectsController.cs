using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Timelogger.Entities;

namespace Timelogger.Api.Controllers
{
    [Route("api/[controller]")]
    public class ProjectsController : Controller
    {
        private IRepositoryWrapper _repository;

        public ProjectsController(IRepositoryWrapper repositoryWrapper)
        {
            _repository = repositoryWrapper;
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] Project project)
        {
            if (project == null)
                return ValidationProblem();

            try
            {
                _repository.Project.Create(project);
                _repository.Save();

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("get/{id}")]
        public IActionResult Get(int id)
        {
            if (id <= 0)
                return ValidationProblem();

            try
            {
                // Get project by id, and add customer & time registrations to the object
                var result = _repository.Project.GetByCondition(x => x.Id == id, x => x.Customer, x => x.TimeRegistrations);

                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("getall")]
        public IActionResult GetAll()
        {
            try
            {
                // Get all project , and add customer & time registrations to the object
                var result = _repository.Project.GetAll(x => x.Customer, x => x.TimeRegistrations);

                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("deadline")]
        public IActionResult GetAllSortedByDeadline()
        {
            try
            {
                // Get all project, and add customer & time registrations to the object then order by deadline
                var result = _repository.Project.GetAll(x => x.Customer, x => x.TimeRegistrations).OrderBy( x=> x.Deadline);

                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("{id}/registrations")]
        public IActionResult GetRegistrations(int id)
        {
            if (id <= 0)
                return ValidationProblem();

            try
            {
                // Get project by id, add time registrations to the object then take the first elements time registrations
                var result = _repository.Project.GetByCondition(x => x.Id == id, x => x.TimeRegistrations).First(x => x.Id == id).TimeRegistrations;

                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("update")]
        public IActionResult Update([FromBody] Project project)
        {
            if (project == null)
                return ValidationProblem();

            try
            {
                _repository.Project.Update(project);
                _repository.Save();     

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("delete")]
        public IActionResult Delete([FromBody] Project project)
        {
            if (project == null)
                return ValidationProblem();

            try
            {
                _repository.Project.Delete(project);
                _repository.Save();

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
