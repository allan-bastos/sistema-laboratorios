using projeto.view;
using projeto.DTO;
using projeto.BLL;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using projeto.view.Forms;
using System.Runtime.InteropServices;


namespace projeto
{

    

    public partial class formMainMenu : Form
    {

        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;
        public formMainMenu(string nome, string id, string papel)
        {
            InitializeComponent();
            random = new Random();
            btnCloseChildForm.Visible = false;
            this.Text = string.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            
            lblNome.Text = nome;
            lblId.Text = id;
            lblPapel.Text = papel;

            if (papel.ToLower() == "funcionario")
            {
                btnUsuario.Visible = true;
            }
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if(currentButton != (Button)btnSender) 
                { 
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    panelTitleBar.BackColor = color;
                    panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    btnCloseChildForm.Visible = true;
                }
            }
        }

        public void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls) 
            {
                if (previousBtn.GetType()==typeof(Button)) 
                {
                    previousBtn.BackColor = ColorTranslator.FromHtml("#33334c");
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                }
            }
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
                activeForm.Close();
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktopPane.Controls.Add(childForm);
            this.panelDesktopPane.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text;
        }

        private void btnMinhasReservas_Click(object sender, EventArgs e)
        {
            OpenChildForm(new view.Forms.FormMinhasReservas(lblId.Text), sender);
        }

        private void btnNovaReserva_Click(object sender, EventArgs e)
        {
            OpenChildForm(new view.Forms.FormNovaReserva(lblId.Text), sender);
        }

        private void btnChamados_Click(object sender, EventArgs e)
        {
            OpenChildForm(new view.Forms.FormAbrirChamado(lblId.Text), sender);
        }

        private void btnSoluciona_Click(object sender, EventArgs e)
        {
            OpenChildForm(new view.Forms.FormSolucionarChamado(), sender);
        }
        private void btnUsuario_Click(object sender, EventArgs e)
        {
            OpenChildForm(new view.Forms.FormEditarUsuario(), sender);
        }

        private void btnCloseChildForm_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            Reset();
        }

        private void Reset()
        {
            DisableButton();
            lblTitle.Text = "HOME";
            panelTitleBar.BackColor = Color.FromArgb(0, 150, 136);
            panelLogo.BackColor = Color.FromArgb(39, 39, 58);
            currentButton = null;
            btnCloseChildForm.Visible = false;
        }

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
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

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new FormLogin();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }
    }
}
