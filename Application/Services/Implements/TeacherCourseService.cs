using Application.Services.Interfaces;
using AutoMapper;
using Domain.DTOs.Portal.TeacherCourse;
using Domain.Entities.Portal.Models;
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

        public TeacherCourse? GetById(int teacherCourseId)
        {

            var id = Convert.ToInt32(teacherCourseId);
            return _teacherCourseRepository.GetById(id);
        }

        public bool IsExistById(int teacherCourseId)
            => _teacherCourseRepository.IsExistById(teacherCourseId);

        public void SaveChanges()
            => _teacherCourseRepository.SaveChanges();
    }
}
