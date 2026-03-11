using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppSenAgriculture.Helper;

namespace AppSenAgriculture.Views.Parametre
{
    public partial class frmLieu : Form
    {
        public frmLieu()
        {
            InitializeComponent();
            AppliquerTheme();
        }

        /// <summary>
        /// Applique le thème moderne au formulaire
        /// </summary>
        private void AppliquerTheme()
        {
            ThemeManager.ApplyFormTheme(this);
        }
    }
}
