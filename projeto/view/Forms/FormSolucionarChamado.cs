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

namespace projeto.view.Forms
{
    
    public partial class FormSolucionarChamado : Form
    {
        ChamadoBLL bll = new ChamadoBLL();
        private int rowIndex = -1;
        private string filtro;
        private string idUsuario;
        public FormSolucionarChamado()
        {
            InitializeComponent();
            dgvChamados.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            bll.SelectChamados(dgvChamados);
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

        private void FormSolucionarChamado_Load(object sender, EventArgs e)
        {
            LoadTheme();

        }

        private void dgvChamados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                rowIndex = e.RowIndex;
                txtIdChamado.Text = dgvChamados.Rows[e.RowIndex].Cells["codigo_chamado"].Value.ToString();
                rtxtSoluciona.Text = dgvChamados.Rows[e.RowIndex].Cells["solucao"].Value.ToString();
                filtro = dgvChamados.Rows[e.RowIndex].Cells["solucao"].Value.ToString();
                idUsuario = dgvChamados.Rows[e.RowIndex].Cells["codigo_usuario"].Value.ToString();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            bll.DeleteChamados(txtIdChamado.Text);
            bll.SelectChamados(dgvChamados);
        }

        private void btnSoluciona_Click(object sender, EventArgs e)
        {
            if (txtIdChamado.Text == "")
            {
                MessageBox.Show(null, "Selecione um chamado", "Erro", MessageBoxButtons.OK);
            } else
            {
                if (filtro == "")
                {

                    bll.InsertSolucao(rtxtSoluciona.Text + " ", txtIdChamado.Text, idUsuario);
                }
                else
                {
                    bll.UpdateSolucao(rtxtSoluciona.Text + " ", txtIdChamado.Text);
                }
                bll.SelectChamados(dgvChamados);
            }   
        }
    }
}
