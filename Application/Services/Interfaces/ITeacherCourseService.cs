using Domain.DTOs.Portal.TeacherCourse;
using Domain.DTOs.Security.Teacher;
using Domain.Entities.Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface ITeacherCourseService
    {
        List<DisplayTeacherCoursesDTO> GetAll();
        TeacherCourse? GetById(int teacherCourseId);
        bool IsExistById(int teacherCourseId);
        bool Insert(InsertTeacherCourseDTO model);
        bool Disable(int teacherCourseId);
        void SaveChanges();
    }
}
