using DomainSharedLib.Repository;
using FluentValidation;
using System.Linq.Expressions;
using ViagemApp.Domain.Entities;
using ViagemApp.Domain.Repository;
using ViagemApp.Domain.Service.BusinessValidator;

namespace ViagemApp.Domain.Service
{
    public class CompaniaAereaDomainService : ICompaniaAereaDomainService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly CompaniaAereaBusinessValidatorInsert _businessValidatorInsert;

        public CompaniaAereaDomainService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
            _businessValidatorInsert = new CompaniaAereaBusinessValidatorInsert(_unitOfWork.CompaniaAereaRepository);
        }

        public async Task<CompaniaAerea> DeleteAsync(CompaniaAerea entity)
        {
            await _unitOfWork.BeginTransactionAsync();
            await _unitOfWork.CompaniaAereaRepository.DeleteAsync(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        public async Task<CompaniaAerea> AddAsync(CompaniaAerea entity)
        {
            if (!_businessValidatorInsert.ValidateAsync(entity).Result)
            {
                throw new ValidationException(_businessValidatorInsert.GetAllErros());
            }
            try
            {
                await _unitOfWork.BeginTransactionAsync();
                await _unitOfWork.CompaniaAereaRepository.AddAsync(entity);
                await _unitOfWork.CommitAsync();
            }
            catch
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }

            return entity;

        }

        public async Task<CompaniaAerea> UpdateAsync(CompaniaAerea entity)
        {
            await _unitOfWork.BeginTransactionAsync();
            await _unitOfWork.CompaniaAereaRepository.UpdateAsync(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        public async Task<IEnumerable<CompaniaAerea?>> GetByConditionAsync(int pageSize = 10, int pageNumber = 1, Expression<Func<CompaniaAerea, bool>> predicate = null, Expression<Func<CompaniaAerea, object>>[] orderBy = null, bool isAscending = true, Expression<Func<CompaniaAerea, object>>[] includes = null)
        {
            return await _unitOfWork.CompaniaAereaRepository.GetByConditionAsync(pageSize, pageNumber, predicate, orderBy, isAscending, includes);
        }
    }
}
