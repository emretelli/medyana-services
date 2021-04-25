using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medyana.Services.Api.Hub
{
    public interface IHubClient
    {
        Task Notify();
    }
}
