using Millenium.Application.Interfaces;
using Millenium.Domain.Interfaces.Services;
using Millenium.Domain.Entity;
using System.Collections.Generic;

namespace Millenium.Application.Services
{
    public class UsuarioAppService : AppServiceBase<Usuario>, IUsuarioAppService
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioAppService(IUsuarioService usuarioService)
            : base(usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public IEnumerable<Usuario> ObterUsuariosAtivos()
        {
            return _usuarioService.ObterUsuariosAtivos(_usuarioService.GetAll());
        }

        public Usuario AutenticarUsuario(string login, string senha)
        {
            return _usuarioService.AutenticarUsuario(_usuarioService.GetAll(), login, senha);
        }

        public Usuario ObterUsuarioLogin(string login)
        {
            return _usuarioService.ObterUsuarioLogin(_usuarioService.GetAll(), login);
        }
    }
}
