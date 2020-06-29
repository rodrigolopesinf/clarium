using Millenium.Application.Interfaces;
using Millenium.Domain.Entity;
using Millenium.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Millenium.Application.Services
{
    public class ContatoClienteAppService : AppServiceBase<ContatoCliente>, IContatoClienteAppService
    {
        private readonly IContatoClienteService _contatoClienteService;

        public ContatoClienteAppService(IContatoClienteService contatoClienteService)
            : base(contatoClienteService)
        {
            _contatoClienteService = contatoClienteService;
        }

        public IEnumerable<ContatoCliente> ObterContatosCliente(IEnumerable<ContatoCliente> contatosCliente, int idCliente)
        {
            return _contatoClienteService.ObterContatosCliente(contatosCliente, idCliente);
        }
    }
}

