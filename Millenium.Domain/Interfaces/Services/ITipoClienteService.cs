using Millenium.Domain.Entity;
using System.Collections.Generic;

namespace Millenium.Domain.Interfaces.Services
{
    public interface ITipoClienteService : IServiceBase<TipoCliente>
    {
        IEnumerable<TipoCliente> ObterTiposClientesAtivos(IEnumerable<TipoCliente> tiposClientes);
        IEnumerable<TipoCliente> ObterTiposClientesPelaDescricao(IEnumerable<TipoCliente> tiposClientes, string descricao);
    }
}
