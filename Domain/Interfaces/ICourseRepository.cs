using Domain.DTOs.Portal.Course;
using Domain.Entities.Security.Models;

namespace Domain.Interfaces
{
    public interface ICourseRepository
    {
        List<DisplayCoursesDTO> GetAll();
        bool Insert(Course model);
        void SaveChanges();
        bool IsExistById(int courseId);
        bool Disable(int courseId);
        Course? GetById(int courseId);

    }
}
