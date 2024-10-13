using ViagemApp.Application.Interfaces.Logs;
using ViagemApp.Application.Models;
using ViagemApp.Infra.Data.MongoDB.Context;
using MongoDB.Driver;


namespace ViagemApp.Infra.Data.MongoDB.Storage
{
    /// <summary>
    /// Implementação da interface da camada de aplicação
    /// para geração dos logs de clientes no MongoDB
    /// </summary>
    public class LogDataStore : ILogDataStore
    {
        private readonly MongoDBContext _mongoDBContext;

        public LogDataStore(MongoDBContext mongoDBContext)
        {
            _mongoDBContext = mongoDBContext;
        }

        public async Task AddAsync(LogModel model)
        {
            await _mongoDBContext.Log.InsertOneAsync(model);
        }

        public async Task<List<LogModel>> GetAsync(Guid Id, int pageNumber, int pageSize)
        {
            //definindo o filtro para consultar somente logs de um determinado cliente
            var filter = Builders<LogModel>.Filter.Eq(log => log.Id, Id);

            //construindo a consulta com a paginação
            var result = await _mongoDBContext.Log
                .Find(filter) //aplicando o filtro
                .Skip((pageNumber - 1) * pageSize)
                .Limit(pageSize)
                .SortByDescending(log => log.DataOperacao)
                .ToListAsync();

            return result;
        }

        public async Task<int> GetTotalCountAsync(Guid Id)
        {
            //definindo o filtro para consultar somente logs de um determinado cliente
            var filter = Builders<LogModel>.Filter.Eq(log => log.Id, Id);

            return (int)await _mongoDBContext.Log.CountDocumentsAsync(filter);
        }
    }
}



