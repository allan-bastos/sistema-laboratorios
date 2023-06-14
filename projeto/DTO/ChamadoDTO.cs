using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto.DTO
{
    internal class ChamadoDTO
    {
        private string idChamado;
        private string titulo;
        private string descricao;
        private string localizacao;
        private string dataChamado;
        private string idUsuario;


        
        public string IdChamado { get => idChamado; set => idChamado = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        public string Localizacao { get => localizacao; set => localizacao = value; }
        public string DataChamado { get => dataChamado; set => dataChamado = value; }
        public string IdUsuario { get => idUsuario; set => idUsuario = value; }
    }
}
