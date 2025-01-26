using Data.Context;
using Domain.DTOs.Portal.Course;
using Domain.Entities.Security.Models;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        #region Constructor
        private readonly TestSchoolContext _context;
        private readonly ITeacherCourseRepository _teachertCourseRepository;
        public CourseRepository(TestSchoolContext context,
                                ITeacherCourseRepository teachertCourseRepository)
        {
            _context = context;
            _teachertCourseRepository = teachertCourseRepository;
        }
        #endregion
        public List<DisplayCoursesDTO> GetAll()
        {
            var courses = (from course in _context.Courses
                           select new DisplayCoursesDTO
                           {
                               CourseId = course.CourseId.ToString(),
                               Title = course.Title,
                               IsActived = course.IsActived.ToString(),

                           }).ToList();

            return courses;
        }

        public bool Insert(Course model)
        {
            if (model == null) return false;

            _context.Add(model);

            return true;
        }

        public void SaveChanges()
            => _context.SaveChanges();

        public bool IsExistById(int courseId)
           => _context.Courses.Where(c => c.CourseId == courseId)
                              .Any();

        public Course? GetById(int courseId)
            => _context.Courses.Find(courseId);

        public bool Disable(int courseId)
        {
            var course = _context.Courses.Find(courseId);

            if (course == null)
                return false;

            course.IsActived = false;
            course.RegisterDate = DateTime.Now;

            _teachertCourseRepository.DisableByCourseId(courseId);

            return true;

        }
    }
}
