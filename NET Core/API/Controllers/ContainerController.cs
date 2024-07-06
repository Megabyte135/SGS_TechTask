using Microsoft.AspNetCore.Mvc;
using Services.Containers.DTOs;
using Services.Containers.Interfaces;

namespace API.Controllers
{
    [Route("api/containers")]
    [ApiController]
    public class ContainerController : ControllerBase
    {
        private readonly IContainerService _containerService;
        private readonly ILogger _logger;
        public ContainerController(IContainerService containerService, ILogger<ContainerController> logger) { 
            _containerService = containerService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<ContainerDto>>> GetAll()
        {
            try
            {
                List<ContainerDto> result = await _containerService.GetAllAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ContainerDto>> FindById(Guid id)
        {
            try
            {
                ContainerDto? result = await _containerService.FindByIdAsync(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(ContainerCreateDto createDto)
        {
            try
            {
                await _containerService.AddAsync(createDto);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(ContainerDto containerDto)
        {
            try
            {
                await _containerService.UpdateAsync(containerDto);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _containerService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return StatusCode(500);
            }
        }
    }
}
