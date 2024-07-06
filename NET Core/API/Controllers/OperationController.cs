using Microsoft.AspNetCore.Mvc;
using Services.Operations.DTOs;
using Services.Operations.Interfaces;

namespace API.Controllers
{
    [Route("api/operations")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        private readonly IOperationService _operationService;
        private readonly ILogger _logger;
        public OperationController(IOperationService operationService, ILogger<OperationController> logger)
        {
            _operationService = operationService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<OperationDto>>> GetAll()
        {
            try
            {
                List<OperationDto> result = await _operationService.GetAllAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message, ex.StackTrace);
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("{containerId}")]
        public async Task<ActionResult<List<OperationDto>>> GetAllByContainerId(Guid containerId)
        {
            try
            {
                List<OperationDto> result = await _operationService.GetAllByContainerId(containerId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message, ex.StackTrace);
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(OperationCreateDto createDto)
        {
            try
            {
                await _operationService.AddAsync(createDto);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message, ex.StackTrace);
                return StatusCode(500);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(OperationDto OperationDto)
        {
            try
            {
                await _operationService.UpdateAsync(OperationDto);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message, ex.StackTrace);
                return StatusCode(500);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _operationService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message, ex.StackTrace);
                return StatusCode(500);
            }
        }
    }
}
