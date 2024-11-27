using HCMS.Application.Features.BusinessUnits.Commands.CreateBusinessUnit;
using HCMS.Application.Features.BusinessUnits.Models;
using HCMS.Domain.Enum;
using HCMS.Service.ValueConverterService;
using HCMS.Services.DataService;
using Microsoft.EntityFrameworkCore;


namespace HCMS.Application.Features.BusinessUnits.Services
{
    public class GenerateBusinessUnitCodeService:IGenerateBusinessUnitCodeService
    {
        private readonly IDataService dataService;
        private readonly IValueConvertor valueConvertor;
        public GenerateBusinessUnitCodeService(IDataService dataService, IValueConvertor valueConvertor)
        {
            this.dataService = dataService;
            this.valueConvertor = valueConvertor;
        }
        public async Task<BusinessUnitCodeGenerateDto> GenerateBusinessUnitCode(CreateBusinessUnitCommand request)
        {

            var businessUnitList = await dataService.BusinessUnits.ToListAsync();
            var parentBuisnessUnit = businessUnitList.Where(bu => bu.Id == request.ParentId).FirstOrDefault();
            var gParentBusinessUnit = businessUnitList.Where(bu => bu.Id == parentBuisnessUnit?.ParentId).FirstOrDefault();
            var gGParentBusinessUnit = businessUnitList.Where(bu => bu.Id == gParentBusinessUnit?.ParentId).FirstOrDefault();

            var newCheifId = businessUnitList.Where(bu => bu.Type == BusinessUnitTypeEnum.ChiefOffice && bu.ParentId==request.ParentId).Count() + 1;
            var newDepartmentorDistrictID = businessUnitList.Where(bu => bu.Type == BusinessUnitTypeEnum.DepartmentorDistrict && bu.ParentId == request.ParentId).Count() + 1;
            var newBranchorDivision = businessUnitList.Where(bu => bu.Type == BusinessUnitTypeEnum.BranchorDivision && bu.ParentId == request.ParentId).Count() + 1;
            var newSectionId = businessUnitList.Where(bu => bu.Type == BusinessUnitTypeEnum.Section && bu.ParentId == request.ParentId).Count() + 1;

            var newBusinessUnitCodeInfo = new BusinessUnitCodeGenerateDto();
            if (request.Type == BusinessUnitTypeEnum.ChiefOffice)
            {
                newBusinessUnitCodeInfo.BusinessUnitId = string.Concat(
                        new string(valueConvertor.TwoDigitConvertorMethod((int)newCheifId).Result), "-00-000-00");

                newBusinessUnitCodeInfo.BusinessUnitCode = valueConvertor.TwoDigitConvertorMethod((int)newCheifId).Result;
            }
            else if (request.Type == BusinessUnitTypeEnum.DepartmentorDistrict)
            {
                newBusinessUnitCodeInfo.BusinessUnitId = string.Concat(
                new string(parentBuisnessUnit.BusinessUnitCode), "-",
                           new string(valueConvertor.TwoDigitConvertorMethod((int)newDepartmentorDistrictID).Result), "-000-00"

                       );
                newBusinessUnitCodeInfo.BusinessUnitCode = valueConvertor.TwoDigitConvertorMethod((int)newDepartmentorDistrictID).Result;
            }
            else if (request.Type == BusinessUnitTypeEnum.BranchorDivision)
            {
                newBusinessUnitCodeInfo.BusinessUnitId = string.Concat(
                           new string(gParentBusinessUnit.BusinessUnitCode), "-",
                new string(parentBuisnessUnit.BusinessUnitCode), "-",
                            new string(valueConvertor.ThreeDigitConvertorMethod((int)newBranchorDivision).Result), "-00"
                       );
                newBusinessUnitCodeInfo.BusinessUnitCode = valueConvertor.ThreeDigitConvertorMethod((int)newBranchorDivision).Result;
            }
            else if (request.Type == BusinessUnitTypeEnum.Section)
            {
                newBusinessUnitCodeInfo.BusinessUnitId = string.Concat(
                           new string(gGParentBusinessUnit.BusinessUnitCode), "-",
                           new string(gParentBusinessUnit.BusinessUnitCode), "-",
                new string(parentBuisnessUnit.BusinessUnitCode), "-",
                            new string(valueConvertor.TwoDigitConvertorMethod((int)newSectionId).Result)
                       );
                newBusinessUnitCodeInfo.BusinessUnitCode = valueConvertor.TwoDigitConvertorMethod((int)newSectionId).Result;
            }
            else
            {
                newBusinessUnitCodeInfo.BusinessUnitId = string.Concat(
                          new string(gGParentBusinessUnit.BusinessUnitCode), "-",
                          new string(gParentBusinessUnit.BusinessUnitCode), "-",
                          new string(parentBuisnessUnit.BusinessUnitCode), "-",
                          new string(valueConvertor.TwoDigitConvertorMethod((int)newSectionId).Result)
                      );
            }
            return newBusinessUnitCodeInfo;
        }
    }
}
