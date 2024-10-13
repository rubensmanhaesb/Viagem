using AutoMapper;
using DomainSharedLib.Shared;
using FluentValidation;
using MediatR;
using System.Linq.Expressions;
using ViagemApp.Application.DTO;
using ViagemApp.Application.Interfaces;
using ViagemApp.Application.Statics;
using ViagemApp.Application.Validation;
using ViagemApp.Domain.Entities;
using ViagemApp.Domain.Service;

namespace ViagemApp.Application.Services
{
    public class ProgramaFidelidadeApplicationService : IProgramaFidelidadeApplicationService
    {
        private readonly IProgramaFidelidadeDomainService _programaFidelidadeDomainService;
        private readonly IMapper _mapper;
        private readonly IProgramaFidelidadeFactoryDTOValidation _programaFidelidadeFactoryDTOValidation;
        private readonly IMediator _mediator;

        #region Construtor
        public ProgramaFidelidadeApplicationService(
            IProgramaFidelidadeDomainService programaFidelidadeDomainService,
            IProgramaFidelidadeFactoryDTOValidation programaFidelidadeFactoryDTOValidation,
            IMapper mapper,
            IMediator mediator)
        {
            _programaFidelidadeDomainService = programaFidelidadeDomainService;
            _programaFidelidadeFactoryDTOValidation = programaFidelidadeFactoryDTOValidation;
            _mapper = mapper;
            _mediator = mediator;
        }
        #endregion Construtor
        public async Task<ProgramaFidelidadeDTOResponse> AddAsync(ProgramaFidelidadeDTOInsert dto)
        {
            var validatorDTOInsert = _programaFidelidadeFactoryDTOValidation.GetValidator<ProgramaFidelidadeDTOInsert>();
            if (!validatorDTOInsert.Validate(dto).IsValid)
                throw new ValidationException(validatorDTOInsert.Validate(dto).Errors);

            var entity = _mapper.Map<ProgramaFidelidade>(dto);
            var response = await _programaFidelidadeDomainService.AddAsync(entity);
            await LogHelper.AddLogAsync(entity, new List<Guid?>() { entity.Id }, CrudOperation.Create, _mediator); ;
            var responseDTO = _mapper.Map<ProgramaFidelidadeDTOResponse>(response);

            return responseDTO;
        }

        public async Task<ProgramaFidelidadeDTOResponse> DeleteAsync(ProgramaFidelidadeDTODelete dto)
        {
            var validatorDTODelete = _programaFidelidadeFactoryDTOValidation.GetValidator<ProgramaFidelidadeDTODelete>();
            if (!validatorDTODelete.Validate(dto).IsValid)
            {
                throw new ValidationException(validatorDTODelete.Validate(dto).Errors);
            }

            var entity = _mapper.Map<ProgramaFidelidade>(dto);
            var response = await _programaFidelidadeDomainService.DeleteAsync(entity);
            await LogHelper.AddLogAsync(entity, new List<Guid?>() { entity.Id }, CrudOperation.Delete, _mediator); ;
            var responseDTO = _mapper.Map<ProgramaFidelidadeDTOResponse>(response);

            return responseDTO;
        }

        public void Dispose()
        {
            _programaFidelidadeDomainService.Dispose();
        }

        public async Task<List<ProgramaFidelidadeDTOResponse>> Get()
        {
            var lista = await _programaFidelidadeDomainService.GetByConditionAsync(
                pageSize: 10,
                pageNumber: 1,
                orderBy: new Expression<Func<ProgramaFidelidade, object>>[]
                    { x => x.Nome}
                ).ConfigureAwait(false);

            var responseDTO = _mapper.Map<List<ProgramaFidelidadeDTOResponse>>(lista);

            return responseDTO;

        }


        public async Task<ProgramaFidelidadeDTOResponse> UpdateAsync(ProgramaFidelidadeDTOUpdate dto)
        {
            var validatorDTOUpdate = _programaFidelidadeFactoryDTOValidation.GetValidator<ProgramaFidelidadeDTOUpdate>();

            if (!validatorDTOUpdate.Validate(dto).IsValid)
            {
                throw new ValidationException(validatorDTOUpdate.Validate(dto).Errors);
            }

            var entity = _mapper.Map<ProgramaFidelidade>(dto);

            var response = await _programaFidelidadeDomainService.UpdateAsync(entity);
            await LogHelper.AddLogAsync(entity, new List<Guid?>() { entity.Id }, CrudOperation.Update, _mediator); ;
            var responseDTO = _mapper.Map<ProgramaFidelidadeDTOResponse>(response);

            return responseDTO;
        }
    }
}
