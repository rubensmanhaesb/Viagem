using DomainSharedLib.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViagemApp.Domain.Entities;

namespace ViagemApp.Domain.Repository
{
    public interface IUnitOfWork : IBaseUnitOfWork
    {
        public IBaseRepository<CompanhiaAerea> CompaniaAereaRepository { get; }
    }
}