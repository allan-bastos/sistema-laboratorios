using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto.DTO
{
    internal class UsuarioDTO
    {
        private string id;
        private string nome;
        private string senha;
        private string papel;

        public string Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Senha { get => senha; set => senha = value; }
        public string Papel { get => papel; set => papel = value; }

    }
}
