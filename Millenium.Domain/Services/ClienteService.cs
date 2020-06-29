using Millenium.Domain.Entity;
using Millenium.Domain.Interfaces.Repositories;
using Millenium.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace Millenium.Domain.Services
{
    public class ClienteService : ServiceBase<Cliente>, IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
            : base(clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public IClienteRepository ClienteRepository => _clienteRepository;

        public IEnumerable<Cliente> ObterClientesAtivos(IEnumerable<Cliente> clientes)
        {
            return clientes.Where(c => c.Ativo);
        }
    }
}
