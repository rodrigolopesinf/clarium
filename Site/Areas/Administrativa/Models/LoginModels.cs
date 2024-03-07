using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Site.Areas.Administrativa.Models
{
    public class LoginModels
    {
        public LoginModels() { ListaTipoSolicitacao = new List<SelectListItem>(); }

        [Required(ErrorMessage = "* O usuário deve ser informado!")]
        public string Login { get; set; }

        [Required(ErrorMessage = "* A senha deve ser informada!")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        public string UsuarioInvalido { get; set; }
        public List<SelectListItem> ListaTipoSolicitacao { get; set; }
        public int IdTipoSolicitacao { get; set; }
        public string DescricaoTipoSolicitacao { get; set; }

    }
}