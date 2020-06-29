using Millenium.Application.Interfaces;
using Millenium.Domain.Entity;
using Millenium.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Millenium.Application.Services
{
    public class ContatoAppService : AppServiceBase<Contato>, IContatoAppService
    {
        private readonly IContatoService _contatoService;

        public ContatoAppService(IContatoService contatoService)
            : base(contatoService)
        {
            _contatoService = contatoService;
        }
    }
}

