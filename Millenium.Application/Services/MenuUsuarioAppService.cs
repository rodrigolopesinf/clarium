using Millenium.Application.Interfaces;
using Millenium.Domain.Entity;
using Millenium.Domain.Interfaces.Services;

namespace Millenium.Application.Services
{
    public class MenuUsuarioAppService : AppServiceBase<MenuUsuario>, IMenuUsuarioAppService
    {
        private readonly IMenuUsuarioService _menuUsuarioService;

        public MenuUsuarioAppService(IMenuUsuarioService menuUsuarioService)
            : base(menuUsuarioService)
        {
            _menuUsuarioService = menuUsuarioService;
        }
    }
}
