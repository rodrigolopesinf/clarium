using Millenium.Application.Interfaces;
using Millenium.Domain.Entity;
using Millenium.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace Millenium.Application.Services
{
    public class MenuAppService : AppServiceBase<Menu>, IMenuAppService
    {
        private readonly IMenuService _menuService;
        private readonly IMenuUsuarioService _menuUsuarioService;

        public MenuAppService(IMenuService menuService, IMenuUsuarioService menuUsuarioService)
            : base(menuService)
        {
            _menuService = menuService;
            _menuUsuarioService = menuUsuarioService;
        }

        public IEnumerable<Menu> ObterMenusPeloNivel(int idNivel)
        {
            return  (IEnumerable<Menu>)(from menu in _menuService.GetAll()
              join menuUsuario in _menuUsuarioService.GetAll() on menu.IdMenu equals menuUsuario.IdMenu
              where menuUsuario.IdNivel == idNivel
              select new { Menu = menu.Descricao, menuUsuario.IdNivel }).ToList();
        }
    }
}