using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Portal.Course
{
    public class DisplayCoursesDTO
    {
        public string CourseId { get; set; }
        public string Title { get; set; }
        public string IsActived { get; set; }
    }
}
