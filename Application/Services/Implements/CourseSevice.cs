using Application.Services.Interfaces;
using AutoMapper;
using Domain.DTOs.Portal.Course;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Implements
{
    public class CourseSevice:ICourseService
    {
        #region Constructor
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;
        public CourseSevice(ICourseRepository courseRepository,
                            IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }
        #endregion

        public List<DisplayDTO> GetAll()
         => _courseRepository.GetAll();
    }
}
