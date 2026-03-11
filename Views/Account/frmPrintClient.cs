using AppSenAgriculture.Models; 
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppSenAgriculture.Views.Account
{
    public partial class frmPrintClient : Form
    {
        public frmPrintClient()
        {
            InitializeComponent();
        }

        private void frmPrintClient_Load(object sender, EventArgs e)
        {
             BdSenAgricultureContext db = new BdSenAgricultureContext();

            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = System.IO.Path.Combine(Application.StartupPath, "Report", "rptListe.rdlc");

            var data = db.clients.ToList(); // récupération des données

            ReportDataSource rds = new ReportDataSource("DataSet1", data);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);

            reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
    }
}
