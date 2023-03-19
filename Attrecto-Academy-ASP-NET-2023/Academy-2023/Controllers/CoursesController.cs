using Academy_2023.Data;
using Academy_2023.Dto;
using Academy_2023.Repositories;
using Academy_2023.Services;
using Academy_2023.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics.Metrics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Academy_2023.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService courseService, IOptions<LogLevelHelper> logLeveloptions)
        {
            _courseService = courseService;

            Console.WriteLine(logLeveloptions.Value.Default);       // test purpose, options pattern szemléltetése
        }
        // GET: api/<CourseController>
        [HttpGet]
        public IEnumerable<CourseDto> Get()
        {
            return _courseService.GetAll();
        }

        // GET api/<CourseController>/5
        [HttpGet("{id}")]
        public ActionResult<CourseDto> Get(int id)
        {
            var course = _courseService.GetById(id);

            return course == null ? NotFound() : course;
        }

        // POST api/<CourseController>
        [HttpPost]
        public ActionResult Post([FromBody] CourseDto data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _courseService.Create(data);

            return NoContent();
        }

        // PUT api/<CourseController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] CourseDto data)
        {
            var course = _courseService.Update(id, data);

            return course == null ? NotFound() : NoContent();
        }
        // DELETE api/<CourseController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return _courseService.Delete(id) ? NoContent() : NotFound();
        }
    }
}

