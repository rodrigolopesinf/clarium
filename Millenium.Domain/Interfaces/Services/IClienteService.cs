using System.Collections.Generic;
using Millenium.Domain.Entity;

namespace Millenium.Domain.Interfaces.Services
{
    public interface IClienteService : IServiceBase<Cliente>
    {
        IEnumerable<Cliente> ObterClientesAtivos(IEnumerable<Cliente> clientes);
    }
}
