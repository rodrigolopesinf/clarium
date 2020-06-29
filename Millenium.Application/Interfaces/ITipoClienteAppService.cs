using Millenium.Domain.Entity;
using System.Collections.Generic;

namespace Millenium.Application.Interfaces
{
    public interface ITipoClienteAppService : IAppServiceBase<TipoCliente>
    {
        IEnumerable<TipoCliente> ObterTiposClientesAtivos();
        IEnumerable<TipoCliente> ObterTiposClientesPelaDescricao(string descricao);
    }
}
