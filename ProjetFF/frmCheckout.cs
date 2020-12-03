using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
namespace ProjetFF
{
    public partial class frmCheckout : Form
    {
        public frmCheckout()
        {
            InitializeComponent();
        }
        SqlDataAdapter daCb = new SqlDataAdapter("select * from chambre where num_ch in (select num_ch from transact where status='in')", D.cn);
        DataSet ds = new DataSet();
        bool fin = false;
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCheckout_Load(object sender, EventArgs e)
        {
            
            daCb.Fill(ds, "chambre");
            cmbNCb.DataSource = ds.Tables["chambre"];
            cmbNCb.ValueMember = "num_ch"; 
            //txtTCb.DataBindings.Add("text", ds.Tables["chambre"], "type");
            //txtPCb.DataBindings.Add("text", ds.Tables["chambre"], "prix");
            //txtCCb.DataBindings.Add("text", ds.Tables["chambre"], "capacite");
            fin = true;
            cmbNCb_SelectedIndexChanged(sender, e);
            /*
            txtID.DataBindings.Add("text", ds.Tables[0], "id");
            txtClt.DataBindings.Add("text", ds.Tables[0], "id_clt");
            cmbIDR.DataBindings.Add("text", ds.Tables[0], "id_R");
            dTPA.DataBindings.Add("text", ds.Tables[0], "checkin_date");
            dTPD.DataBindings.Add("text", ds.Tables[0], "checkout");
            txtE.DataBindings.Add("text", ds.Tables[0], "nbE");
            txtA.DataBindings.Add("text", ds.Tables[0], "nbA");
            txtPr.DataBindings.Add("text", ds.Tables[0], "prepaiment");*/

        }

        private void btnOUT_Click(object sender, EventArgs e)
        {
            D.cn.Open();
            D.cmd = D.cn.CreateCommand();
            D.cmd.CommandText = "update transact set status='out' where id='" + txtID.Text + "'";
            D.cmd.ExecuteNonQuery();
            D.cn.Close();
            MessageBox.Show("Le check-out est effectue avec succè");
            frmFactureOut f = new frmFactureOut(txtID.Text,lblP.Text,lblN.Text,
                cmbNCb.Text,txtPCb.Text,txtNJ.Text,
                txtST.Text,txtPr.Text,txtTR.Text,
                txtT.Text,txtPEA.Text,dTPA.Value.ToShortDateString(),
                dTPD.Value.ToShortDateString());
            f.Show();
            ds.Tables["chambre"].Clear();
            frmCheckout_Load(sender,e);


        }
        DataTable dt = new DataTable();
        public void infoR(string r,Control cmb,Control txt)
        {
            //if(D.cn.State!=ConnectionState.Open)
            //D.cn.Open();
            //D.cmd = D.cn.CreateCommand();
            //D.cmd.CommandText = "select * from remise where id_R='" + r + "'";

            //SqlDataReader dr= D.cmd.ExecuteReader();
            //while (dr.Read())
            //{
            //    cmb.Text = dr[1].ToString();
            //    txt.Text = dr[2].ToString();
            //}
            //dr.Close();
            //D.cn.Close();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from remise where id_R='" + r + "'",D.cn);
            da.Fill(dt);
            cmb.Text = dt.Rows[0][1].ToString();
            txt.Text = dt.Rows[0][2].ToString();

        }

        public void infoClt(string id, Control cmb,Control lblP,Control lblN)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from client where id_clt='" + id + "'", D.cn);
            da.Fill(dt);
            txtClt.Text = id;
            lblP.Text = dt.Rows[0][1].ToString();
            lblN.Text = dt.Rows[0][2].ToString();

        }
        
        private void cmbNCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(fin)
            {
                txtTCb.Text = ds.Tables["chambre"].Rows[cmbNCb.SelectedIndex][1].ToString();
                txtPCb.Text = ds.Tables["chambre"].Rows[cmbNCb.SelectedIndex][2].ToString();
                txtCCb.Text = ds.Tables["chambre"].Rows[cmbNCb.SelectedIndex][3].ToString();
                D.cmd = D.cn.CreateCommand();
                D.cmd.CommandText = "select id,id_clt,checkin_date,checkout, nbE,nbA,prepaiment,id_R from transact " +
                    "where num_ch='" + cmbNCb.Text + "'";
                D.cn.Open();
                D.dr = D.cmd.ExecuteReader();
                while (D.dr.Read())
                {
                    txtID.Text = D.dr[0].ToString();
                    //txtClt.Text = D.dr[1].ToString();
                    infoClt(D.dr[1].ToString(), txtClt, lblP, lblN);
                    dTPA.Text = D.dr[2].ToString();
                    dTPD.Text = D.dr[3].ToString();
                    txtE.Text = D.dr[4].ToString();
                    txtA.Text = D.dr[5].ToString();
                    txtPr.Text = D.dr[6].ToString();
                    infoR(D.dr[7].ToString(), cmbR, txtTR);
                }
                D.dr.Close();
                D.cn.Close();

                txtCash.Text = "";
                dTPD_ValueChanged(sender,e);
                cmbR_SelectedIndexChanged(sender, e);
                txtPr_TextChanged(sender, e);
            }
        }

        private void dTPD_ValueChanged(object sender, EventArgs e)
        {
            txtNJ.Text = (dTPD.Value.Date - dTPA.Value.Date).Days + "";
            txtST.Text = (int.Parse(txtNJ.Text) * double.Parse(txtPCb.Text)) + "";
            txtT.Text = (int.Parse(txtNJ.Text) * double.Parse(txtPCb.Text)) + "";
            if (cmbR.Text != "")
                cmbR_SelectedIndexChanged(sender, e);
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
                    double total = double.Parse(txtST.Text) - double.Parse(txtST.Text) * (double.Parse(txtTR.Text) / 100);
                    txtT.Text = total.ToString();
                }

            }
        }

  
        
        private void txtPr_TextChanged(object sender, EventArgs e)
        {
            if (txtPr.Text != "")
                txtPEA.Text = (double.Parse(txtT.Text) - double.Parse(txtPr.Text)).ToString();
        }

        private void txtCash_TextChanged(object sender, EventArgs e)
        {
            if (txtCash.Text != "")
            {
                txtChange.Text = (double.Parse(txtCash.Text) - double.Parse(txtPEA.Text)).ToString();
            }
            else
            {
                txtChange.Text = "";
            }
        }
    }
}
