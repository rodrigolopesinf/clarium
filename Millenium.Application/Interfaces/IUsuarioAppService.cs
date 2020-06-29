using Millenium.Domain.Entity;
using System.Collections.Generic;

namespace Millenium.Application.Interfaces
{
    public interface IUsuarioAppService : IAppServiceBase<Usuario>
    {
        IEnumerable<Usuario> ObterUsuariosAtivos();
        Usuario AutenticarUsuario(string login, string senha);
        Usuario ObterUsuarioLogin(string login);
    }
}

