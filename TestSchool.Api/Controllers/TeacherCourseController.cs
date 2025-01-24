using Application.Services.Interfaces;
using AutoMapper;
using Domain.DTOs.Portal.TeacherCourse;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TestSchool.Api.Controllers
{
    [Route("api/teachercourse/")]
    public class TeacherCourseController : BaseController
    {
        #region Constructor
        private readonly ITeacherCourseService _teacherCourseService;
        private readonly IMapper _mapper;
        private readonly ILogger<TeacherCourseController> _logger;
        public TeacherCourseController(ITeacherCourseService teacherCourseService,
                                       IMapper mapper,
                                       ILogger<TeacherCourseController> logger)
        {
            _teacherCourseService = teacherCourseService;
            _mapper = mapper;
            _logger = logger;
        }
        #endregion

        #region Get
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var teacherCourses = _teacherCourseService.GetAll();
                _logger.LogInformation("Successfully getting all :)");
                return Ok(teacherCourses);
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

        #region Patch
        [HttpPatch("{teacherCourseId}")]
        public IActionResult Update(int teacherCourseId,
                                    JsonPatchDocument<UpdateDTO> model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var isExists = _teacherCourseService.IsExistById(teacherCourseId);

                    if (isExists)
                    {
                        var item = _teacherCourseService.GetById(teacherCourseId);

                        if(item != null)
                        {
                            var itemToPatch = _mapper.Map<UpdateDTO>(item);

                            model.ApplyTo(itemToPatch,ModelState);

                            if (!ModelState.IsValid)
                            {
                                return BadRequest(ModelState);
                            }
                            if (!TryValidateModel(itemToPatch))
                            {
                                return BadRequest(ModelState);
                            }

                            _mapper.Map(itemToPatch,item);

                            _teacherCourseService.SaveChanges();

                            _logger.LogInformation("Updated");
                            return Ok("Updated");
                        }
                    }

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
            return NotFound();
        }

        #endregion
    }
}
