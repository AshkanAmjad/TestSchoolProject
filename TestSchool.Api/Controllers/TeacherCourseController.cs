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



    }
}
