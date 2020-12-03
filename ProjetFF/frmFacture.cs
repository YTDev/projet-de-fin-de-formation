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
    public partial class frmFacture : Form
    {
        private string id;
        private string n;
        private string p;
        private string ncb;
        public frmFacture(string id,string n,string p,string ncb)
        {
            this.id = id;
            this.n = n;
            this.p = p;
            this.ncb = ncb;
            InitializeComponent();
        }
        
        private void frmFacture_Load(object sender, EventArgs e)
        {
            CrystalReport1 cr = new CrystalReport1();
            cr.SetParameterValue("id",id);
            cr.SetParameterValue("n", n);
            cr.SetParameterValue("p", p);
            cr.SetParameterValue("ncb", ncb);
            cr.SetParameterValue("dt", DateTime.Now);
            crystalReportViewer1.ReportSource = cr;
            crystalReportViewer1.Refresh();
        }
    }
}
