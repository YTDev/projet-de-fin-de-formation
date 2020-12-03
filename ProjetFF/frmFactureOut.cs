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
    public partial class frmFactureOut : Form
    {

        private string id;
        private string n;
        private string p;
        private string ncb;
        string nbJ;
        string st;
        string pr;
        string tr;
        string t;
        string pea;
        string dtpa;
        string dtpd;
        string pcb;
        //(txtID.Text, lblP.Text, lblN.Text,
        //        cmbNCb.Text, txtPCb.Text, txtNJ.Text, txtST.Text, txtPr.Text, txtTR.Text,
        //        txtT.Text, txtPEA.Text, txtST.Text, dTPA.Value.ToShortDateString(), dTPD.Value.ToShortDateString());
        public frmFactureOut(string id, string p, string n,
            string ncb,string pcb,string nbJ,string st,
            string pr,string tr,string t,
            string pea,string dtpa,string dtpd)
        {
            this.pcb = pcb;
            this.id = id;
            this.n = n;
            this.p = p;
            this.ncb = ncb;
            this.nbJ = nbJ;
            this.st = st;
            this.pr = pr;
            this.tr = tr;
            this.t = t;
            this.pea = pea;
            this.dtpa = dtpa;
            this.dtpd = dtpd;
            InitializeComponent();
        }

        private void frmFactureOut_Load(object sender, EventArgs e)
        {
            crOut cro = new crOut();
            cro.SetParameterValue("id", id);
            cro.SetParameterValue("n", n);
            cro.SetParameterValue("p", p);
            cro.SetParameterValue("ncb", ncb);
            cro.SetParameterValue("pcb", pcb);
            cro.SetParameterValue("nbj", nbJ);
            cro.SetParameterValue("st", st);
            cro.SetParameterValue("pr", pr);
            cro.SetParameterValue("tr", tr);
            cro.SetParameterValue("pea", pea);
            cro.SetParameterValue("t", t);
            cro.SetParameterValue("chk", "Check-out");
            cro.SetParameterValue("dtpa", dtpa);
            cro.SetParameterValue("dtpd", dtpd);
            //cro.SetParameterValue("dt", DateTime.Now);
            crystalReportViewer1.ReportSource = cro;
            crystalReportViewer1.Refresh();
        }
    }
}
