using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using projeto.DTO;
using projeto.BLL;

namespace projeto.view.Forms
{
    public partial class FormAbrirChamado : Form
    {
        string id;
        private ChamadoDTO dto = new ChamadoDTO();
        private ChamadoBLL bll = new ChamadoBLL();
        public FormAbrirChamado(string id)
        {
            InitializeComponent();
            this.id = id;
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
        }

        private void FormAbrirChamado_Load_1(object sender, EventArgs e)
        {
            LoadTheme();
            txtId.Text = id;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtTitulo.Text == "" || txtLocalizacao.Text == "")
            {
                MessageBox.Show(null, "Você deve preencher os campos título e localização", "Erro!", MessageBoxButtons.OK);
            }
            else
            {
                dto.Titulo = txtTitulo.Text;
                dto.Localizacao = txtLocalizacao.Text;
                dto.Descricao = rtxtDesc.Text;
                dto.DataChamado = dtpData.Value.Year.ToString() + "-" + dtpData.Value.Month.ToString() + "-" + dtpData.Value.Day.ToString();
                dto.IdUsuario = txtId.Text;
                bll.InsertChamados(dto);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
