using Ambev.DeveloperEvaluation.Application.Sales.Commands.AddItemSale;
using Ambev.DeveloperEvaluation.Application.Sales.Commands.StartSale;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.AddItemSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.StartSale;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesController : BaseController
    {

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public SalesController(DomainValidationContext domainValidationContext,
            IMediator mediator, IMapper mapper) : base(domainValidationContext)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponseWithData<StartSaleResponse>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> StartSale([FromBody] StartSaleRequest request, CancellationToken cancellationToken)
        {
            var validator = new StartSaleRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<StartSaleCommand>(request);
            var response = await _mediator.Send(command, cancellationToken);

            if (!OperationValid())
                return ErrorResponse();

            return Created(string.Empty, new ApiResponseWithData<StartSaleResponse>
            {
                Success = true,
                Message = "Sale created successfully",
                Data = _mapper.Map<StartSaleResponse>(response)
            });
        }
        [HttpPost("items")]
        [ProducesResponseType(typeof(ApiResponseWithData<StartSaleResponse>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddItemSale([FromBody] AddItemSaleRequest request, CancellationToken cancellationToken)
        {
            var validator = new AddItemSaleRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<AddItemSaleCommand>(request);
            var response = await _mediator.Send(command, cancellationToken);

            if (!OperationValid())
                return ErrorResponse();

            return Created(string.Empty, new ApiResponseWithData<AddItemSaleResponse>
            {
                Success = true,
                Message = "Item sale add successfully",
                Data = _mapper.Map<AddItemSaleResponse>(response)
            });
        }
    }
}
