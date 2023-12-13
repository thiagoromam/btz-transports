using BtzTransports.Contas;
using BtzTransports.Web.Models.Contas;
using General.Helpers;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Security.Claims;
using System.Web.Http;

namespace BtzTransports.Web.Api
{
    [RoutePrefix("api/conta")]
    public class ContaController : BaseApiController
    {
        private readonly IGerenciadorDeContas _gerenciadorDeContas;
        private readonly IAuthenticationManager _authenticationManager;

        public ContaController(IGerenciadorDeContas gerenciadorDeContas, IAuthenticationManager authenticationManager)
        {
            _gerenciadorDeContas = gerenciadorDeContas;
            _authenticationManager = authenticationManager;
        }

        [HttpPost, Route("login")]
        [AllowAnonymous]
        public IHttpActionResult EfetuarLogin(LoginModel dados)
        {
            string login = dados?.Login;
            string senha = dados?.Senha;
            bool lembrar = dados?.Lembrar ?? false;

            if (login.IsNullOrWhiteSpace() || login.IsNullOrWhiteSpace())
                return BadRequest("Informe os dados de acesso.");

            Usuario usuario = _gerenciadorDeContas.Logar(dados.Login, senha);

            if (usuario == null)
                return BadRequest("Login ou senha inválidos.");

            lembrar = true;

            Usuario.Preencher(usuario, DefaultAuthenticationTypes.ApplicationCookie, lembrar);

            ClaimsIdentity identidade = Usuario.GetClaims();
            AuthenticationProperties definicoes = new AuthenticationProperties();

            definicoes.AllowRefresh = true;
            definicoes.IsPersistent = lembrar;

            if (!lembrar)
                definicoes.ExpiresUtc = DateTime.UtcNow.AddMinutes(30);
            
            _authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            _authenticationManager.SignIn(definicoes, identidade);

            return Ok();
        }
    }
}