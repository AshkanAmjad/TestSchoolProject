﻿using Domain.DTOs.Security.Teacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface ITeacherService
    {
        List<DisplayDTO> GetAll();
    }
}
