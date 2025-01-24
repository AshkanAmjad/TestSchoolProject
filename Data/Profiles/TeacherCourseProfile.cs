using AutoMapper;
using Domain.DTOs.Portal.TeacherCourse;
using Domain.Entities.Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Profiles
{
    public class TeacherCourseProfile:Profile
    {
        public TeacherCourseProfile()
        {
            CreateMap<TeacherCourse, UpdateDTO>();
            CreateMap<UpdateDTO, TeacherCourse>();
        }
    }
}
