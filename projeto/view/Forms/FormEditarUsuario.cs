using projeto.BLL;
using projeto.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projeto.view.Forms
{
    public partial class FormEditarUsuario : Form
    {
        private int rowIndex = -1;
        UsuarioBLL bll = new UsuarioBLL();
        UsuarioDTO dto = new UsuarioDTO();
        public FormEditarUsuario()
        {
            InitializeComponent();
        }

        private void FormEditarUsuario_Load(object sender, EventArgs e)
        {
            LoadTheme();
            bll.SelectUsuario(dgvUsuario);
            cbxPapel.Items.Add("");
            bll.SelectPapel(cbxPapel);
        }

        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
            label4.ForeColor = ThemeColor.SecondaryColor;
        }

        private void dgvUsuario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                rowIndex = e.RowIndex;
                dto.Id = dgvUsuario.Rows[e.RowIndex].Cells["codigo_usuario"].Value.ToString();
                txtNome.Text = dgvUsuario.Rows[e.RowIndex].Cells["nome"].Value.ToString();
                txtSenha.Text = dgvUsuario.Rows[e.RowIndex].Cells["senha"].Value.ToString();
                cbxPapel.Text = dgvUsuario.Rows[e.RowIndex].Cells["papel"].Value.ToString();
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            
            if (txtNome.Text == "" || txtSenha.Text == "" || cbxPapel.Text == "")
            {
                MessageBox.Show(null, "Preencha todas as informações do usuário", "Erro!", MessageBoxButtons.OK);
            } else
            {
                dto.Nome = txtNome.Text;
                dto.Senha = txtSenha.Text;
                dto.Papel = cbxPapel.Text;
                if (rowIndex < 0)
                {
                    bll.InsertUsuario(dto);
                }
                else
                {
                    bll.UpdateUsuario(dto);
                }
                txtNome.Text = txtSenha.Text = cbxPapel.Text = "";
                rowIndex = -1;
                bll.SelectUsuario(dgvUsuario);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtNome.Text = txtSenha.Text = cbxPapel.Text = "";
            rowIndex = -1;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (rowIndex < 0)
            {
                MessageBox.Show(null, "Nenhum usuário selecionado", "Erro!", MessageBoxButtons.OK);
            }
            else
            {
                bll.DeleteUsuario(dto.Id);
                bll.SelectUsuario(dgvUsuario);
                txtNome.Text = txtSenha.Text = cbxPapel.Text = "";
                rowIndex = -1;
            }
        }
    }
}
