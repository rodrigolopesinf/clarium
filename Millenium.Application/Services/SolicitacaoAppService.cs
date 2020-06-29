using Millenium.Application.Interfaces;
using Millenium.Domain.Entity;
using Millenium.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Millenium.Application.Services
{
    public class SolicitacaoAppService : AppServiceBase<Solicitacao>, ISolicitacaoAppService
    {
        private readonly ISolicitacaoService _solicitacaoService;

        public SolicitacaoAppService(ISolicitacaoService solicitacaoService)
            : base(solicitacaoService)
        {
            _solicitacaoService = solicitacaoService;
        }
        
        public IEnumerable<Solicitacao> ObterSolicitacoesAtivas()
        {
            return _solicitacaoService.ObterSolicitacoesAtivas(_solicitacaoService.GetAll());
        }
    }
}
