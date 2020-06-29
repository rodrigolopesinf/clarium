using Millenium.Application.Interfaces;
using Millenium.Domain.Entity;
using Millenium.Domain.Interfaces.Services;

namespace Millenium.Application.Services
{
    public class FaturamentoAppService : AppServiceBase<Faturamento>, IFaturamentoAppService
    {
        private readonly IFaturamentoService _faturamentoService;

        public FaturamentoAppService(IFaturamentoService faturamentoService)
            : base(faturamentoService)
        {
            _faturamentoService = faturamentoService;
        }
    }
}
