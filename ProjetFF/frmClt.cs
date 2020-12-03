using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace ProjetFF
{
    public partial class frmClt : Form
    {
        public frmClt()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        DataSet ds = new DataSet();
        int i = 0;
        int n;
        bool fin = false;
        int nbPage;
        int cpt = 1;
        SqlDataAdapter daClt = new SqlDataAdapter("select * from client", D.cn);
      
        private void frmClt_Load(object sender, EventArgs e)
        {
            int[] T = { 10, 20, 50, 100 };
            cmbA.DataSource = T;

            D.cmd = D.cn.CreateCommand();
            D.cmd.CommandText = "Select * from client";
            D.sDA.SelectCommand = D.cmd;
            D.sDA.Fill(ds,i,int.Parse(cmbA.Text), "client");
           // daClt.Fill(ds, i, int.Parse(cmbA.Text), "client");
            dG.DataSource = ds.Tables[0];

            textBox5.DataBindings.Add("text", ds.Tables[0], "id_clt");
            txtP.DataBindings.Add("text", ds.Tables[0], "prenom");
            txtN.DataBindings.Add("text", ds.Tables[0], "nom");
            txtA.DataBindings.Add("text", ds.Tables[0], "adresse");
            txtE.DataBindings.Add("text", ds.Tables[0], "email");
            txtNT.DataBindings.Add("text", ds.Tables[0], "tel");
            cmbS.DataBindings.Add("text", ds.Tables[0], "sexe");
            rTB.DataBindings.Add("Text", ds.Tables[0], "remarque");

            D.cn.Open();
            D.cn.CreateCommand();
            D.cmd.CommandText = "select count(*) from client";
            n = (int)D.cmd.ExecuteScalar();
            D.cn.Close();
            nbPage = (int)Math.Ceiling(n / double.Parse(cmbA.Text));
            lblP.Text = cpt + " / " + nbPage.ToString();
            fin = true;

        }

        private void btnN_Click(object sender, EventArgs e)
        {
            this.BindingContext[ds.Tables[0]].AddNew();
        }

        private void btnA_Click(object sender, EventArgs e)
        {
            this.BindingContext[ds.Tables[0]].EndCurrentEdit();
            dG.Rows[this.BindingContext[ds.Tables[0]].Position].Selected = true;
            MessageBox.Show("L'ajout est effectué avec succés, veuillez cliquer sur enregistrer pour faire les mises à jour!");
        }

        private void btnM_Click(object sender, EventArgs e)
        {
            this.BindingContext[ds.Tables[0]].EndCurrentEdit();
            MessageBox.Show("Modification effectué avec succés, veuillez cliquer sur enregistrer pour faire les mises à jour");
        }

        private void btnS_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Êtes-vous sûr de vouloir supprimer cet utilisateur ?",
                "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (r == DialogResult.Yes)
            {
                this.BindingContext[ds.Tables[0]].RemoveAt(this.BindingContext[ds.Tables[0]].Position);
                MessageBox.Show("Suppression effectuée avec succée,  veuillez cliquer sur enregistrer pour faire les mises à jour");
            }
        }

        private void btnE_Click(object sender, EventArgs e)
        {
            try
            {
                //SqlCommandBuilder cb = new SqlCommandBuilder(D.sDA);
                //D.sDA.Update(ds.Tables[0]);
                SqlCommandBuilder cb = new SqlCommandBuilder(daClt);
                daClt.Update(ds.Tables[0]);

                D.cn.Open();
                D.cmd = D.cn.CreateCommand();
                D.cmd.CommandText = "select count(*) from client";
                n = (int)D.cmd.ExecuteScalar();
                nbPage = (int)Math.Ceiling(n / double.Parse(cmbA.Text));
                D.cn.Close();
                cmbA_SelectedIndexChanged(sender, e);
                MessageBox.Show("Mise à jour effectué avec succée");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fin)
            {
                i = 0;
                ds.Clear();
                cpt = 1;
                D.cmd = D.cn.CreateCommand();
                D.cmd.CommandText = "Select * from client";
                D.sDA.SelectCommand = D.cmd;
                D.sDA.Fill(ds, i, int.Parse(cmbA.Text), "client");
                // daClt.Fill(ds, i, int.Parse(cmbA.Text), "client");

                nbPage = (int)Math.Ceiling(n / double.Parse(cmbA.Text));
                lblP.Text = cpt + " / " + nbPage.ToString();
            }
        }

        private void btnSv_Click(object sender, EventArgs e)
        {
            i = i + int.Parse(cmbA.Text);
            if (i >= n)
            {
                i = i - int.Parse(cmbA.Text);
            }
            ds.Clear();
            daClt.Fill(ds, i, int.Parse(cmbA.Text), "client");
            cpt++;
            if (cpt >= nbPage)
            {
                cpt = nbPage;
            }
            lblP.Text = cpt + " / " + nbPage.ToString();
        }

        private void btnPc_Click(object sender, EventArgs e)
        {
            i = i - int.Parse(cmbA.Text);
            if (i <= 0)
            {
                i = 0;
            }
            ds.Clear();
            daClt.Fill(ds, i, int.Parse(cmbA.Text), "client");
            cpt--;
            if (cpt <= 0)
            {
                cpt = 1;
            }
            lblP.Text = cpt + " / " + nbPage.ToString();
        }

        private void txtR_TextChanged(object sender, EventArgs e)
        {
            ds.Tables[0].DefaultView.RowFilter = "prenom like '%" + txtR.Text + "%' or nom like '%" + txtR.Text + "%'";
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            
            
            for (int i = 0; i <= 10; i++)
            {
                
                string n = "nom" + i.ToString();
                string p = "prenom" + i.ToString();
                string a = "adresse" + i.ToString();
                string em = "email" + i.ToString();
                string nt = "+1 541-741" + new Random().Next(1000, 6000);
                string s = new Random().Next(0, 2)==0?"Femme":"Homme";
                string r = "remarque" + i + "";
               
               
                D.cn.Open();
                D.cmd = D.cn.CreateCommand();
                D.cmd.CommandText = "insert into client values('" + p + "','" + n+ "','"
                    + a + "','" + em + "','" + nt + "','" +
                    s + "','" + r + "')";
                D.cmd.ExecuteNonQuery();

                D.cn.Close();


            }

        }
    }
}
