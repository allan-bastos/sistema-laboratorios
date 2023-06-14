using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto.DTO
{
    internal class ReservaDTO
    {
        private string idReserva;
        private string idUsuario;
        private string idLaboratorio;
        private string dataReservada;
        private string horario;

        public string IdReserva { get => idReserva; set => idReserva = value; }
        public string IdUsuario { get => idUsuario; set => idUsuario = value; }
        public string IdLaboratorio { get => idLaboratorio; set => idLaboratorio = value;}
        public string DataReservada { get => dataReservada; set => dataReservada = value; }
        public string Horario { get => horario; set => horario = value; }  
        
    }
}
