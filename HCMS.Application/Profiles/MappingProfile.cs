﻿using AutoMapper;
using HCMS.Application.Features.BusinessUnits;
using HCMS.Application.Features.BusinessUnits.Commands.CreateBusinessUnit;
using HCMS.Application.Features.BusinessUnits.Commands.UpdateBusinessUnit;
using HCMS.Application.Features.Employees;
using HCMS.Domain;


namespace HCMS.Application.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateEmployeeProfileCommand, Employee>().ReverseMap();
            CreateMap<BusinessUnit, BusinessUnitDto>();
            CreateMap<CreateBusinessUnitCommand, UpdateBusinessUnitCommand>().ReverseMap();
        }
    }
}
