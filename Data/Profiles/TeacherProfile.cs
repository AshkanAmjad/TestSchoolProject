using AutoMapper;
using Domain.DTOs.Security.Teacher;
using Domain.Entities.Portal.Models;
using Domain.Entities.Security.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Profiles
{
    public class TeacherProfile : Profile
    {
        public TeacherProfile()
        {
            CreateMap<InsertTeacherDTO, Teacher>();
            CreateMap<Teacher, UpdateTeacherDTO>();
            CreateMap<UpdateTeacherDTO, Teacher>();

        }
    }
}
