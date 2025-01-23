using Application.Services.Implements;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestSchool.Api.Controllers
{
    public class TeacherController : BaseController
    {
        #region Constructor
        private readonly ITeacherService _teacherService;
        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }
        #endregion


        #region Get
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var teachers = _teacherService.GetAll();
                return Ok(teachers);
            }
            catch (Exception ex)
            {
                List<Exception> errors = new();

                while (ex.InnerException != null)
                {
                    errors.Add(ex.InnerException);
                }

                return BadRequest(errors);
            }
        }
        #endregion
    }
}
