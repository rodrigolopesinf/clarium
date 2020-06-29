using Millenium.Domain.Entity;
using System.Collections.Generic;

namespace Millenium.Domain.Interfaces.Services
{
    public interface ISolicitacaoService : IServiceBase<Solicitacao>
    {
        IEnumerable<Solicitacao> ObterSolicitacoesAtivas(IEnumerable<Solicitacao> solicitacoes);
    }
}
