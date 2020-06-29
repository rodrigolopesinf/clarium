using Millenium.Domain.Entity;
using Millenium.Domain.Interfaces.Repositories;
using Millenium.Domain.Interfaces.Services;

namespace Millenium.Domain.Services
{
    public class NivelService : ServiceBase<Nivel>, INivelService
    {
        private readonly INivelRepository _nivelRepository;

        public NivelService(INivelRepository nivelRepository)
            : base(nivelRepository)
        {
            _nivelRepository = nivelRepository;
        }
    }
}
