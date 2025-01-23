using Data.Context;
using Domain.DTOs.Security.Teacher;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class TeacherRepository:ITeacherRepository
    {
        #region Constructor
        private readonly TestSchoolContext _context;
        public TeacherRepository(TestSchoolContext context)
        {
            _context = context;
        }
        #endregion
        public List<DisplayDTO> GetAll()
        {
            var courses = (from teacher in _context.Teachers
                           select new DisplayDTO
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
    }
}
