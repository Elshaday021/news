using HCMS.Application.Features.BusinessUnits.Commands.CreateBusinessUnit;
using HCMS.Application.Features.BusinessUnits.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Features.BusinessUnits.Services
{
    public interface IGenerateBusinessUnitCodeService
    {
        Task<BusinessUnitCodeGenerateDto> GenerateBusinessUnitCode(CreateBusinessUnitCommand request);
    }
}
