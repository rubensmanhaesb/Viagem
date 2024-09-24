using DomainSharedLib.Repository;
using Infrasctructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using ViagemAApp.Repository.Context;
using ViagemApp.Domain.Entities;
using ViagemApp.Domain.Repository;

namespace ViagemAApp.Repository.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dbContext;
        private IDbContextTransaction _transaction;
        public IBaseRepository<CompaniaAerea> CompaniaAereaRepository { get; private set; }

        public UnitOfWork(DataContext dbContext)
        {
            _dbContext = dbContext;
            CompaniaAereaRepository = new BaseRepository<CompaniaAerea>(_dbContext);// DbContextFactory.CreateDbContext(_dbContext.Database.GetConnectionString()));
        }

        public async Task BeginTransactionAsync()
        {
            if (_transaction == null)
                _transaction =  await _dbContext.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            try
            {
                 await _dbContext.SaveChangesAsync();

                if (_transaction!=null)
                    await _transaction.CommitAsync();
            }
            catch
            {
                await _transaction.RollbackAsync();
                throw;
            }
            finally
            {
                _transaction?.DisposeAsync();
                _transaction = null;
            }
        }

        public void Dispose()
        {
            _dbContext.DisposeAsync();
        }

        public async Task RollbackAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }
    }
}
