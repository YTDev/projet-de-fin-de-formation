using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetFF
{
    public partial class frmMenu : Form
    {
        private string role;
        public frmMenu(string r)
        {
            this.role = r;
            InitializeComponent();
        }

       

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin f = new frmLogin();
            f.Show();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {

            if (role == "Admin")
                btnU.Enabled = true;
            else
                btnU.Enabled = false;
            

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnRestore.Visible = false;
            btnMaximize.Visible = true;
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnRestore.Visible = true;
            btnMaximize.Visible = false;
        }
        public void f(object Frm)
        {
            if (this.panelContainer.Controls.Count > 0)
                this.panelContainer.Controls.RemoveAt(0);
            Form fh = Frm as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelContainer.Controls.Add(fh);
            this.panelContainer.Tag = fh;
            fh.Show();
        }
    

        

       
     

      
  

        

        private void btnSlide_Click(object sender, EventArgs e)
        {
            if (pnlMenu.Width == 250)
            {
                pnlMenu.Width = 70;
            }
            else
            {
                pnlMenu.Width = 250;
            }
        }

        private void btnCr_Click(object sender, EventArgs e)
        {
            f(new frmChambre());
        }

        private void btnR_Click(object sender, EventArgs e)
        {
            f(new frmRemise());
        }

        private void btnCI_Click_1(object sender, EventArgs e)
        {
            f(new frmCheckin());
        }

        private void btnCO_Click(object sender, EventArgs e)
        {
            f(new frmCheckout());
        }

        public void btnClt_Click(object sender, EventArgs e)
        {
            f(new frmClt());
        }

        private void btnU_Click(object sender, EventArgs e)
        {
            f(new frmGestionUtilisateur());
        }
    }
}
