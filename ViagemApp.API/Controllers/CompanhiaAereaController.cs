﻿using AutoMapper;
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
    public class CompanhiaAereaController : ControllerBase
    {
        private readonly ICompanhiaAereaDomainService _companiaAereaDomainService;
        private readonly AbstractValidator<CompanhiaAereaDTODelete> _validatorDTODelete;
        private readonly AbstractValidator<CompanhiaAereaDTOUpdate> _validatorDTOUpdate;
        private readonly AbstractValidator<CompanhiaAereaDTOInsert> _validatorDTOInsert;

        public CompanhiaAereaController(
            ICompanhiaAereaDomainService companiaAereaDomainService, 
            AbstractValidator<CompanhiaAereaDTODelete> validatorDTODelete, 
            AbstractValidator<CompanhiaAereaDTOUpdate> validatorDTOUpdate, 
            AbstractValidator<CompanhiaAereaDTOInsert> validatorDTOInsert)
        {
            _companiaAereaDomainService = companiaAereaDomainService;
            _validatorDTODelete = validatorDTODelete;
            _validatorDTOUpdate = validatorDTOUpdate;
            _validatorDTOInsert = validatorDTOInsert;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CompanhiaAereaDTOResponse), StatusCodes.Status201Created)]
        public async Task<IActionResult> Insert([FromBody] CompanhiaAereaDTOInsert dto, [FromServices] IMapper mapper)
        {
            try
            {
                if (!_validatorDTOInsert.Validate(dto).IsValid)
                {
                    return StatusCode(StatusCodes.Status422UnprocessableEntity, _validatorDTOInsert.Validate(dto).Errors);
                }

                var entity = mapper.Map<CompanhiaAerea>(dto);

                var response = await _companiaAereaDomainService.AddAsync(entity);

                var responseDTO = mapper.Map<CompanhiaAereaDTOResponse>(response);

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
        [ProducesResponseType(typeof(CompanhiaAereaDTOResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromBody] CompanhiaAereaDTOUpdate dto, [FromServices] IMapper mapper)
        {
            try
            {
                if (!_validatorDTOUpdate.Validate(dto).IsValid)
                {
                    return StatusCode(StatusCodes.Status422UnprocessableEntity, _validatorDTOUpdate.Validate(dto).Errors);
                }

                var entity = mapper.Map<CompanhiaAerea>(dto);

                var response = await _companiaAereaDomainService.UpdateAsync(entity);
                var responseDTO = mapper.Map<CompanhiaAereaDTOResponse>(response);

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
        [ProducesResponseType(typeof(CompanhiaAereaDTOResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete([FromBody] CompanhiaAereaDTODelete dto, [FromServices] IMapper mapper)
        {
            try
            {
                if (!_validatorDTODelete.Validate(dto).IsValid)
                {
                    return StatusCode(StatusCodes.Status422UnprocessableEntity, _validatorDTODelete.Validate(dto).Errors);
                }

                var entity = mapper.Map<CompanhiaAerea>(dto);
                var response = await _companiaAereaDomainService.DeleteAsync(entity);
                var responseDTO = mapper.Map<CompanhiaAereaDTOResponse>(response);

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
        [ProducesResponseType(typeof(List<CompanhiaAereaDTOResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromServices] IMapper mapper)
        {
            try
            {
                var lista = await _companiaAereaDomainService.GetByConditionAsync(
                    pageSize: 10,
                    pageNumber: 1,
                    orderBy: new Expression<Func<CompanhiaAerea, object>>[]
                        { x => x.Nome}
                    ).ConfigureAwait(false);

                var responseDTO = mapper.Map<List<CompanhiaAereaDTOResponse>>(lista);

                return StatusCode(StatusCodes.Status200OK, responseDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
