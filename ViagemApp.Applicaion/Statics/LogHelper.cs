using DomainSharedLib.Shared;
using MediatR;
using Newtonsoft.Json;
using ViagemApp.Application.Commands;
using ViagemApp.Application.Models;

namespace ViagemApp.Application.Statics
{
    public static class LogHelper
    {
        public static async Task AddLogAsync<T>(T entity, List<Guid?> Ids, CrudOperation tipoOperacao, IMediator mediator) where T : class
        {
            //string objectId = string.Join(",", Ids);

            await mediator.Send(new LogCommand
            {
                Log = new LogModel()
                {
                    Id = Guid.NewGuid(),
                    DataOperacao = DateTime.Now,
                    TipoOperacao = tipoOperacao,
                    ObjectIds = Ids, // (entity as dynamic).Id, // Assumindo que todas as entidades têm uma propriedade Id
                    Dados = JsonConvert.SerializeObject(entity)
                }
            });
        }
    }
}