using Millenium.Domain.Entity;
using Millenium.Domain.Interfaces.Repositories;
using Millenium.Domain.Interfaces.Services;

namespace Millenium.Domain.Services
{
    public class SituacaoClienteService : ServiceBase<SituacaoCliente>, ISituacaoClienteService
    {
        private readonly ISituacaoClienteRepository _situacaoClienteRepository;

        public SituacaoClienteService(ISituacaoClienteRepository situacaoClienteRepository)
            : base(situacaoClienteRepository)
        {
            _situacaoClienteRepository = situacaoClienteRepository;
        }
    }
}
