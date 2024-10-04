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
            nouveauToolStripMenuItem.Image = nouveauToolStripButton.Image;
            ouvrirToolStripMenuItem.Image = ouvrirToolStripButton.Image;
            enregistrerSousToolStripMenuItem.Image = enregistrerToolStripButton.Image;
            couperToolStripMenuItem.Image= couperToolStripButton.Image;
            copierToolStripMenuItem.Image = copierToolStripButton.Image;
            collerToolStripMenuItem.Image = collerToolStripButton.Image;
            aideSurListesEmployeesToolStripMenuItem.Image = aideToolStripButton.Image;
        }
        private void GestionEntrepriseForm_Load(object sender, EventArgs e)
        {
            associerImages();
        }
        #endregion
    }
}
