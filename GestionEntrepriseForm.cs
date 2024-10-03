using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionEntreprise
{
    public partial class GestionEntrepriseForm : Form
    {
        #region Initialisation
        public GestionEntrepriseForm()
        {
            InitializeComponent();
        }
        private void associerImages()
        {
            boldToolStripButton.Image = Properties.Resources.b;
            italicToolStripButton.Image = Properties.Resources.I;
            underlineToolStripButton.Image = Properties.Resources.u;
            alignLeftToolStripButton.Image = Properties.Resources.left;
            alignCenterToolStripButton.Image = Properties.Resources.center;
            alignRightToolStripButton.Image = Properties.Resources.right;
        }
        private void GestionEntrepriseForm_Load(object sender, EventArgs e)
        {
            associerImages();
        }
        #endregion
    }
}
