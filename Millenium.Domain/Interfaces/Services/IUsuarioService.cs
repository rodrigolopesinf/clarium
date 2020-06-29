using Millenium.Domain.Entity;
using System.Collections.Generic;

namespace Millenium.Domain.Interfaces.Services
{
    public interface IUsuarioService : IServiceBase<Usuario>
    {
        IEnumerable<Usuario> ObterUsuariosAtivos(IEnumerable<Usuario> usuarios);
        Usuario AutenticarUsuario(IEnumerable<Usuario> usuarios, string login, string senha);
        Usuario ObterUsuarioLogin(IEnumerable<Usuario> usuarios, string login);
    }
}
