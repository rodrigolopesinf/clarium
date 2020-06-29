using Millenium.Application.Interfaces;
using Millenium.Domain.Entity;
using Millenium.Domain.Services;
using Millenium.Infra.Data.Repositories;
using Millenium.Util;
using System.Collections.Generic;
using System.Linq;

namespace Site.Areas.Administrativa.Models
{
    public class MenuModels
    {
        private IEnumerable<Menu> _menus { get; set; }
        public int IdNivel { get; set; }
        private readonly IMenuAppService _menuApp;
        private readonly MenuRepository _menuRepository;
        private readonly MenuService _menuService;
        private readonly MenuUsuarioRepository _menuUsuarioRepository;
        private readonly MenuUsuarioService _menuUsuarioService;

        public MenuModels()
        {
            _menuRepository = new MenuRepository();
            _menuService = new MenuService(_menuRepository);
            _menuUsuarioRepository = new MenuUsuarioRepository();
            _menuUsuarioService = new MenuUsuarioService(_menuUsuarioRepository);
        }

        public MenuModels(IMenuAppService menuApp)
        {
            _menuApp = menuApp;
            _menus = _menuApp.ObterMenusPeloNivel(IdNivel);
        }

        public List<IMenu> GetMainMenu(int _idNivel)
        {
            IdNivel = _idNivel;
            var menuUsuario = _menuUsuarioService.GetAll();
            var list = menuUsuario.Where(x => x.IdNivel == IdNivel).ToList();

            var menus = (from m in _menuService.GetAll() where list.Any(mu => mu.IdMenu == m.IdMenu) select m).ToList();

            return menus.Select(menuUser => new MenuEntity
            {
                Id = menuUser.IdMenu,
                Descricao = menuUser.Descricao,
                MenuPaiId = menuUser.MenuPaiId,
                Url = menuUser.Url,
                Controller = menuUser.Controller,
                Route = menuUser.Route,
                Action = menuUser.Action
            }).Cast<IMenu>().ToList();
        }

        public List<IMenu> GetViewApp(int _idNivel)
        {
            IdNivel = _idNivel;
            var menuUsuario = _menuUsuarioService.GetAll();
            var list = menuUsuario.Where(x => x.IdNivel == IdNivel).ToList();

            var menus = (from m in _menuService.GetAll() where list.Any(mu => mu.IdMenu == m.IdMenu) select m).ToList();

            return menus.Select(viewApp => new MenuEntity
            {
                Id = viewApp.IdMenu,
                Descricao = viewApp.Descricao,
                Route = viewApp.Route,
                Controller = viewApp.Controller,
                MenuPaiId = viewApp.MenuPaiId,
                Url = viewApp.Url,
                Action = viewApp.Action
            }).Cast<IMenu>().ToList();

        }        
    }
}