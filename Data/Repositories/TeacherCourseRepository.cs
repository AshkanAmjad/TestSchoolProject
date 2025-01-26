using AutoMapper;
using Data.Context;
using Domain.DTOs.Portal.TeacherCourse;
using Domain.Entities.Portal.Models;
using Domain.Entities.Security.Models;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class TeacherCourseRepository:ITeacherCourseRepository
    {
        #region Constructor
        private readonly TestSchoolContext _context;
        private readonly IMapper _mapper;
        public TeacherCourseRepository(TestSchoolContext context,
                                       IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        #endregion
        public List<DisplayTeacherCoursesDTO> GetAll()
        {
            var courses = (from item in _context.TeachersCourse
                           select new DisplayTeacherCoursesDTO
                           {
                               CourseId = item.CourseId.ToString(),
                               TeacherCourseId = item.TeacherCourseId.ToString(),
                               TeacherId = item.TeacherId.ToString(),
                               IsActived = item.IsActived.ToString()
                           }).ToList();

            return courses;
        }

        public bool IsExistById(int teacherCourseId)
            => _context.TeachersCourse.Where(tc => tc.TeacherCourseId == teacherCourseId)
                                      .Any();

        public TeacherCourse? GetById(int teacherCourseId)
            => _context.TeachersCourse.Find(teacherCourseId);

        public void SaveChanges()
            => _context.SaveChanges();

        public bool Insert(TeacherCourse model)
        {
            if (model == null) return false;

            _context.Add(model);

            return true;
        }

        public bool DisableByTeacherCourseId(int teacherCourseId)
        {
            var teacherCourse = _context.TeachersCourse.Find(teacherCourseId);

            if (teacherCourse == null)
                return false;

            teacherCourse.IsActived = false;
            teacherCourse.RegisterDate = DateTime.Now;

            return true;
        }

        public void DisableByCourseId(int courseId)
        {
            var teacherCourse = _context.TeachersCourse.Where(tc => tc.CourseId == courseId)
                                                       .ToList();

            if (teacherCourse.Count != 0)
            {
                foreach (var item in teacherCourse)
                {
                    item.IsActived = false;
                    item.RegisterDate = DateTime.Now;
                }
            }
        }

        public void DisableByTeacherId(int teacherId)
        {
            var teacherCourse = _context.TeachersCourse.Where(tc => tc.TeacherId == teacherId)
                                                       .ToList();

            if (teacherCourse.Count != 0)
            {
                foreach (var item in teacherCourse)
                {
                    item.IsActived = false;
                    item.RegisterDate = DateTime.Now;
                }
            }
        }
    }
}
