using projeto.DAL;
using projeto.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projeto.BLL
{
    internal class ChamadoBLL
    {
        AcessoPostgresql bd = new AcessoPostgresql();
        private DataTable dt;

        public void SelectChamados(DataGridView dgv) // metodo para preencher dgv
        {
            try
            {
                bd.Conectar();
                string comando = "SELECT C.titulo, C.localizacao, C.descricao, C.dataC as data_chamado, C.usuarios_idusuarios as codigo_usuario, C.idChamados as codigo_chamado, S.descricao as solucao\r\nFROM mydb.Chamados C LEFT JOIN mydb.Soluciona S ON C.idChamados = S.Chamados_idChamados;";
                dt = new DataTable();
                dt.Load(bd.ExecutarComandoSQL(comando).ExecuteReader());
                dgv.DataSource = dt;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar o usuário!!" + ex.Message);
            }
        }
        public void InsertChamados(ChamadoDTO dto) // metodo para preencher dgv
        {
            try
            {
                bd.Conectar();
                string comando = "INSERT INTO mydb.Chamados(titulo, descricao, localizacao, dataC, usuarios_idusuarios) " +
                    "VALUES ('" + dto.Titulo + "','" + dto.Descricao + "','" + dto.Localizacao + "','" + dto.DataChamado + "','" + dto.IdUsuario + "');";
                bd.ExecutarComandoSQL(comando);
                MessageBox.Show(null, "Chamado cadastrado", "Sucesso", MessageBoxButtons.OK);
            }
            catch
            {
                //throw new Exception("Erro ao inserir Chamado" + ex.Message);
                MessageBox.Show(null, "Erro ao inserir chamado!", "Erro", MessageBoxButtons.OK);
            }
        }

        public void DeleteChamados(string id) // metodo para preencher dgv
        {
            try
            {
                bd.Conectar();
                string comando = "DELETE FROM mydb.Chamados WHERE idChamados = " + id + ";";
                bd.ExecutarComandoSQL(comando);
                MessageBox.Show(null, "Chamado deletado", "Sucesso", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir Chamado" + ex.Message);
                //MessageBox.Show(null, "Erro ao inserir chamado!", "Erro", MessageBoxButtons.OK);
            }
        }

        public void InsertSolucao(string desc, string idc, string idu)
        {
            try
            {
                bd.Conectar();
                string comando = "INSERT INTO mydb.Soluciona(Chamados_idChamados, Usuarios_idUsuarios, descricao) " +
                    "VALUES (" + idc + "," + idu + ",'" + desc + "');";
                bd.ExecutarComandoSQL(comando);
                MessageBox.Show(null, "Solucão inserida", "Sucesso", MessageBoxButtons.OK);
            }
            catch
            {
                //throw new Exception("Erro ao inserir Chamado" + ex.Message);
                MessageBox.Show(null, "Erro ao inserir solução!", "Erro", MessageBoxButtons.OK);
            }
        }
        public void UpdateSolucao(string desc, string idc)
        {
            try
            {
                bd.Conectar();
                string comando = "UPDATE mydb.Soluciona SET descricao = '" + desc + "' WHERE Chamados_idChamados = " + idc + ";";
                bd.ExecutarComandoSQL(comando);
                MessageBox.Show(null, "Solucão atualizada", "Sucesso", MessageBoxButtons.OK);
            }
            catch
            {
                //throw new Exception("Erro ao inserir Chamado" + ex.Message);
                MessageBox.Show(null, "Erro ao atualizar solução!", "Erro", MessageBoxButtons.OK);
            }
        }

    }
}
