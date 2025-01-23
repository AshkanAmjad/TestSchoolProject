using Data.Context;
using Domain.DTOs.Portal.TeacherCourse;
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
        public TeacherCourseRepository(TestSchoolContext context)
        {
            _context = context;
        }
        #endregion
        public List<DisplayDTO> GetAll()
        {
            var courses = (from item in _context.TeachersCourse
                           select new DisplayDTO
                           {
                               CourseId = item.CourseId.ToString(),
                               TeacherCourseId = item.TeacherCourseId.ToString(),
                               TeacherId = item.TeacherId.ToString(),
                               IsActived = item.IsActived.ToString()
                           }).ToList();

            return courses;
        }
    }
}
