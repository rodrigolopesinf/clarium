using Millenium.Domain.Entity;
using Millenium.Domain.Interfaces.Repositories;
using Millenium.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace Millenium.Domain.Services
{
    public class FaturamentoService : ServiceBase<Faturamento>, IFaturamentoService
    {
        private readonly IFaturamentoRepository _faturamentoRepository;

        public FaturamentoService(IFaturamentoRepository clienteRepository)
            : base(clienteRepository)
        {
            _faturamentoRepository = clienteRepository;
        }
    }
}

