using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Portal.Models;

namespace Domain.Entities.Security.Models
{
    [Table("Teachers", Schema = "Security")]

    public class Teacher
    {
        #region Properties
        public int TeacherId { get; set; }
        public string NationalCode {  get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public bool IsActived { get; set; }
        public DateTime RegisterDate { get; set; }
        #endregion

        #region Navigations
        public virtual ICollection<TeacherCourse> UserCourses { get; set; }
        #endregion
    }
}
