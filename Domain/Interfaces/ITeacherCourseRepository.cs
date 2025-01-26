using Domain.DTOs.Portal.TeacherCourse;
using Domain.Entities.Portal.Models;
using Domain.Entities.Security.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ITeacherCourseRepository
    {
        List<DisplayTeacherCoursesDTO> GetAll();
        bool IsExistById(int teacherCourseId);
        TeacherCourse? GetById(int teacherCourseId);
        bool Insert(TeacherCourse model);
        bool DisableByTeacherCourseId(int teacherCourseId);
        void DisableByTeacherId(int teacherId);
        void DisableByCourseId(int courseId);
        void SaveChanges();
    }
}
