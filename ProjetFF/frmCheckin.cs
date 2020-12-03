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
    public partial class frmCheckin : Form
    {
        public frmCheckin()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        DataSet ds = new DataSet();
        SqlDataAdapter daCb = new SqlDataAdapter("select * from chambre where status='disp'", D.cn);
        SqlDataAdapter daR = new SqlDataAdapter("select * from remise", D.cn);
        SqlDataAdapter daClt = new SqlDataAdapter("select * from client", D.cn);
        bool fin = false;
        private void frmCheckin_Load(object sender, EventArgs e)
        {

            lblSNR.Visible = false;
            txtSNR.Visible = false;
            D.cn.Open();
            D.cmd = D.cn.CreateCommand();
            D.cmd.CommandText = "select isnull(max(id)+1,0) from transact";
            int id = (int)D.cmd.ExecuteScalar();
            txtID.Text = id.ToString();
            D.cn.Close();
            daCb.Fill(ds, "chambre");
            cmbNCb.DataSource = ds.Tables["chambre"];
            cmbNCb.ValueMember = "num_ch";
            
            txtTCb.DataBindings.Add("text", ds.Tables["chambre"], "type");
            txtPCb.DataBindings.Add("text", ds.Tables["chambre"], "prix");
            txtCCb.DataBindings.Add("text", ds.Tables["chambre"], "capacite");
            dTPA.Value = DateTime.Now;

            //daR.Fill(ds, "Remise");
            //cmbR.DataSource = ds.Tables["Remise"];
            //cmbR.ValueMember = "type";

            //D.cmd = D.cn.CreateCommand();
            //D.cmd.CommandText = "select type from remise";
            //D.cn.Open();
            //SqlDataReader dr = D.cmd.ExecuteReader();
            //while(dr.Read())
            //{
            //    cmbR.Items.Add(dr[0]);
            //}
            //D.cn.Close();
            daR.Fill(ds, "remise");
            cmbR.DataSource = ds.Tables["remise"];
            cmbR.DisplayMember = "type";
            cmbR.ValueMember = "id_R";
            txtTR.DataBindings.Add("text", ds.Tables["remise"], "taux");


            daClt.Fill(ds, "client");
            cmbID.DataSource = ds.Tables["client"];
            cmbID.ValueMember = "id_clt";

            lblP.DataBindings.Add("text", ds.Tables["client"], "prenom");
            lblN.DataBindings.Add("text", ds.Tables["client"], "nom");



            fin = true;
        }

        private void dTPD_ValueChanged(object sender, EventArgs e)
        {
            txtNJ.Text= (dTPD.Value.Date - dTPA.Value.Date).Days+"";
            txtST.Text = (int.Parse(txtNJ.Text) * double.Parse(txtPCb.Text))+"";
            txtT.Text = (int.Parse(txtNJ.Text) * double.Parse(txtPCb.Text)) + "";
            if(cmbR.Text!="")
            cmbR_SelectedIndexChanged(sender,e);

        }

        private void cmbR_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fin)
            {
                //D.cmd = D.cn.CreateCommand();
                //D.cmd.CommandText = "select taux from remise where type='" + cmbR.Text + "'";
                //D.cn.Open();
                //double tR = (double)D.cmd.ExecuteScalar();
                //txtTR.Text = tR.ToString();
                //D.cn.Close();
                if (txtST.Text != "")
                {
                    double total = double.Parse(txtST.Text) - double.Parse(txtST.Text) * (double.Parse(txtTR.Text)/100);
                    txtT.Text = total.ToString();
                }
               
            }
        }

        private void cmbR_TextChanged(object sender, EventArgs e)
        {
            if (cmbR.Text == "")
            {
                txtTR.Text = "";
                txtT.Text = txtST.Text;
            }
               
        }

        private void cmbNCb_TextChanged(object sender, EventArgs e)
        {
            if (cmbNCb.Text == "")
            {
                txtTCb.Text = "";
                txtPCb.Text = "";
                txtCCb.Text = "";
            }
        }

        private void btnIN_Click(object sender, EventArgs e)
        {
            
            ////MessageBox.Show(dTPA.Value.ToString());
            D.cn.Open();
            D.cmd = D.cn.CreateCommand();
            
            D.cmd.CommandText = "insert into transact values" +
                "('" + cmbID.Text + "','" + cmbNCb.Text + "','" + cmbR.SelectedValue.ToString() + "','"
                + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "','" + dTPD.Value.ToString("yyyy/MM/dd")
                + "','" + txtE.Text + "','" + txtA.Text + "','" + txtPr.Text + "','in')";

            D.cmd.ExecuteNonQuery();
            D.cn.Close();
            MessageBox.Show("Le checkin est éffectué avec succèes");

            //status chambre = ndisp
            D.cn.Open();
            D.cmd = D.cn.CreateCommand();
            D.cmd.CommandText = "update chambre set status='ndisp' where num_ch='" + cmbNCb.Text + "'";
            D.cmd.ExecuteNonQuery();
            D.cn.Close();
            frmFacture f = new frmFacture(txtID.Text,lblP.Text,lblN.Text,cmbNCb.Text);
            f.Show();


        }

        private void txtPr_TextChanged(object sender, EventArgs e)
        {
            if(txtPr.Text!="")
            txtPEA.Text = (double.Parse(txtT.Text) - double.Parse(txtPr.Text)).ToString();
        }

        private void cmbID_TextChanged(object sender, EventArgs e)
        {
            if(cmbID.Text=="")
            {
                lblN.Text = "";
                lblP.Text = "";
            }
        }

        private void btnV_Click(object sender, EventArgs e)
        {
            
            cmbNCb.Text = "";
            cmbR.Text = "";
        }
        
        private void btnS_Click(object sender, EventArgs e)
        {
            if (btnS.Text != "Confirmer")
            {
            lblSNR.Visible = true;
            txtSNR.Visible = true;
            btnS.Text = "Confirmer";
            }
            else
            {
                
                DialogResult r=MessageBox.Show("Êtes-vous sûr de vouloir supprimer ce check-in","Confirmation",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {
                    try
                    {
                    D.cn.Open();
                    SqlTransaction T=D.cn.BeginTransaction();
                        D.cmd = D.cn.CreateCommand();
                        D.cmd.Transaction = T;
                    
                    D.cmd.CommandText = "select num_ch from transact where id='" + txtSNR.Text + "'";
                    int ncb =(int) D.cmd.ExecuteScalar();
                    D.cmd.CommandText = "delete from transact where id='" + txtSNR.Text + "'";
                    D.cmd.ExecuteNonQuery();
                    D.cmd.CommandText="update chambre set status='disp' where num_ch='"+ncb+"'";
                    D.cmd.ExecuteNonQuery();
                    T.Commit();
                    D.cn.Close();
                    MessageBox.Show("Supprimé avec succès!");
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }
                    finally
                    {
                        D.cn.Close();
                    }
                    

                }

                lblSNR.Visible = false;
                txtSNR.Visible = false;
                btnS.Text = "Supprimer un check-in";
            }
          
        }

        private void cmbNCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
