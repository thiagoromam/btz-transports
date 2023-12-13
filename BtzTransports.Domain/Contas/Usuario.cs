using General.Context;
using General.Helpers;
using System;

namespace BtzTransports.Contas
{
    public class Usuario : IEntity
    {
        private string _senha;
        private string _key;
        private string _salt;

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha
        {
            get => _senha;
            private set
            {
                string[] partes = null;

                if (value != null) partes = value.Split(';');
                if (partes?.Length != 2) partes = new string[2];

                string key = partes[0];
                string salt = partes[1];
                string senha = null;

                if (key?.Length > 0 && salt?.Length > 0)
                    senha = $"{key};{salt}";

                _key = key;
                _salt = salt;
                _senha = senha;
            }
        }

        internal void DefinirSenha(string senha)
        {
            byte[] encriptada = EncryptionHelper.Encrypt(senha, out var salt);

            _key = Convert.ToBase64String(encriptada);
            _salt = Convert.ToBase64String(salt);
            _senha = $"{_key};{_salt}";
        }
        internal bool VerificarSenha(string senha)
        {
            if (senha == null) return false;
            if (_key == null) return false;

            byte[] key = Convert.FromBase64String(_key);
            byte[] salt = Convert.FromBase64String(_salt);
            byte[] received = EncryptionHelper.Encrypt(senha, salt);

            return received.SlowEquals(key);
        }
    }
}
