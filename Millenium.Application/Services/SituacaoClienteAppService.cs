using Millenium.Application.Interfaces;
using Millenium.Domain.Entity;
using Millenium.Domain.Interfaces.Services;

namespace Millenium.Application.Services
{
    public class SituacaoClienteAppService : AppServiceBase<SituacaoCliente>, ISituacaoClienteAppService
    {
        private readonly ISituacaoClienteService _situacaoClienteService;

        public SituacaoClienteAppService(ISituacaoClienteService situacaoClienteService)
            : base(situacaoClienteService)
        {
            _situacaoClienteService = situacaoClienteService;
        }
    }
}
