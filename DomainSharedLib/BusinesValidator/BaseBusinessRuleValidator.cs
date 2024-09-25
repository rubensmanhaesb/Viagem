using DomainSharedLib.Context;
using DomainSharedLib.Repositories;
using DomainSharedLib.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DomainSharedLib.BusinesValidator
{
    public abstract class BaseBusinessRuleValidator<T> : IDisposable where T : class
    {
        protected readonly List<string> _errors = new List<string>();
        private readonly IDbContextFactory _dbContextFactory;

        protected BaseBusinessRuleValidator(IDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public IReadOnlyCollection<string> Errors => _errors.AsReadOnly();

        public string GetAllErros()
        {
            var sb = new StringBuilder();
            foreach (var error in _errors)
            {
                sb.AppendLine(error);
            }

            return sb.ToString();
        }
        // Método genérico para validar regras de negócio
        public abstract  Task<bool> ValidateAsync(T entity);

        protected void AddError(string message)
        {
            _errors.Add(message);
        }

        public bool HasErrors()
        {
            return _errors.Any();
        }

        public void ClearErrors()
        {
            _errors.Clear();
        }

        public async virtual Task<bool> CheckExistsAsync(
            Expression<Func<T, bool>> predicate,
            Func<IEnumerable<T>, bool> validationLogic,
            Func<T, string> errorMessage,
            IList<string> errorList = null,
            Expression<Func<T, object>>[] includes = null)
        {
            var query = new BaseQueryRepository<T>(_dbContextFactory.CreateDbContext());

            var result = await query.GetByConditionAsync(predicate: predicate, includes: includes).ConfigureAwait(false);

            if (validationLogic(result))
            {
                var strError = errorMessage(result.FirstOrDefault<T>());
                AddError(strError);
            }

            return validationLogic(result);
        }

        public void Dispose()
        { 
            GC.SuppressFinalize(this);
        }
    }

}
