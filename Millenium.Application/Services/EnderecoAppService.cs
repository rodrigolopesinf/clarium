using Millenium.Application.Interfaces;
using Millenium.Domain.Entity;
using Millenium.Domain.Interfaces.Services;

namespace Millenium.Application.Services
{
    public class EnderecoAppService : AppServiceBase<Endereco>, IEnderecoAppService
    {
        private readonly IEnderecoService _enderecoService;

        public EnderecoAppService(IEnderecoService enderecoService)
            : base(enderecoService)
        {
            _enderecoService = enderecoService;
        }
    }
}