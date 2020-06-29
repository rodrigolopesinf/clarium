using Millenium.Domain.Entity;
using System.Collections.Generic;

namespace Millenium.Application.Interfaces
{
    public interface IClienteAppService : IAppServiceBase<Cliente>
    {
        IEnumerable<Cliente> ObterClientesAtivos();
    }
}

