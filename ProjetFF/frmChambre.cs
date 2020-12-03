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
    public partial class frmChambre : Form
    {
        public frmChambre()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        DataSet dS = new DataSet();
        private void frmChambre_Load(object sender, EventArgs e)
        {
            D.cmd = D.cn.CreateCommand();
            D.cmd.CommandText = "select * from chambre";
            D.sDA.SelectCommand = D.cmd;
            D.sDA.Fill(dS, "chambre");
            dG.DataSource = dS.Tables[0];
            txtN.DataBindings.Add("Text", dS.Tables[0], "num_ch");
            cmbT.DataBindings.Add("Text", dS.Tables[0], "type");
            txtP.DataBindings.Add("Text", dS.Tables[0], "prix");
            txtC.DataBindings.Add("Text", dS.Tables[0], "capacite");


        }

        private void btnN_Click(object sender, EventArgs e)
        {
            this.BindingContext[dS.Tables[0]].AddNew();
        }

        private void btnA_Click(object sender, EventArgs e)
        {
            this.BindingContext[dS.Tables[0]].EndCurrentEdit();
            dG.Rows[this.BindingContext[dS.Tables[0]].Position].Selected = true;
            MessageBox.Show("L'ajout est effectué avec succés, veuillez cliquer sur enregistrer pour faire les mises à jour!");
        }

        private void btnM_Click(object sender, EventArgs e)
        {
            this.BindingContext[dS.Tables[0]].EndCurrentEdit();
            MessageBox.Show("Modification effectué avec succés, veuillez cliquer sur enregistrer pour faire les mises à jour");
        }

        private void btnS_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Êtes-vous sûr de vouloir supprimer cet utilisateur ?",
                "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (r == DialogResult.Yes)
            {
                this.BindingContext[dS.Tables[0]].RemoveAt(this.BindingContext[dS.Tables[0]].Position);
                MessageBox.Show("Suppression effectuée avec succée,  veuillez cliquer sur enregistrer pour faire les mises à jour");
            }
        }

        private void btnE_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommandBuilder cb = new SqlCommandBuilder(D.sDA);
                D.sDA.Update(dS.Tables[0]);
                MessageBox.Show("Mise à jour effectué avec succée");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i <= 10; i++)
            //{
            //    txtN.Text = i.ToString();
            //    cmbT.SelectedIndex = new Random().Next(0, 11);
            //    txtP.Text = new Random().Next(1000, 6000)+"";
            //    txtC.Text = new Random().Next(1, 5)+"";


            //}
            errorProvider1.Clear();
            errorProvider2.Clear();
            errorProvider3.Clear();
            chkP.Checked = chkS.Checked = chkT.Checked = rdD.Checked = rdND.Checked = false;
            cmbRT.SelectedIndex = -1;
            cmb.SelectedIndex = -1;
            txtPCb.Text = "";
            dS.Tables[0].DefaultView.RowFilter = "";


        }

        private void cmbRT_SelectedIndexChanged(object sender, EventArgs e)
        {
            // dS.Tables[0].DefaultView.RowFilter = "type='"+cmbRT.Text+"'";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string req1 = "";
            string req2 = "";
            string req3 = "";

            if (chkS.Checked)
            {
                if (!rdD.Checked && !rdND.Checked)
                {
                    errorProvider3.SetError(rdD,"Champ vide");
                    return;
                }
                else
                    errorProvider3.Clear();
            }


            if (chkT.Checked)
                req1 = "type='" + cmbRT.Text + "'";
            if (chkP.Checked)
            {
                //if (cmb.Text == "")
                //{
                //    errorProvider1.SetError(cmb, "Champ vide");
                //    return;
                //}
                //else
                //{
                //    errorProvider1.Clear();
                //}
                //if (txtPCb.Text == "")
                //{
                //    errorProvider2.SetError(txtPCb, "Champ vide");
                //    return;
                //}
                //else
                //{
                //    errorProvider2.Clear();
                //}
                if (cmb.Text == "" || txtPCb.Text == "")
                {
                    if (cmb.Text == "")
                        errorProvider1.SetError(cmb, "Champ vide");
                    else
                        errorProvider1.Clear();

                    if (txtPCb.Text == "")
                        errorProvider2.SetError(txtPCb, "Champ vide");
                    else
                        errorProvider2.Clear();

                    return;
                }
                errorProvider1.Clear();
                errorProvider2.Clear();
                req2 = "prix" + cmb.Text + "'" + txtPCb.Text + "'";
            }


            string req = "";

            //if (chkS.Checked)
            //    req = "status=" + (rdD.Checked ? "disp" : "ndisp");
            //else
            //{
            //    if (chkT.Checked && chkP.Checked)
            //    {
            //        req = req1 + " and " + req2;
            //    }

            //    else
            //    {
            //        req = chkT.Checked ? req1 : req2;
            //    }
            //}
            //3 parameter=>6cas
            //1er cas
            //chkS,chkP,chkT    chkS,!chkP,!chkT   chkS,!chkP,chkT   chkS,chkP,!chkT  
            //2eme cas
            //!chkS,chkP,chkT    !chkS,!chkP,!chkT   !chkS,!chkP,chkT   !chkS,chkP,!chkT  
            if (chkS.Checked)
            {
                req = "status='" + (rdD.Checked ? "disp" : "ndisp")+"'";
                if (chkT.Checked && chkP.Checked)
                    req += " and " + req1 + " and " + req2;
                else if (chkT.Checked || chkP.Checked)
                    req +=" and "+ (chkT.Checked ? req1 : req2);
            }
            else
            {
                if (chkT.Checked && chkP.Checked)
                    req =  req1 + " and " + req2;
                else if (chkT.Checked || chkP.Checked)
                    req =  (chkT.Checked ? req1 : req2);
            }





            dS.Tables[0].DefaultView.RowFilter = req;

            //} 
            //dS.Tables[0].DefaultView.RowFilter = "convert(varchar,prix) like '" + txtPCb.Text + "'";
        }
    }
}
