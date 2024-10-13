using AutoMapper;
using DomainSharedLib.Shared;
using FluentValidation;
using MediatR;
using System.Linq.Expressions;
using ViagemApp.Application.Commands;
using ViagemApp.Application.DTO;
using ViagemApp.Application.Interfaces;
using ViagemApp.Application.Models;
using ViagemApp.Application.Validation;
using ViagemApp.Domain.Entities;
using ViagemApp.Domain.Service;
using ViagemApp.Application.Statics;

namespace ViagemApp.Application.Services
{
    public class CompanhiaAereaApplicationService : ICompanhiaAereaApplicationService
    {
        private readonly ICompanhiaAereaDomainService _companiaAereaDomainService;
        private readonly IMapper _mapper;
        private readonly ICompanhiaAereaFactoryDTOValidation _companhiaAereaFactoryDTOValidation;
        private readonly IMediator _mediator;

        #region Construtor
        public CompanhiaAereaApplicationService(
            ICompanhiaAereaDomainService companiaAereaDomainService,
            ICompanhiaAereaFactoryDTOValidation companhiaAereaFactoryDTOValidation,
            IMapper mapper,
            IMediator mediator)
        {
            _companiaAereaDomainService = companiaAereaDomainService;
            _companhiaAereaFactoryDTOValidation = companhiaAereaFactoryDTOValidation;
            _mapper = mapper;
            _mediator = mediator;
        }
        #endregion Construtor


        public async Task<CompanhiaAereaDTOResponse> AddAsync(CompanhiaAereaDTOInsert dto )
        { 
            var validatorDTOInsert = _companhiaAereaFactoryDTOValidation.GetValidator<CompanhiaAereaDTOInsert>();
            if (!validatorDTOInsert.Validate(dto).IsValid)
                throw new ValidationException(validatorDTOInsert.Validate(dto).Errors);
            
            var entity = _mapper.Map<CompanhiaAerea>(dto);
            var response = await _companiaAereaDomainService.AddAsync(entity);
            await LogHelper.AddLogAsync(entity, new List<Guid?>() { entity.Id }, CrudOperation.Create, _mediator);

            var responseDTO = _mapper.Map<CompanhiaAereaDTOResponse>(response);
            
            return responseDTO;
        }

        public async Task<CompanhiaAereaDTOResponse> DeleteAsync(CompanhiaAereaDTODelete dto)
        {
            var validatorDTODelete = _companhiaAereaFactoryDTOValidation.GetValidator<CompanhiaAereaDTODelete>();
            if (!validatorDTODelete.Validate(dto).IsValid)
            {
                throw new ValidationException(validatorDTODelete.Validate(dto).Errors);
            }
             
            var entity = _mapper.Map<CompanhiaAerea>(dto);
            var response = await _companiaAereaDomainService.DeleteAsync(entity);
            await LogHelper.AddLogAsync(entity, new List<Guid?>() { entity.Id }, CrudOperation.Delete, _mediator); ;
            var responseDTO = _mapper.Map<CompanhiaAereaDTOResponse>(response);

            return responseDTO;
        }

        public void Dispose()
        {
            _companiaAereaDomainService.Dispose();
        }

        public async Task<List<CompanhiaAereaDTOResponse>> Get()
        {
            var lista = await _companiaAereaDomainService.GetByConditionAsync(
                pageSize: 10,
                pageNumber: 1,
                orderBy: new Expression<Func<CompanhiaAerea, object>>[]
                    { x => x.Nome}
                ).ConfigureAwait(false);

            var responseDTO = _mapper.Map<List<CompanhiaAereaDTOResponse>>(lista);

            return responseDTO;

        }

        public async Task<CompanhiaAereaDTOResponse> UpdateAsync(CompanhiaAereaDTOUpdate dto)
        {
            var validatorDTOUpdate= _companhiaAereaFactoryDTOValidation.GetValidator<CompanhiaAereaDTOUpdate>();
            if (!validatorDTOUpdate.Validate(dto).IsValid)
            {
                throw new ValidationException(validatorDTOUpdate.Validate(dto).Errors);
            }

            var entity = _mapper.Map<CompanhiaAerea>(dto);

            var response = await _companiaAereaDomainService.UpdateAsync(entity);
            await LogHelper.AddLogAsync(entity, new List<Guid?>() { entity.Id }, CrudOperation.Update, _mediator);

            var responseDTO = _mapper.Map<CompanhiaAereaDTOResponse>(response);

            
            return responseDTO;
        }
    }
}
