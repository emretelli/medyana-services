using Medyana.Services.Api.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medyana.Services.Api.Hub
{
    public class PatientHub : Hub<IHubClient>
    {
    }
}
