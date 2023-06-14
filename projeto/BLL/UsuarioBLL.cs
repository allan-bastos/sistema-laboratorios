using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using projeto.DAL;
using projeto.DTO;
using Npgsql;
using System.Data;

namespace projeto.BLL
{
    internal class UsuarioBLL
    {
        AcessoPostgresql bd = new AcessoPostgresql();
        private DataTable dt;
        NpgsqlDataReader dr;

        public UsuarioDTO SelectLogin(UsuarioDTO dto) // metodo para verificar o login
        {
            try
            {
                bd.Conectar();
                string comando = "SELECT * FROM mydb.Usuarios WHERE nome = '" + dto.Nome.ToLower() + "' AND senha = '" + dto.Senha + "';";
                NpgsqlDataReader reader = bd.ExecutarComandoSQL(comando).ExecuteReader();
                if (reader.Read())
                {
                    dto.Id = (reader.GetInt32(0)).ToString();
                    dto.Nome = reader.GetString(1);
                    dto.Senha = reader.GetString(2);
                    dto.Papel = reader.GetString(3);
                    return dto;
                } else
                {
                    return dto;
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar o usuário!!" + ex.Message);
            }
        }

        public void SelectUsuario(DataGridView dgv)
        {
            {
                try
                {
                    bd.Conectar();
                    string comando = "SELECT nome, senha, papel_nomepapel as papel, idUsuarios as codigo_usuario FROM mydb.Usuarios;";
                    dt = new DataTable();
                    dt.Load(bd.ExecutarComandoSQL(comando).ExecuteReader());
                    dgv.DataSource = dt;

                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao buscar usuários!!" + ex.Message);
                }
            }
        }

        public void InsertUsuario(UsuarioDTO dto)
        {
            try
            {
                bd.Conectar();
                string comando = "INSERT INTO mydb.Usuarios(nome, senha, Papel_nomePapel) VALUES('"+dto.Nome+"', '"+dto.Senha+"', '"+dto.Papel+"');";
                bd.ExecutarComandoSQL(comando);
                MessageBox.Show(null, "Usuário inserido", "Sucesso", MessageBoxButtons.OK);
            }
            catch(Exception ex)
            {
                throw new Exception("Erro ao inserir Chamado" + ex.Message);
                //MessageBox.Show(null, "Erro ao inserir usuário!", "Erro", MessageBoxButtons.OK);
            }
        }
        public void UpdateUsuario(UsuarioDTO dto)
        {
            try
            {
                bd.Conectar();
                string comando = "UPDATE mydb.Usuarios SET nome = '" + dto.Nome + "', senha = '" + dto.Senha + "', Papel_nomePapel = '" + dto.Papel + "' WHERE idUsuarios = "+dto.Id+";";
                bd.ExecutarComandoSQL(comando);
                MessageBox.Show(null, "Usuário atualizado", "Sucesso", MessageBoxButtons.OK);
            }
            catch(Exception ex)
            {
                throw new Exception("Erro ao inserir Chamado" + ex.Message);
                //MessageBox.Show(null, "Erro ao atualizar usuário!", "Erro", MessageBoxButtons.OK);
            }
        }

        public void SelectPapel(ComboBox cbx) // metodo para preencher dgv
        {
            try
            {
                bd.Conectar();
                string comando = "SELECT * FROM mydb.Papel;";
                dr = bd.retDataReader(comando);
                while (dr.Read())
                {
                    string value1 = dr.GetString(0);
                    cbx.Items.Add(value1);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar papéis!!" + ex.Message);
            }
        }

        public void DeleteUsuario(string id) // metodo para preencher dgv
        {
            try
            {
                bd.Conectar();
                string comando = "DELETE FROM mydb.Usuarios WHERE idUsuarios = " + id + ";";
                bd.ExecutarComandoSQL(comando);
                MessageBox.Show(null, "Usuário deletado", "Sucesso", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao deletar reserva" + ex.Message);
                //MessageBox.Show(null, "Erro ao inserir chamado!", "Erro", MessageBoxButtons.OK);
            }
        }

    }
}
