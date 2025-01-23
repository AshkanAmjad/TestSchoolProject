using Application.Services.Interfaces;
using AutoMapper;
using Domain.DTOs.Security.Teacher;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Implements
{
    public class TeacherService : ITeacherService
    {
        #region Constructor
        private readonly ITeacherRepository _teacherRepository;
        private readonly IMapper _mapper;
        public TeacherService(ITeacherRepository teacherRepository,
                            IMapper mapper)
        {
            _teacherRepository = teacherRepository;
            _mapper = mapper;
        }
        #endregion
        public List<DisplayDTO> GetAll()
            => _teacherRepository.GetAll();
    }
}
