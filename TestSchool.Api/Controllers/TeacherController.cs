using Application.Services.Implements;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestSchool.Api.Controllers
{
    [Route("api/teacher/")]
    public class TeacherController : BaseController
    {
        #region Constructor
        private readonly ITeacherService _teacherService;
        private readonly ILogger<TeacherController> _logger;
        public TeacherController(ITeacherService teacherService,
                                 ILogger<TeacherController> logger)
        {
            _teacherService = teacherService;
            _logger = logger;
        }
        #endregion


        #region Get
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var teachers = _teacherService.GetAll();
                _logger.LogInformation("Successfully getting all :)");
                return Ok(teachers);
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
