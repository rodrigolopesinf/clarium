using Millenium.Application.Interfaces;
using Millenium.Domain.Entity;
using Millenium.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Millenium.Application.Services
{
    public class TipoSolicitacaoAppService : AppServiceBase<TipoSolicitacao>, ITipoSolicitacaoAppService
    {
        private readonly ITipoSolicitacaoService _tipoSolicitacaoService;

        public TipoSolicitacaoAppService(ITipoSolicitacaoService tipoSolicitacaoService)
            : base(tipoSolicitacaoService)
        {
            _tipoSolicitacaoService = tipoSolicitacaoService;
        }

        public IEnumerable<TipoSolicitacao> ObterTiposSolicitacoesAtivos()
        {
            return _tipoSolicitacaoService.ObterTiposSolicitacoesAtivos(_tipoSolicitacaoService.GetAll());
        }
    }
}
