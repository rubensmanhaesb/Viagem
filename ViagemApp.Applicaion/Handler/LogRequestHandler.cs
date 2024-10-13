using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViagemApp.Application.Commands;
using ViagemApp.Application.Interfaces.Logs;

namespace ViagemApp.Application.Handler
{
    public class LogRequestHandler : IRequestHandler<LogCommand>
    {
        private readonly ILogDataStore _logDataStore;

        public LogRequestHandler(ILogDataStore logDataStore)
        {
            _logDataStore = logDataStore;
        }

        public async Task Handle(LogCommand request, CancellationToken cancellationToken)
        {
            await _logDataStore.AddAsync(request.Log);
        }
    }
}
