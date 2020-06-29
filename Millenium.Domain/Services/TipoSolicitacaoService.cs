using Millenium.Domain.Entity;
using Millenium.Domain.Interfaces.Repositories;
using Millenium.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace Millenium.Domain.Services
{
    public class TipoSolicitacaoService : ServiceBase<TipoSolicitacao>, ITipoSolicitacaoService
    {
        private readonly ITipoSolicitacaoRepository _tipoSolicitacaoRepository;

        public TipoSolicitacaoService(ITipoSolicitacaoRepository tipoSolicitacaoRepository)
            : base(tipoSolicitacaoRepository)
        {
            _tipoSolicitacaoRepository = tipoSolicitacaoRepository;
        }

        public IEnumerable<TipoSolicitacao> ObterTiposSolicitacoesAtivos(IEnumerable<TipoSolicitacao> tipoaSolicitacoes)
        {
            return tipoaSolicitacoes.Where(c => c.Ativo == true);
        }
    }
}

