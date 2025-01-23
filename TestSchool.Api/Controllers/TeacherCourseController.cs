using Application.Services.Implements;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestSchool.Api.Controllers
{
    public class TeacherCourseController : BaseController
    {
        #region Constructor
        private readonly ITeacherCourseService _teacherCourseService;
        public TeacherCourseController(ITeacherCourseService teacherCourseService)
        {
            _teacherCourseService = teacherCourseService;
        }
        #endregion


        #region Get
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var teacherCourses = _teacherCourseService.GetAll();
                return Ok(teacherCourses);
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
