﻿using DomainSharedLib.Repositories;
using DomainSharedLib.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using ViagemApp.Domain.Entities;
using ViagemApp.Domain.Repository;

namespace ViagemAApp.Repository.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;
        private IDbContextTransaction _transaction;
        public IBaseRepository<CompanhiaAerea> CompaniaAereaRepository { get; private set; }

        public UnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
            CompaniaAereaRepository = new BaseRepository<CompanhiaAerea>(_dbContext);
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
            GC.SuppressFinalize(this);
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
