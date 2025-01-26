using Domain.DTOs.Security.Teacher;
using Domain.Entities.Portal.Models;
using Domain.Entities.Security.Models;

namespace Domain.Interfaces
{
    public interface ITeacherRepository
    {
        List<DisplayTeachersDTO> GetAll();
        bool Insert(Teacher model);
        void SaveChanges();
        bool IsExistById(int teacherId);
        Teacher? GetById(int teacherId);
        bool Disable(int teacherId);
    }
}
