using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using projeto.BLL;
using projeto.DTO;
using projeto.view;

namespace projeto.view.Forms
{
    public partial class FormLogin : Form
    {

        UsuarioBLL bll = new UsuarioBLL();
        UsuarioDTO dto = new UsuarioDTO();
        public FormLogin()
        {
            InitializeComponent();
            this.Text = string.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            dto.Nome = txtNome.Text;
            dto.Senha = txtSenha.Text;

            dto = bll.SelectLogin(dto);

            if(dto.Id != null)
            {
                string nome = dto.Nome;
                string id = dto.Id;
                string papel = dto.Papel;

                
                this.Hide();
                var form2 = new formMainMenu(nome, id, papel);
                form2.Closed += (s, args) => this.Close();
                form2.Show();
                
            }
            else
            {
                MessageBox.Show(null, "Usuário ou senha inválidos!!", "Erro", MessageBoxButtons.OK);
                txtNome.Text = "";
                txtSenha.Text = "";
                txtNome.Focus();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LimpaCampos()
        {
            txtNome.Text = "";
            txtSenha.Text = "";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
