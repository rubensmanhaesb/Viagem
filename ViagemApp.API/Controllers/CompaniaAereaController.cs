using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using ViagemApp.Domain.DTO;
using ViagemApp.Domain.Entities;
using ViagemApp.Domain.Service;

namespace ViagemApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniaAereaController : ControllerBase
    {
        private readonly ICompaniaAereaDomainService _companiaAereaDomainService;
        private readonly AbstractValidator<CompaniaAereaDTODelete> _validatorDTODelete;
        private readonly AbstractValidator<CompaniaAereaDTOUpdate> _validatorDTOUpdate;
        private readonly AbstractValidator<CompaniaAereaDTOInsert> _validatorDTOInsert;

        public CompaniaAereaController(
            ICompaniaAereaDomainService companiaAereaDomainService, 
            AbstractValidator<CompaniaAereaDTODelete> validatorDTODelete, 
            AbstractValidator<CompaniaAereaDTOUpdate> validatorDTOUpdate, 
            AbstractValidator<CompaniaAereaDTOInsert> validatorDTOInsert)
        {
            _companiaAereaDomainService = companiaAereaDomainService;
            _validatorDTODelete = validatorDTODelete;
            _validatorDTOUpdate = validatorDTOUpdate;
            _validatorDTOInsert = validatorDTOInsert;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CompaniaAerea), StatusCodes.Status201Created)]
        public async Task<IActionResult> Insert([FromBody] CompaniaAereaDTOInsert dto, [FromServices] IMapper mapper)
        {
            try
            {
                if (!_validatorDTOInsert.Validate(dto).IsValid)
                {
                    return StatusCode(StatusCodes.Status422UnprocessableEntity, _validatorDTOInsert.Validate(dto).Errors);
                }

                var entity = mapper.Map<CompaniaAerea>(dto);

                var response = await _companiaAereaDomainService.AddAsync(entity);

                return StatusCode(StatusCodes.Status201Created, response);
            }
            catch (ValidationException ex)
            {
                return StatusCode(StatusCodes.Status422UnprocessableEntity, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(CompaniaAerea), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromBody] CompaniaAereaDTOUpdate dto, [FromServices] IMapper mapper)
        {
            try
            {
                if (!_validatorDTOUpdate.Validate(dto).IsValid)
                {
                    return StatusCode(StatusCodes.Status422UnprocessableEntity, _validatorDTOUpdate.Validate(dto).Errors);
                }

                var entity = mapper.Map<CompaniaAerea>(dto);

                var response = await _companiaAereaDomainService.UpdateAsync(entity);

                return StatusCode(StatusCodes.Status201Created, response);
            }
            catch (ValidationException ex)
            {
                return StatusCode(StatusCodes.Status422UnprocessableEntity, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [ProducesResponseType(typeof(CompaniaAerea), StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete([FromBody] CompaniaAereaDTODelete dto, [FromServices] IMapper mapper)
        {
            try
            {
                if (!_validatorDTODelete.Validate(dto).IsValid)
                {
                    return StatusCode(StatusCodes.Status422UnprocessableEntity, _validatorDTODelete.Validate(dto).Errors);
                }

                var entity = mapper.Map<CompaniaAerea>(dto);
                var response = await _companiaAereaDomainService.DeleteAsync(entity);

                return StatusCode(StatusCodes.Status201Created, response);
            }
            catch (ValidationException ex)
            {
                return StatusCode(StatusCodes.Status422UnprocessableEntity, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<CompaniaAereaDTOResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromServices] IMapper mapper)
        {
            try
            {
                var lista = await _companiaAereaDomainService.GetByConditionAsync(
                    pageSize: 10,
                    pageNumber: 1,
                    orderBy: new Expression<Func<CompaniaAerea, object>>[]
                        { x => x.Nome}
                    ).ConfigureAwait(false);

                var response = mapper.Map<List<CompaniaAereaDTOResponse>>(lista);

                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
