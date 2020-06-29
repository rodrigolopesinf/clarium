using Millenium.Domain.Entity;
using Millenium.Domain.Interfaces.Repositories;
using Millenium.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace Millenium.Domain.Services
{
    public class SolicitacaoService : ServiceBase<Solicitacao>, ISolicitacaoService
    {
        private readonly ISolicitacaoRepository _solicitacaoRepository;

        public SolicitacaoService(ISolicitacaoRepository solicitacaoRepository)
            : base(solicitacaoRepository)
        {
            _solicitacaoRepository = solicitacaoRepository;
        }

        public ISolicitacaoRepository SolicitacaoRepository => _solicitacaoRepository;

        public IEnumerable<Solicitacao> ObterSolicitacoesAtivas(IEnumerable<Solicitacao> solicitacoes)
        {
            return solicitacoes.Where(s => s.Excluido == null);
        }
    }
}
