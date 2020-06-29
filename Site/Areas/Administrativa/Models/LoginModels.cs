using System.ComponentModel.DataAnnotations;

namespace Site.Areas.Administrativa.Models
{
    public class LoginModels
    {
        [Required(ErrorMessage = "* O usuário deve ser informado!")]
        public string Login { get; set; }

        [Required(ErrorMessage = "* A senha deve ser informada!")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        public string UsuarioInvalido { get; set; }
    }
}