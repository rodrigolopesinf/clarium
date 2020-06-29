using Millenium.Application.Interfaces;
using Millenium.Domain.Entity;
using Millenium.Domain.Interfaces.Services;

namespace Millenium.Application.Services
{
    public class NivelAppService : AppServiceBase<Nivel>, INivelAppService
    {
        private readonly INivelService _nivelService;

        public NivelAppService(INivelService nivelService)
            : base(nivelService)
        {
            _nivelService = nivelService;
        }
    }
}
