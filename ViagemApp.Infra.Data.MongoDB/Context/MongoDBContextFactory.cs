using DomainSharedLib.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViagemApp.Infra.Data.MongoDB.Context
{
    public class MongoDBContextFactory : IDbContextFactory
    {
        public DbContext CreateDbContext()
        {
            throw new NotImplementedException();
        }
    }
}
