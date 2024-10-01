using DomainSharedLib.ProtoType;
using FluentValidation;
using System.Linq.Expressions;
using ViagemApp.Domain.Entities;
using ViagemApp.Domain.Repository;
using ViagemApp.Domain.Service.BusinessValidator;

namespace ViagemApp.Domain.Service
{
    public class ProgramaFidelidadeDomainService : IProgramaFidelidadeDomainService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidatorFactory<ProgramaFidelidade> _validatorFactory;

        #region Constructor
        public ProgramaFidelidadeDomainService(IUnitOfWork unitOfWork, 
            IValidatorFactory<ProgramaFidelidade> validatorFactory)
        {
            _unitOfWork = unitOfWork;
            _validatorFactory = validatorFactory;
        }
        #endregion Constructor
        public async Task<IEnumerable<ProgramaFidelidade?>> GetByConditionAsync(int? pageSize = null, int? pageNumber = null, Expression<Func<ProgramaFidelidade, bool>> predicate = null, Expression<Func<ProgramaFidelidade, object>>[] orderBy = null, bool isAscending = true, Expression<Func<ProgramaFidelidade, object>>[] includes = null)
        {
            return await _unitOfWork.ProgramaFidelidadeRepository.GetByConditionAsync(pageSize, pageNumber, predicate, orderBy, isAscending, includes);
        }
        private async Task ValidateAsync(ProgramaFidelidade entity, OperationType operationType)
        {
            var validator = _validatorFactory.CreateValidator(operationType);
            var validationResult = await validator.ValidateAsync(entity);

            if (validationResult)
                throw new ValidationException(validator.GetAllErros());

        }
        public async Task<ProgramaFidelidade> AddAsync(ProgramaFidelidade entity)
        {
            try
            {
                await ValidateAsync(entity, OperationType.Create);

                await _unitOfWork.BeginTransactionAsync();
                _unitOfWork.ProgramaFidelidadeRepository.Add(entity);
                await _unitOfWork.CommitAsync();
            }
            catch
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }

            return EntityProtoType.CopyProperties(entity);

        }

        public async Task<ProgramaFidelidade> DeleteAsync(ProgramaFidelidade entity)
        {
            try
            {
                await ValidateAsync(entity, OperationType.Delete);

                await _unitOfWork.BeginTransactionAsync();
                _unitOfWork.ProgramaFidelidadeRepository.Delete(entity);
                await _unitOfWork.CommitAsync();
            }
            catch
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }

            return EntityProtoType.CopyProperties(entity);
        }

        public async Task<ProgramaFidelidade> UpdateAsync(ProgramaFidelidade entity)
        {
            try
            {
                await ValidateAsync(entity, OperationType.Update);

                await _unitOfWork.BeginTransactionAsync();
                _unitOfWork.ProgramaFidelidadeRepository.Update(entity);
                await _unitOfWork.CommitAsync();
            }
            catch
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }

            return EntityProtoType.CopyProperties(entity);
        }
    }
}
