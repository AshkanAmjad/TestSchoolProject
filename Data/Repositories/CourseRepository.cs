using Data.Context;
using Domain.DTOs.Portal.Course;
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
        public CourseRepository(TestSchoolContext context)
        {
            _context = context;
        }
        #endregion
        public List<DisplayDTO> GetAll()
        {
            var courses = (from course in _context.Courses 
                           select new DisplayDTO
                           {
                               CourseId = course.CourseId.ToString(),
                               Title = course.Title,
                               IsActived = course.IsActived.ToString(),

                           }).ToList();

            return courses;
        }
    }
}
