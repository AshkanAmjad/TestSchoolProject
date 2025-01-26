using Application.Services.Implements;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.DTOs.Portal.TeacherCourse;
using Domain.DTOs.Security.Teacher;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace TestSchool.Api.Controllers
{
    [Route("api/teacher/")]
    public class TeacherController : BaseController
    {
        #region Constructor
        private readonly ITeacherService _teacherService;
        private readonly ILogger<TeacherController> _logger;
        private readonly IMapper _mapper;
        public TeacherController(ITeacherService teacherService,
                                 ILogger<TeacherController> logger,
                                 IMapper mapper)
        {
            _teacherService = teacherService;
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

        #region Post
        [HttpPost]
        public IActionResult Insert(InsertTeacherDTO model)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogInformation("Model is not valid :(");
                return BadRequest(model);
            }
            try
            {
                bool result = false;
                result=_teacherService.Insert(model);

                if (result)
                {
                    _teacherService.SaveChanges();

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
        [HttpPatch("{teacherId}")]
        public IActionResult Update(int teacherId,
                                    JsonPatchDocument<UpdateTeacherDTO> model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var isExists = _teacherService.IsExistById(teacherId);

                    if (isExists)
                    {
                        var item = _teacherService.GetById(teacherId);

                        if (item != null)
                        {
                            var itemToPatch = _mapper.Map<UpdateTeacherDTO>(item);

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

                            _teacherService.SaveChanges();

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
        [HttpDelete("{teacherId}")]
        public IActionResult Delete(int teacherId)
        {
            if (teacherId <= 0 ||
                !_teacherService.IsExistById(teacherId))
            {
                _logger.LogInformation("Teacher ID is not valid :(");
                return NotFound();
            }

            try
            {
                bool result = false;
                result = _teacherService.Disable(teacherId);

                if (result)
                {
                    _teacherService.SaveChanges();

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
