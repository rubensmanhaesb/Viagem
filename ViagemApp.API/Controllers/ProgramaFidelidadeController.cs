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
    public class ProgramaFidelidadeController : ControllerBase
    {
        private readonly IProgramaFidelidadeDomainService _programaFidelidadeDomainService;
        private readonly AbstractValidator<ProgramaFidelidadeDTODelete> _validatorDTODelete;
        private readonly AbstractValidator<ProgramaFidelidadeDTOUpdate> _validatorDTOUpdate;
        private readonly AbstractValidator<ProgramaFidelidadeDTOInsert> _validatorDTOInsert;

        public ProgramaFidelidadeController(
            IProgramaFidelidadeDomainService programaFidelidadeDomainService,
            AbstractValidator<ProgramaFidelidadeDTODelete> validatorDTODelete,
            AbstractValidator<ProgramaFidelidadeDTOUpdate> validatorDTOUpdate,
            AbstractValidator<ProgramaFidelidadeDTOInsert> validatorDTOInsert)
        {
            _programaFidelidadeDomainService = programaFidelidadeDomainService;
            _validatorDTODelete = validatorDTODelete;
            _validatorDTOUpdate = validatorDTOUpdate;
            _validatorDTOInsert = validatorDTOInsert;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ProgramaFidelidadeDTOResponse), StatusCodes.Status201Created)]
        public async Task<IActionResult> Insert([FromBody] ProgramaFidelidadeDTOInsert dto, [FromServices] IMapper mapper)
        {
            try
            {
                if (!_validatorDTOInsert.Validate(dto).IsValid)
                {
                    return StatusCode(StatusCodes.Status422UnprocessableEntity, _validatorDTOInsert.Validate(dto).Errors);
                }

                var entity = mapper.Map<ProgramaFidelidade>(dto);

                var response = await _programaFidelidadeDomainService.AddAsync(entity);

                var responseDTO = mapper.Map<ProgramaFidelidadeDTOResponse>(response);

                return StatusCode(StatusCodes.Status201Created, responseDTO);
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
        [ProducesResponseType(typeof(ProgramaFidelidadeDTOResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromBody] ProgramaFidelidadeDTOUpdate dto, [FromServices] IMapper mapper)
        {
            try
            {
                if (!_validatorDTOUpdate.Validate(dto).IsValid)
                {
                    return StatusCode(StatusCodes.Status422UnprocessableEntity, _validatorDTOUpdate.Validate(dto).Errors);
                }

                var entity = mapper.Map<ProgramaFidelidade>(dto);

                var response = await _programaFidelidadeDomainService.UpdateAsync(entity);
                var responseDTO = mapper.Map<ProgramaFidelidadeDTOResponse>(response);

                return StatusCode(StatusCodes.Status201Created, responseDTO);
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
        [ProducesResponseType(typeof(ProgramaFidelidadeDTOResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete([FromBody] ProgramaFidelidadeDTODelete dto, [FromServices] IMapper mapper)
        {
            try
            {
                if (!_validatorDTODelete.Validate(dto).IsValid)
                {
                    return StatusCode(StatusCodes.Status422UnprocessableEntity, _validatorDTODelete.Validate(dto).Errors);
                }

                var entity = mapper.Map<ProgramaFidelidade>(dto);
                var response = await _programaFidelidadeDomainService.DeleteAsync(entity);
                var responseDTO = mapper.Map<ProgramaFidelidadeDTOResponse>(response);

                return StatusCode(StatusCodes.Status201Created, responseDTO);
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
        [ProducesResponseType(typeof(List<ProgramaFidelidadeDTOResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromServices] IMapper mapper)
        {
            try
            {
                var lista = await _programaFidelidadeDomainService.GetByConditionAsync(
                    pageSize: 10,
                    pageNumber: 1,
                    orderBy: new Expression<Func<ProgramaFidelidade, object>>[]
                        { x => x.Nome}
                    ).ConfigureAwait(false);

                var responseDTO = mapper.Map<List<ProgramaFidelidadeDTOResponse>>(lista);

                return StatusCode(StatusCodes.Status200OK, responseDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
