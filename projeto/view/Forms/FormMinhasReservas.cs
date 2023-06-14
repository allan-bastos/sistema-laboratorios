using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using projeto.BLL;

namespace projeto.view.Forms
{
    public partial class FormMinhasReservas : Form
    {
        private int rowIndex = -1;
        ReservaBLL bll = new ReservaBLL();
        string idUsuario;
        public FormMinhasReservas(string id)
        {
            idUsuario = id;
            InitializeComponent();
        }

        private void FormMinhasReservas_Load(object sender, EventArgs e)
        {
            LoadTheme();
            bll.SelectReservas(dgvReservas, idUsuario);
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

        private void dgvReservas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                rowIndex = e.RowIndex;
                txtIdReserva.Text = dgvReservas.Rows[e.RowIndex].Cells["codigo_reserva"].Value.ToString();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            bll.DeleteReserva(txtIdReserva.Text);
            bll.SelectReservas(dgvReservas, idUsuario);
        }
    }
}
