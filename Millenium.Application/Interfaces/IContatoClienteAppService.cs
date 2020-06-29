using Millenium.Domain.Entity;
using System.Collections.Generic;

namespace Millenium.Application.Interfaces
{
    public interface IContatoClienteAppService : IAppServiceBase<ContatoCliente>
    {
        IEnumerable<ContatoCliente> ObterContatosCliente(IEnumerable<ContatoCliente> contatosCliente,int idCliente);
    }
}
