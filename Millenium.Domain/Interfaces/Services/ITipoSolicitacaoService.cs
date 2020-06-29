using Millenium.Domain.Entity;
using System.Collections.Generic;

namespace Millenium.Domain.Interfaces.Services
{
    public interface ITipoSolicitacaoService : IServiceBase<TipoSolicitacao>
    {
        IEnumerable<TipoSolicitacao> ObterTiposSolicitacoesAtivos(IEnumerable<TipoSolicitacao> tiposSolicitacao);
    }
}

