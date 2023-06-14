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

namespace projeto.view.Forms
{
    
    public partial class FormNovaReserva : Form
    {
        ReservaBLL bll = new ReservaBLL();
        ReservaDTO dto = new ReservaDTO();

        string id;
        public FormNovaReserva(string id)
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

        private void FormNovaReserva_Load_1(object sender, EventArgs e)
        {
            LoadTheme();
            cbxHorario.Items.Add("");
            cbxLab.Items.Add("");
            bll.SelectHorarios(cbxHorario);
            bll.SelectLaboratorios(cbxLab);
            txtId.Text = id;
        }

        private void btnReservar_Click(object sender, EventArgs e)
        { 
            if (dtpData.Value.Date <= DateTime.Now)
            {
                MessageBox.Show(null,"Você não pode marcar nessa data", "Erro!", MessageBoxButtons.OK);
            }
            else if (cbxHorario.Text == "" || cbxLab.Text == "")
            {
                MessageBox.Show(null, "Você deve selecionar o horário e o laboratório", "Erro!", MessageBoxButtons.OK);
            }
            else
            {
                // idReserva = lab/dia/mes/horario
                dto.IdReserva = cbxLab.Text + dtpData.Value.Day.ToString() + dtpData.Value.Month.ToString() + cbxHorario.Text.Substring(0, 2) + cbxHorario.Text.Substring(3, 2);
                dto.IdUsuario = txtId.Text;
                dto.IdLaboratorio = cbxLab.Text;
                dto.DataReservada = dtpData.Value.Year.ToString() + "-" + dtpData.Value.Month.ToString() + "-" + dtpData.Value.Day.ToString();
                dto.Horario = cbxHorario.Text;
                bll.InsertReservas(dto);
                bll.SelectReservasDia(dgvReservas,
                dtpData.Value.Year.ToString() + "-" + dtpData.Value.Month.ToString() + "-" + dtpData.Value.Day.ToString(),
                cbxLab.Text,
                cbxHorario.Text);
            }
            

        }

        private void dtpData_ValueChanged(object sender, EventArgs e)
        {
            bll.SelectReservasDia(dgvReservas, 
                dtpData.Value.Year.ToString() + "-" + dtpData.Value.Month.ToString() + "-" + dtpData.Value.Day.ToString(),
                cbxLab.Text,
                cbxHorario.Text);
        }

        private void cbxLab_SelectedIndexChanged(object sender, EventArgs e)
        {
            bll.SelectReservasDia(dgvReservas,
                dtpData.Value.Year.ToString() + "-" + dtpData.Value.Month.ToString() + "-" + dtpData.Value.Day.ToString(),
                cbxLab.Text,
                cbxHorario.Text);
        }

        private void cbxHorario_SelectedIndexChanged(object sender, EventArgs e)
        {
            bll.SelectReservasDia(dgvReservas,
                dtpData.Value.Year.ToString() + "-" + dtpData.Value.Month.ToString() + "-" + dtpData.Value.Day.ToString(),
                cbxLab.Text,
                cbxHorario.Text);
        }
    }
}
