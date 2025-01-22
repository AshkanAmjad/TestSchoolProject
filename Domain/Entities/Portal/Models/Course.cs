using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Portal.Models;

namespace Domain.Entities.Security.Models
{
    [Table("Courses", Schema = "Portal")]

    public class Course
    {
        #region Properties
        public int CourseId { get; set; }
        public string Title {  get; set; }
        public bool IsActived { get; set; }
        public DateTime RegisterDate { get; set; }
        #endregion

        #region Navigations
        public virtual ICollection<TeacherCourse> UserCourses { get; set; }
        #endregion
    }
}
