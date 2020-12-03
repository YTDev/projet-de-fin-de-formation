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
    public partial class frmGestionUtilisateur : Form
    {
        public frmGestionUtilisateur()
        {
            InitializeComponent();
        }
        DataSet ds = new DataSet();
        
        private void frmGestionUtilisateur_Load(object sender, EventArgs e)
        {
            
            D.cmd = D.cn.CreateCommand();
            D.cmd.CommandText = "select * from utilisateur where role='user'";
            D.sDA.SelectCommand = D.cmd;
            D.sDA.Fill(ds, "utilisateur");
            dG.DataSource = ds.Tables[0];
            
            dG.Columns[7].Visible = false;
            dG.Columns[0].Visible = false;
            txtP.DataBindings.Add("Text",ds.Tables[0],"prenom");
            txtN.DataBindings.Add("Text", ds.Tables[0], "nom");
            txtPs.DataBindings.Add("Text", ds.Tables[0], "pseudo");
            txtMdp.DataBindings.Add("Text", ds.Tables[0], "password");
            txtNt.DataBindings.Add("Text", ds.Tables[0], "tel");
            txtE.DataBindings.Add("Text", ds.Tables[0], "email");

        }
        private void txtU_TextChanged(object sender, EventArgs e)
        {
            ds.Tables[0].DefaultView.RowFilter = "prenom like '%" + txtU.Text + "%' or nom like '%" + txtU.Text + "%'";
        }

        private void btnA_Click(object sender, EventArgs e)
        {
            dG.Rows[this.BindingContext[ds.Tables[0]].Position].Cells[7].Value = "user";
            this.BindingContext[ds.Tables[0]].EndCurrentEdit();
            dG.Rows[this.BindingContext[ds.Tables[0]].Position].Selected = true;
            //dG.Rows[this.BindingContext[ds.Tables[0]].Position].Selected = false;
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
                SqlCommandBuilder cb = new SqlCommandBuilder(D.sDA);
                D.sDA.Update(ds.Tables[0]);
                MessageBox.Show("Mise à jour effectué avec succée");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnN_Click(object sender, EventArgs e)
        {
            this.BindingContext[ds.Tables[0]].AddNew();
        }
    }
}
