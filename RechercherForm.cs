using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using g = GestionEntreprise.GestionEntrepriseClassGenerale;
using ce = GestionEntreprise.GestionEntrepriseClassGenerale.Erreurs;
namespace GestionEntreprise
{
    public partial class RechercherForm : Form
    {
        #region variable
      public   string mot;
        #endregion

        #region Initialisation
        public RechercherForm()
        {
            InitializeComponent();
            
        }
        #endregion

        #region Propriétés
        public string Mot
        {
            get
            {
                return mot;
            }
            set
            {
                mot = value;
            }
        }
        #endregion

        #region  suivant
        private void suivantButton_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.Owner.ActiveMdiChild != null)
                {
                    Employes oForm = (Employes)this.Owner.ActiveMdiChild;
                    oForm.infoRichTextBox.Focus();

                    // Récupère le mot à rechercher depuis la boîte de dialogue
                    string mot = rechercherTextBox.Text;
                    int positionDepartInteger = oForm.infoRichTextBox.SelectionStart;
                    int resultatRecherche;


                    // Si la longueur de la sélection actuelle est nulle
                    if (oForm.infoRichTextBox.SelectionLength == 0)
                    {
                        // Cherche le mot à partir de la position actuelle
                        resultatRecherche = oForm.infoRichTextBox.Find(mot, positionDepartInteger, RichTextBoxFinds.None);


                    }
                    else
                    {
                        resultatRecherche = oForm.infoRichTextBox.Find(mot, positionDepartInteger + 1, RichTextBoxFinds.None);
                    }

                    // Si le mot n'est pas trouvé, recommence la recherche depuis le début
                    if (resultatRecherche == -1)
                    {
                        resultatRecherche = oForm.infoRichTextBox.Find(mot, 0, RichTextBoxFinds.None);
                    }

                    // Si le mot est trouvé, surligne-le
                    if (resultatRecherche != -1)
                    {
                        oForm.infoRichTextBox.Select(resultatRecherche, mot.Length);
                        oForm.infoRichTextBox.ScrollToCaret();
                    }
                    else
                    {
                        MessageBox.Show(g.tMessagesErreursStr[(int)ce.CEMotIntrouvable]);
                    }
                }


            }
            catch (Exception ex)
            {
                // Gestion des exceptions
                MessageBox.Show(ex.ToString());
                //MessageBox.Show("Erreur lors de la recherche : " + ex.Message);
            }
        }

        #endregion

        #region annuler
        private void annulerButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void RechercherForm_Load(object sender, EventArgs e)
        {
            OuvrirNouvelEnfantMdi();

            mot = this.rechercherTextBox.Text;

        }

        private void OuvrirNouvelEnfantMdi()
        {
           
        }
    }
}
