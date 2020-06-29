using System.Collections.Generic;
using Millenium.Domain.Entity;

namespace Millenium.Domain.Interfaces.Services
{
    public interface IContatoClienteService : IServiceBase<ContatoCliente>
    {
        IEnumerable<ContatoCliente> ObterContatosCliente(IEnumerable<ContatoCliente> contatosCliente, int idCliente);
    }
}

