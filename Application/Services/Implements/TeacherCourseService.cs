using Application.Services.Interfaces;
using AutoMapper;
using Domain.DTOs.Portal.TeacherCourse;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Implements
{
    public class TeacherCourseService : ITeacherCourseService
    {
        #region Constructor
        private readonly ITeacherCourseRepository _teacherCourseRepository;
        private readonly IMapper _mapper;
        public TeacherCourseService(ITeacherCourseRepository teacherCourseRepository,
                                    IMapper mapper)
        {
            _teacherCourseRepository = teacherCourseRepository;
            _mapper = mapper;
        }
        #endregion
        public List<DisplayDTO> GetAll()
           => _teacherCourseRepository.GetAll();
    }
}
