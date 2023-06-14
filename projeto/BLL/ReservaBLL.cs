using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using projeto.DAL;
using projeto.DTO;
using Npgsql;
using System.Reflection;

namespace projeto.BLL
{
    internal class ReservaBLL
    {
        AcessoPostgresql bd = new AcessoPostgresql();
        private DataTable dt;
        NpgsqlDataReader dr;

        public void SelectReservas(DataGridView dgv, string id) // metodo para preencher dgv
        {
            try
            {
                bd.Conectar();
                string comando = "SELECT Laboratorios_idLaboratorio AS Laboratorio, dataReservada AS data_reservada, Horarios_listaHorarios AS horario_reservado," +
                    "Usuarios_idUsuarios AS codigo_usuário, idReserva AS codigo_reserva FROM mydb.Reserva WHERE usuarios_idusuarios = '" + id + "';";
                dt = new DataTable();
                dt.Load(bd.ExecutarComandoSQL(comando).ExecuteReader());
                dgv.DataSource = dt;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar o usuário!!" + ex.Message);
            }
        }

        public void SelectReservasDia(DataGridView dgv, string data, string lab, string horario) // metodo para preencher dgv
        {
            try
            {
                bd.Conectar();
                string comando;

                if (lab == "" && horario == "")
                {
                    comando = "SELECT R.Laboratorios_idLaboratorio AS Laboratorio, R.dataReservada AS data_reservada, R.Horarios_listaHorarios AS horario_reservado, U.nome AS nome_usuário, R.idReserva AS codigo_reserva " +
                    "FROM mydb.Reserva R INNER JOIN mydb.Usuarios U ON R.usuarios_idusuarios = U.idUsuarios WHERE R.dataReservada = '" + data +
                    "' ORDER BY R.idReserva;"; ;
                } else if (lab == "")
                {
                    comando = "SELECT R.Laboratorios_idLaboratorio AS Laboratorio, R.dataReservada AS data_reservada, R.Horarios_listaHorarios AS horario_reservado, U.nome AS nome_usuário, R.idReserva AS codigo_reserva " +
                    "FROM mydb.Reserva R INNER JOIN mydb.Usuarios U ON R.usuarios_idusuarios = U.idUsuarios WHERE R.dataReservada = '" + data + "' AND R.Horarios_listaHorarios = '" + horario +
                    "' ORDER BY R.idReserva;";
                }
                else if (horario == "")
                {
                    comando = "SELECT R.Laboratorios_idLaboratorio AS Laboratorio, R.dataReservada AS data_reservada, R.Horarios_listaHorarios AS horario_reservado, U.nome AS nome_usuário, R.idReserva AS codigo_reserva " +
                    "FROM mydb.Reserva R INNER JOIN mydb.Usuarios U ON R.usuarios_idusuarios = U.idUsuarios WHERE R.dataReservada = '" + data + "' AND R.Laboratorios_idLaboratorio = " + lab +
                    " ORDER BY R.idReserva;";
                } else
                {
                    comando = "SELECT R.Laboratorios_idLaboratorio AS Laboratorio, R.dataReservada AS data_reservada, R.Horarios_listaHorarios AS horario_reservado, U.nome AS nome_usuário, R.idReserva AS codigo_reserva " +
                    "FROM mydb.Reserva R INNER JOIN mydb.Usuarios U ON R.usuarios_idusuarios = U.idUsuarios WHERE R.dataReservada = '" + data + "' AND R.Laboratorios_idLaboratorio = " + lab + " AND R.Horarios_listaHorarios >= '" + horario +
                    "' ORDER BY R.idReserva;";
                }

                dt = new DataTable();
                dt.Load(bd.ExecutarComandoSQL(comando).ExecuteReader());
                dgv.DataSource = dt;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar reservas!!" + ex.Message);
            }
        }
        public void SelectHorarios(ComboBox cbx) // metodo para preencher dgv
        {
            try
            {
                bd.Conectar();
                string comando = "SELECT * FROM mydb.Horarios;";
                dr = bd.retDataReader(comando);
                while (dr.Read())
                {
                    string value1 = dr.GetString(0);
                    cbx.Items.Add(value1);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar o usuário!!" + ex.Message);
            }
        }
        public void SelectLaboratorios(ComboBox cbx) // metodo para preencher dgv
        {
            try
            {
                bd.Conectar();
                string comando = "SELECT idLaboratorio FROM mydb.Laboratorios;";
                dr = bd.retDataReader(comando);
                while (dr.Read())
                {
                    string value1 = (dr.GetInt32(0)).ToString();
                    cbx.Items.Add(value1);
                }


            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar o usuário!!" + ex.Message);
            }
        }

        public void InsertReservas(ReservaDTO dto) // metodo para preencher dgv
        {
            try
            {
                bd.Conectar();
                string comando = "INSERT INTO mydb.Reserva(idReserva, Usuarios_idUsuarios, Laboratorios_idLaboratorio, dataReservada, Horarios_listaHorarios) " +
                    "VALUES (" + dto.IdReserva + "," + dto.IdUsuario + "," + dto.IdLaboratorio + ",'" + dto.DataReservada + "','" + dto.Horario + "');";
                bd.ExecutarComandoSQL(comando);
                MessageBox.Show(null, "Reserva realizada", "Sucesso", MessageBoxButtons.OK);


            }
            catch {
                MessageBox.Show(null, "Erro ao inserir reserva!! possivelmente esse laboratório não está mais disponível nesse horário", "Erro", MessageBoxButtons.OK);
            }
        }

        public void DeleteReserva(string id) // metodo para preencher dgv
        {
            try
            {
                bd.Conectar();
                string comando = "DELETE FROM mydb.Reserva WHERE idReserva = " + id + ";";
                bd.ExecutarComandoSQL(comando);
                MessageBox.Show(null, "Reserva deletada", "Sucesso", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao deletar reserva" + ex.Message);
                //MessageBox.Show(null, "Erro ao inserir chamado!", "Erro", MessageBoxButtons.OK);
            }
        }

    }
}


