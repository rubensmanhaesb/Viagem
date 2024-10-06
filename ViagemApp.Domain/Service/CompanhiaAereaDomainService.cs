using DomainSharedLib.ProtoType;
using DomainSharedLib.Shared;
using FluentValidation;
using System.Linq.Expressions;
using ViagemApp.Domain.Entities;
using ViagemApp.Domain.Repository;
using ViagemApp.Domain.Service.BusinessValidation;

namespace ViagemApp.Domain.Service
{
    public class CompanhiaAereaDomainService : ICompanhiaAereaDomainService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidatorFactory<CompanhiaAerea> _validatorFactory;

        #region Construtor
        public CompanhiaAereaDomainService(IUnitOfWork unitOfWork,
            IValidatorFactory<CompanhiaAerea> companiaAereaValidatorFactory)
        {
            _unitOfWork = unitOfWork;
            _validatorFactory = companiaAereaValidatorFactory;
        }
        #endregion #Construtor

        public async Task<IEnumerable<CompanhiaAerea?>> GetByConditionAsync(int? pageSize = null, int? pageNumber = null, Expression<Func<CompanhiaAerea, bool>> predicate = null, Expression<Func<CompanhiaAerea, object>>[] orderBy = null, bool isAscending = true, Expression<Func<CompanhiaAerea, object>>[] includes = null)
        {
            return await _unitOfWork.CompaniaAereaRepository.GetByConditionAsync(pageSize, pageNumber, predicate, orderBy, isAscending, includes);
        }

        private async Task ValidateAsync(CompanhiaAerea entity, CrudOperation operationType)
        {
            var validator = _validatorFactory.CreateValidator(operationType);
            var validationResult = await validator.ValidateAsync(entity);

            if (validationResult)
                throw new ValidationException(validator.GetAllErros());

        }

        public async Task<CompanhiaAerea> AddAsync(CompanhiaAerea entity)
        {
            try
            {
                await ValidateAsync(entity, CrudOperation.Create);

                await _unitOfWork.BeginTransactionAsync();
                _unitOfWork.CompaniaAereaRepository.Add(entity);
                await _unitOfWork.CommitAsync();
            }
            catch
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }

            return EntityProtoType.CopyProperties(entity); 

        }

        public async Task<CompanhiaAerea> UpdateAsync(CompanhiaAerea entity)
        {
            try
            {
                await ValidateAsync(entity, CrudOperation.Update);

                await _unitOfWork.BeginTransactionAsync();
                _unitOfWork.CompaniaAereaRepository.Update(entity);
                await _unitOfWork.CommitAsync();
            }
            catch
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }

            return EntityProtoType.CopyProperties(entity);

        }

        public async Task<CompanhiaAerea> DeleteAsync(CompanhiaAerea entity)
        {
            try
            {
                await ValidateAsync(entity, CrudOperation.Delete);

                await _unitOfWork.BeginTransactionAsync();
                 _unitOfWork.CompaniaAereaRepository.Delete(entity);
                await _unitOfWork.CommitAsync();
            }
            catch
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }

            return EntityProtoType.CopyProperties(entity); 
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
