using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Security.Models;

namespace Domain.Entities.Portal.Models
{
    [Table("TeacherCourses", Schema = "Portal")]

    public class TeacherCourse
    {
        #region Properties
        public int TeacherCourseId { get; set; }
        public int TeacherId { get; set; }
        public int CourseId { get; set; }
        public bool IsActived { get; set; }
        public DateTime RegisterDate { get; set; }
        #endregion

        #region Navigations
        public virtual Course Course { get; set; }
        public virtual Teacher Teacher { get; set; }
        #endregion
    }
}
