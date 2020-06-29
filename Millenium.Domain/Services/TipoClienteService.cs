using Millenium.Domain.Entity;
using Millenium.Domain.Interfaces.Repositories;
using Millenium.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace Millenium.Domain.Services
{
    public class TipoClienteService : ServiceBase<TipoCliente>, ITipoClienteService
    {
        private readonly ITipoClienteRepository _tipoClienteRepository;

        public TipoClienteService(ITipoClienteRepository tipoClienteRepository)
            : base(tipoClienteRepository)
        {
            _tipoClienteRepository = tipoClienteRepository;
        }

        public ITipoClienteRepository TipoClienteRepository => _tipoClienteRepository;

        public IEnumerable<TipoCliente> ObterTiposClientesAtivos(IEnumerable<TipoCliente> tiposClientes)
        {
            return tiposClientes.Where(c => c.Ativo == true);
        }

        public IEnumerable<TipoCliente> ObterTiposClientesPelaDescricao(IEnumerable<TipoCliente> tiposClientes, string descricao)
        {
            return tiposClientes.Where(t => t.Descricao.Contains(descricao));
        }
    }
}

