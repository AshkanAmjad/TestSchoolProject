using Domain.DTOs.Portal.TeacherCourse;
using Domain.Entities.Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ITeacherCourseRepository
    {
        List<DisplayDTO> GetAll();
        bool IsExistById(int teacherCourseId);
        TeacherCourse? GetById(int teacherCourseId);
        void SaveChanges();
    }
}
