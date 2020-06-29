using Millenium.Domain.Entity;
using Millenium.Domain.Interfaces.Repositories;
using Millenium.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace Millenium.Domain.Services
{
    public class ContatoClienteService : ServiceBase<ContatoCliente>, IContatoClienteService
    {
        private readonly IContatoClienteRepository _contatoClienteRepository;

        public ContatoClienteService(IContatoClienteRepository contatoClienteRepository)
            : base(contatoClienteRepository)
        {
            _contatoClienteRepository = contatoClienteRepository;
        }

        public IEnumerable<ContatoCliente> ObterContatosCliente(IEnumerable<ContatoCliente> contatosCliente, int idCliente)
        {
            return contatosCliente.Where(c => c.IdCliente == idCliente);
        }
    }
}

