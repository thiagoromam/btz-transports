using BtzTransports.Contas;

namespace BtzTransports.Web.Models.Contas
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }

        public Usuario Converter()
        {
            return new Usuario
            {
                Id = Id,
                Nome = Nome,
                Login = Login,
            };
        }

        public static UsuarioModel Converter(Usuario usuario)
        {
            return new UsuarioModel
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Login = usuario.Login,
            };
        }
    }
}