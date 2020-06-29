using Millenium.Domain.Entity;
using System.Collections.Generic;

namespace Millenium.Application.Interfaces
{
    public interface ISolicitacaoAppService : IAppServiceBase<Solicitacao>
    {
        IEnumerable<Solicitacao> ObterSolicitacoesAtivas();
    }
}
