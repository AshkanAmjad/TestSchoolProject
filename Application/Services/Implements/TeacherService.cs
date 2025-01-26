using Application.Services.Interfaces;
using AutoMapper;
using Data.Repositories;
using Domain.DTOs.Security.Teacher;
using Domain.Entities.Portal.Models;
using Domain.Entities.Security.Models;
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
        public List<DisplayTeachersDTO> GetAll()
            => _teacherRepository.GetAll();

        public bool Insert(InsertTeacherDTO model)
        {
            bool result = false;

            var teacher = _mapper.Map<Teacher>(model);

            teacher.IsActived = true;
            teacher.RegisterDate = DateTime.Now;

            result = _teacherRepository.Insert(teacher);

            if (result)
            {
                return true;
            }

            return false;
        }

        public void SaveChanges()
            => _teacherRepository.SaveChanges();

        public Teacher? GetById(int teacherId)
        {

            var id = Convert.ToInt32(teacherId);
            return _teacherRepository.GetById(id);
        }

        public bool IsExistById(int teacherId)
           => _teacherRepository.IsExistById(teacherId);

        public bool Disable(int teacherId)
           => _teacherRepository.Disable(teacherId);

    }
}
