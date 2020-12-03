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
    public partial class frmRemise : Form
    {
        public frmRemise()
        {
            InitializeComponent();
        }
        DataSet ds = new DataSet();
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRemise_Load(object sender, EventArgs e)
        {
            D.cmd = D.cn.CreateCommand();
            D.cmd.CommandText = "select * from remise";
            D.sDA.SelectCommand = D.cmd;
            D.sDA.Fill(ds, "remise");
            dG.DataSource = ds.Tables[0];

            txtT.DataBindings.Add("text", ds.Tables[0], "type");
            txtTX.DataBindings.Add("text", ds.Tables[0], "taux");
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
            DialogResult r = MessageBox.Show("Êtes-vous sûr de vouloir supprimer cet remise ?",
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

        private void txtR_TextChanged(object sender, EventArgs e)
        {
            ds.Tables[0].DefaultView.RowFilter = "type like '%" + txtR.Text + "%'" ;
        }
    }
}
