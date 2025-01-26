using Domain.DTOs.Portal.Course;
using Domain.Entities.Security.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface ICourseService
    {
        List<DisplayCoursesDTO> GetAll();
        bool Insert(InsertCourseDTO model);
        Course? GetById(int courseId);
        bool IsExistById(int courseId);
        bool Disable(int courseId);
        void SaveChanges();
    }
}
