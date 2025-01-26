using Application.Services.Interfaces;
using AutoMapper;
using Data.Repositories;
using Domain.DTOs.Portal.Course;
using Domain.DTOs.Portal.TeacherCourse;
using Domain.Entities.Portal.Models;
using Domain.Entities.Security.Models;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Implements
{
    public class TeacherCourseService : ITeacherCourseService
    {
        #region Constructor
        private readonly ITeacherCourseRepository _teacherCourseRepository;
        private readonly IMapper _mapper;
        public TeacherCourseService(ITeacherCourseRepository teacherCourseRepository,
                                    IMapper mapper)
        {
            _teacherCourseRepository = teacherCourseRepository;
            _mapper = mapper;
        }
        #endregion
        public List<DisplayTeacherCoursesDTO> GetAll()
           => _teacherCourseRepository.GetAll();

        public TeacherCourse? GetById(int teacherCourseId)
        {

            var id = Convert.ToInt32(teacherCourseId);
            return _teacherCourseRepository.GetById(id);
        }

        public bool IsExistById(int teacherCourseId)
            => _teacherCourseRepository.IsExistById(teacherCourseId);

        public void SaveChanges()
            => _teacherCourseRepository.SaveChanges();

        public bool Insert(InsertTeacherCourseDTO model)
        {
            bool result = false;

            var course = _mapper.Map<TeacherCourse>(model);

            course.IsActived = true;
            course.RegisterDate = DateTime.Now;

            result = _teacherCourseRepository.Insert(course);

            if (result)
            {
                return true;
            }

            return false;
        }

        public bool Disable(int teacherCourseId)
            => _teacherCourseRepository.Disable(teacherCourseId);
    }
}
