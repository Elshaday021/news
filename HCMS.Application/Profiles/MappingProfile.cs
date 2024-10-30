using AutoMapper;
using HCMS.Application.Features.Employees;
using HCMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateEmployeeProfileCommand, Employee>().ReverseMap();

        }
    }
}
