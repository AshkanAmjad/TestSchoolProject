using AutoMapper;
using Data.Context;
using Domain.DTOs.Portal.TeacherCourse;
using Domain.Entities.Portal.Models;
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

        public bool IsExistById(int teacherCourseId)
            => _context.TeachersCourse.Where(tc => tc.TeacherCourseId == teacherCourseId)
                                      .Any();

        public TeacherCourse? GetById(int teacherCourseId)
            => _context.TeachersCourse.Find(teacherCourseId);

        public void SaveChanges()
            => _context.SaveChanges();


    }
}
