using Data.Context;
using Domain.DTOs.Security.Teacher;
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
    public class TeacherRepository : ITeacherRepository
    {
        #region Constructor
        private readonly TestSchoolContext _context;
        public TeacherRepository(TestSchoolContext context)
        {
            _context = context;
        }
        #endregion
        public List<DisplayTeachersDTO> GetAll()
        {
            var courses = (from teacher in _context.Teachers
                           select new DisplayTeachersDTO
                           {
                               TeacherId = teacher.TeacherId.ToString(),
                               IsActived = teacher.IsActived.ToString(),
                               Address = teacher.Address.ToString(),
                               FirstName = teacher.FirstName.ToString(),
                               LastName = teacher.LastName.ToString(),
                               NationalCode = teacher.NationalCode.ToString(),
                               PhoneNumber = teacher.PhoneNumber.ToString()
                           }).ToList();

            return courses;
        }

        public bool Insert(Teacher model)
        {
            if (model == null) return false;

            _context.Add(model);

            return true;
        }

        public void SaveChanges()
            => _context.SaveChanges();

        public bool IsExistById(int teacherId)
            => _context.Teachers.Where(t => t.TeacherId == teacherId)
                                .Any();

        public Teacher? GetById(int teacherId)
            => _context.Teachers.Find(teacherId);

        public bool Disable(int teacherId)
        {
            var teacher = _context.Teachers.Find(teacherId);

            if(teacher == null)
                return false;

            teacher.IsActived = false;
            return true;
        }
    }
}
