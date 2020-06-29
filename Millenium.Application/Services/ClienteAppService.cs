using Millenium.Application.Interfaces;
using Millenium.Domain.Entity;
using Millenium.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Millenium.Application.Services
{
    public class ClienteAppService : AppServiceBase<Cliente>, IClienteAppService
    {
        private readonly IClienteService _clienteService;

        public ClienteAppService(IClienteService clienteService)
            : base(clienteService)
        {
            _clienteService = clienteService;
        }

        public IEnumerable<Cliente> ObterClientesAtivos()
        {
            return _clienteService.ObterClientesAtivos(_clienteService.GetAll());
        }
    }
}
