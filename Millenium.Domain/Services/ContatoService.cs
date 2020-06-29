using Millenium.Domain.Entity;
using Millenium.Domain.Interfaces.Repositories;
using Millenium.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace Millenium.Domain.Services
{
    public class ContatoService : ServiceBase<Contato>, IContatoService
    {
        private readonly IContatoRepository _contatoRepository;

        public ContatoService(IContatoRepository contatoRepository)
            : base(contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }

        public IEnumerable<Contato> ObterContatosAtivos(IEnumerable<Contato> contatos)
        {
            return contatos.Where(c => c.Ativo == true);
        }
    }
}
