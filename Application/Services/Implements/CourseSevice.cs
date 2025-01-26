using Application.Services.Interfaces;
using AutoMapper;
using Data.Repositories;
using Domain.DTOs.Portal.Course;
using Domain.Entities.Security.Models;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Implements
{
    public class CourseSevice:ICourseService
    {
        #region Constructor
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;
        public CourseSevice(ICourseRepository courseRepository,
                            IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }
        #endregion

        public List<DisplayCoursesDTO> GetAll()
         => _courseRepository.GetAll();

        public void SaveChanges()
            => _courseRepository.SaveChanges();

        public bool Insert(InsertCourseDTO model)
        {
            bool result = false;

            var course = _mapper.Map<Course>(model);

            course.IsActived = true;
            course.RegisterDate = DateTime.Now;

            result = _courseRepository.Insert(course);

            if (result)
            {
                return true;
            }

            return false;
        }

        public Course? GetById(int courseId)
        {

            var id = Convert.ToInt32(courseId);
            return _courseRepository.GetById(id);
        }

        public bool IsExistById(int courseId)
           => _courseRepository.IsExistById(courseId);

        public bool Disable(int courseId)
            => _courseRepository.Disable(courseId);
    }
}
