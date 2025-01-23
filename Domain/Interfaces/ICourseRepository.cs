using Domain.DTOs.Portal.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICourseRepository
    {
        List<DisplayDTO> GetAll();
    }
}
