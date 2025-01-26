using AutoMapper;
using Domain.DTOs.Portal.TeacherCourse;
using Domain.Entities.Portal.Models;
using Domain.Entities.Security.Models;
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
            CreateMap<InsertTeacherCourseDTO, TeacherCourse>();
            CreateMap<TeacherCourse, UpdateTeacherCourseDTO>();
            CreateMap<UpdateTeacherCourseDTO, TeacherCourse>();
        }
    }
}
