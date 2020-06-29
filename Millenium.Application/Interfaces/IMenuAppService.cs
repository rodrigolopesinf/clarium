using Millenium.Domain.Entity;
using System.Collections.Generic;

namespace Millenium.Application.Interfaces
{
    public interface IMenuAppService : IAppServiceBase<Menu>
    {
        IEnumerable<Menu> ObterMenusPeloNivel(int idNivel);
    }
}

