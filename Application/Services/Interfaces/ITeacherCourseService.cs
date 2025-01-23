using Domain.DTOs.Portal.TeacherCourse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface ITeacherCourseService
    {
        List<DisplayDTO> GetAll();
    }
}
