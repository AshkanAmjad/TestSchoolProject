using Application.Services.Implements;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.DTOs.Portal.Course;
using Domain.DTOs.Security.Teacher;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace TestSchool.Api.Controllers
{
    [Route("api/course/")]
    public class CourseController : BaseController
    {
        #region Constructor
        private readonly ICourseService _courseService;
        private readonly ILogger<CourseController> _logger;
        private readonly IMapper _mapper;
        public CourseController(ICourseService courseService,
                                ILogger<CourseController> logger,
                                IMapper mapper)
        {
            _courseService = courseService;
            _logger = logger;
            _mapper = mapper;
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

        #region Post
        [HttpPost]
        public IActionResult Insert(InsertCourseDTO model)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogInformation("Model is not valid :(");
                return BadRequest(model);
            }
            try
            {
                bool result = false;

                result = _courseService.Insert(model);

                if (result)
                {
                    _courseService.SaveChanges();

                    _logger.LogInformation("Successfully Inserted ;)");
                    return Ok("Successfully Inserted ;)");
                }
                else
                {
                    return BadRequest("Unsuccessfully Inserted :(");
                }
            }
            catch (Exception ex)
            {
                List<string> errors = new();
                errors.Add(ex.Message);

                while (ex.InnerException != null)
                {
                    errors.Add(ex.InnerException.Message);
                    ex = ex.InnerException;
                }

                return BadRequest(errors);
            }
        }
        #endregion

        #region Patch
        [HttpPatch("{courseId}")]
        public IActionResult Update(int courseId,
                                    JsonPatchDocument<UpdateCourseDTO> model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var isExists = _courseService.IsExistById(courseId);

                    if (isExists)
                    {
                        var item = _courseService.GetById(courseId);

                        if (item != null)
                        {
                            var itemToPatch = _mapper.Map<UpdateCourseDTO>(item);

                            model.ApplyTo(itemToPatch, ModelState);

                            if (!ModelState.IsValid)
                            {
                                return BadRequest(ModelState);
                            }
                            if (!TryValidateModel(itemToPatch))
                            {
                                return BadRequest(ModelState);
                            }

                            _mapper.Map(itemToPatch, item);

                            _courseService.SaveChanges();

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

        #region Disable
        [HttpDelete("{courseId}")]
        public IActionResult Delete(int courseId)
        {
            if (courseId <= 0 ||
                _courseService.IsExistById(courseId))
            {
                _logger.LogInformation("Course ID is not valid :(");
                return NotFound();

            }

            try
            {
                bool result = false;
                result = _courseService.Disable(courseId);

                if (result)
                {
                    _courseService.SaveChanges();

                    _logger.LogInformation("Successfully Disabled ;)");
                    return Ok("Successfully Disabled ;)");
                }
                else
                {
                    return BadRequest("Unsuccessfully Disabled :(");
                }
            }
            catch (Exception ex)
            {
                List<string> errors = new();
                errors.Add(ex.Message);


                while (ex.InnerException != null)
                {
                    errors.Add(ex.InnerException.Message);
                    ex = ex.InnerException;
                }

                return BadRequest(errors);
            }
        }
        #endregion
    }
}
