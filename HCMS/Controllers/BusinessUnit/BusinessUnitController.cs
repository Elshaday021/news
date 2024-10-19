using HCMS.Application.Features.BusinessUnits.Commands.CreateBusinessUnit;
using HCMS.Services.DataService;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HCMS.API.Controllers.BusinessUnit
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessUnitController : ControllerBase
    {
        private readonly IDataService _dataservice;
        private readonly IMediator _mediator;
        public BusinessUnitController(IDataService dataService, IMediator mediator)
        {
            this._dataservice = dataService;
            _mediator = mediator;
        }

        [HttpPost("CreateBusinessUnit", Name = "CreateBusinessUnit")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<int>> CreateBusinessUnit([FromBody] CreateBusinessUnitCommand command)
        {
            var parValueId = await _mediator.Send(command);
            return Ok(parValueId);
        }

    }
}
