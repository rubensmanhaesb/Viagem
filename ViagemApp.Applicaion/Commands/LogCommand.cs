using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViagemApp.Application.Models;

namespace ViagemApp.Application.Commands
{
    public class LogCommand : IRequest
    {
        public LogModel? Log { get; set; }
    }
}
