using Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestSchool.Api.Controllers
{
    [Route("api/course/")]
    public class CourseController : BaseController
    {
        #region Constructor
        private readonly ICourseService _courseService;
        private readonly ILogger<CourseController> _logger;
        public CourseController(ICourseService courseService,
                                ILogger<CourseController> logger)
        {
            _courseService = courseService;
            _logger = logger;
        }
        #endregion

        #region Get
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var courses = _courseService.GetAll();
                _logger.LogInformation("Successfully getting all :)");
                return Ok(courses);
            }
            catch (Exception ex)
            {
                List<Exception> errors = new();

                while (ex.InnerException != null)
                {
                    errors.Add(ex.InnerException);
                    _logger.LogError(ex.InnerException.ToString());
                }

                return BadRequest(errors);
            }
        }
        #endregion

    }
}
