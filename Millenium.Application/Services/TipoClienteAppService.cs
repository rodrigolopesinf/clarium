using Millenium.Application.Interfaces;
using Millenium.Domain.Entity;
using Millenium.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Millenium.Application.Services
{
    public class TipoClienteAppService : AppServiceBase<TipoCliente>, ITipoClienteAppService
    {
        private readonly ITipoClienteService _tipoClienteService;

        public TipoClienteAppService(ITipoClienteService tipoClienteService)
            : base(tipoClienteService)
        {
            _tipoClienteService = tipoClienteService;
        }

        public IEnumerable<TipoCliente> ObterTiposClientesAtivos()
        {
            return _tipoClienteService.ObterTiposClientesAtivos(_tipoClienteService.GetAll());
        }

        public IEnumerable<TipoCliente> ObterTiposClientesPelaDescricao(string descricao)
        {
            return _tipoClienteService.ObterTiposClientesPelaDescricao(_tipoClienteService.GetAll(), descricao);
        }
    }
}
