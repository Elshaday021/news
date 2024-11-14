using HCMS.Application.Features.BusinessUnits;
using HCMS.Application.Features.BusinessUnits.Commands.ApproveBusinessUnit;
using HCMS.Application.Features.BusinessUnits.Commands.CreateBusinessUnit;
using HCMS.Application.Features.BusinessUnits.Commands.RejectBusinessUnit;
using HCMS.Application.Features.BusinessUnits.Commands.SubmitBusinessUnit;
using HCMS.Application.Features.BusinessUnits.Commands.UpdateBusinessUnit;
using HCMS.Application.Features.BusinessUnits.Queries;
using HCMS.Domain.Enum;
using Microsoft.AspNetCore.Mvc;
using SMS.Application;

namespace HCMS.API.Controllers.BusinessUnits
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessUnitController : BaseController<BusinessUnitController>
    {

        [HttpPost("CreateBusinessUnit", Name = "CreateBusinessUnit")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<int>> CreateBusinessUnit([FromBody] CreateBusinessUnitCommand command)
        {
            var businessUnitId = await mediator.Send(command);
            return Ok(businessUnitId);
        }
        [HttpGet("all", Name = "GetAllBusinessUnits")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<BusinessUnitLists>> GetAllBusinessUnits()
        {
            var searchResult = await mediator.Send(new GetBusinessUnitsQuery());
            return searchResult;
        }
        [HttpPost("update",Name="UpdateBusinessUnit")]
        public async Task<ActionResult<int>> UpdateBusinessUnit([FromBody]UpdateBusinessUnitCommand command)
        {
            var businessUnitId= await mediator.Send(command);
            return Ok(businessUnitId);
        }
        [HttpPost("submit", Name = "SubmitBusinessUnit")]
        public async Task<ActionResult<int>> SubmitBusinessUnit([FromBody] SubmitBusinessUnitCommand command)
        {
            var businessUnitId = await mediator.Send(command);
            return Ok(businessUnitId);
        }
        [HttpPost("approve",Name ="ApproveBusinessUnit")]
        public async Task<ActionResult<int>> ApproveBusinessUnit([FromBody] ApproveBusinessUnitCommand command)
        {
            var businessUnitId = await mediator.Send(command);
            return Ok(businessUnitId);
        }
        [HttpPost("Reject", Name = "RejectBusinessUnit")]
        public async Task<ActionResult<int>> RejectBusinessUnit([FromBody] RejectBusinessUnitCommand command)
        {
            var businessUnitId = await mediator.Send(command);
            return Ok(businessUnitId);
        }
        [HttpGet("allBusinessUnit", Name = "GetAllBuisnessUnitLists")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<BusinessUnitSearchResult>> GetAllBuisnessUnitLists(ApprovalStatus status, int pageNumber = 1, int pageSize = 20)
        {
            var searchResult = await mediator.Send(new GetBusinessUnitsListQuery(status, pageNumber, pageSize));

            return searchResult;
        }
        [HttpGet("counts", Name = "GetBusinessUnitCountPerApprovalStatus")]
        [ProducesResponseType(200)]
        public async Task<BusinessUnitCountsByStatus> GetBusinessUnitCountPerApprovalStatus()
        {
            return await mediator.Send(new GetBusinessUnitCountPerApprovalStatusQuery());
        }
    }
}
