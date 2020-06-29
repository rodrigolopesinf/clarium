using Millenium.Domain.Entity;
using Millenium.Domain.Interfaces.Repositories;
using Millenium.Domain.Interfaces.Services;

namespace Millenium.Domain.Services
{
    public class MenuUsuarioService : ServiceBase<MenuUsuario>, IMenuUsuarioService
    {
        private readonly IMenuUsuarioRepository _menuUsuarioRepository;

        public MenuUsuarioService(IMenuUsuarioRepository menuUsuarioRepository)
            : base(menuUsuarioRepository)
        {
            _menuUsuarioRepository = menuUsuarioRepository;
        }
    }
}

