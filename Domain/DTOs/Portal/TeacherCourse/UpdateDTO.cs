using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Portal.TeacherCourse
{
    public class UpdateDTO
    {
        public string TeacherId { get; set; }
        public string CourseId { get; set; }
        public string IsActived { get; set; }
    }
}
