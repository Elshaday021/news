using AutoMapper;
using HCMS.Application.Features.Employees;
using HCMS.Domain;


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
