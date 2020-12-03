using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace ProjetFF
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void btnC_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnM_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        public void msgErreur(string msg)
        {
            lblE.Text = msg;
            lblE.Visible = true;
        }
        public static string s;
        public static string nom;
        private void btnL_Click(object sender, EventArgs e)
        {
            
            //this.Hide();
            //frmMenu f = new frmMenu();
            //f.Show();
            if (txtP.Text != "")
            {
                if (txtM.Text != "")
                {
                    if(rdA.Checked || rdU.Checked)
                    {

                        string s = rdA.Checked ? "Admin" : "User";
                        D.cn.Open();
                        D.cmd = D.cn.CreateCommand();
                        D.cmd.CommandText = "select count(*) from utilisateur where pseudo= '"
                            + txtP.Text + "' and password='" + txtM.Text + "' and role='"+s+"'";
                        int n = int.Parse(D.cmd.ExecuteScalar().ToString());
                        D.cn.Close();
                        if (n > 0)
                        {
                            frmMenu f = new frmMenu(s);
                            f.Show();
                            this.Hide();
                        }

                        else
                        {
                            msgErreur("Les informations de ce "+s+" sont incorrectes!");
                        }

                    }
                    else
                    {
                        msgErreur("Veuillez saisir le type!");
                    }
                }
                else
                {
                    msgErreur("Veuillez saisir le mot de passe!");
                }
            }
            else
            {
                msgErreur("Veuillez saisir votre pseudo!");
            }
        }

        private void frmLogin_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);

        }

        private void pnlH_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);

        }
    }
}
