using Millenium.Domain.Entity;
using Millenium.Domain.Interfaces.Repositories;
using Millenium.Domain.Interfaces.Services;

namespace Millenium.Domain.Services
{
    public class MenuService : ServiceBase<Menu>, IMenuService
    {
        private readonly IMenuRepository _menuRepository;

        public MenuService(IMenuRepository menuRepository)
            : base(menuRepository)
        {
            _menuRepository = menuRepository;
        }
    }
}
