using Domain.DTOs.Security.Teacher;
using Domain.Entities.Portal.Models;
using Domain.Entities.Security.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface ITeacherService
    {
        List<DisplayTeachersDTO> GetAll();
        bool Insert(InsertTeacherDTO model);
        Teacher? GetById(int teacherId);
        bool IsExistById(int teacherId);
        bool Disable(int teacherId);
        void SaveChanges();
    }
}
