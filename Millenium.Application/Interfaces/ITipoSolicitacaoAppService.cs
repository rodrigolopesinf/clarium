using Millenium.Domain.Entity;
using System.Collections.Generic;

namespace Millenium.Application.Interfaces
{
    public interface ITipoSolicitacaoAppService : IAppServiceBase<TipoSolicitacao>
    {
        IEnumerable<TipoSolicitacao> ObterTiposSolicitacoesAtivos();
    }
}

