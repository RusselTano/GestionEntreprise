/*
    Programmeur:    Manuela,dylane,andreas,cedric
    Date:           octobre 2024
  
    Solution:       Employes.sln
    Projet:         employes.csproj
    Classe:         employesForm.cs  
  
    But:			recuperer les informations ces employes       
  
    Traitement:	    Implementer le code
   			
    
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using g = GestionEntreprise.GestionEntrepriseClassGenerale;
using ce = GestionEntreprise.GestionEntrepriseClassGenerale.Erreurs;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace GestionEntreprise
{
    public partial class Employes : Form
    {
        #region Variables
        private bool enregistrementBool = false;
        private bool modificationBool = false;
        private bool modeInsertion = false;
        #endregion

        #region initialisation
        public Employes()
        {
            InitializeComponent();
        }

        private void Employes_Load(object sender, EventArgs e)
        {
            g.InitMessagesErreurs();
            infoRichTextBox.Focus();
        }

        #endregion

        #region Propriétés
        public bool ModeInsertion
        {
            get
            {
                return modeInsertion;
            }
            set
            {
                modeInsertion = value;
            }
        }
        public bool Enregistrement
        {
            get
            {
                return enregistrementBool;
            }
            set
            {
                enregistrementBool = value;
            }
        }
        public bool Modification
        {
            get
            {
                return modificationBool;
            }
            set
            {
                modificationBool = value;
            }
        }
        #endregion

        #region Formulaire fermer
        private void Employes_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                DialogResult oDialogResult;

                if (infoRichTextBox.Modified || Modification)
                {
                    oDialogResult = MessageBox.Show("Modification. Enregistrer ?", "Modification", MessageBoxButtons.YesNoCancel);

                    switch (oDialogResult)
                    {
                        case DialogResult.Yes:
                            try
                            {
                                Enregistrer();
                                this.Dispose();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Erreur lors de la fermeture : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                e.Cancel = true;
                            }
                            break;

                        case DialogResult.Cancel:
                            e.Cancel = true;
                            break;

                        case DialogResult.No:
                            this.Dispose();
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(g.tMessagesErreursStr[(int)ce.CEErreurIndeterminee], "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Changement dans TextBox
        private void clientTextBox_TextChanged(object sender, EventArgs e)
        {
            Modification = true;
        }
        #endregion

        #region Enregistrer
        public void Enregistrer()
        {
            try
            {
                if (infoRichTextBox.Modified || Modification)
                {
                    if (!Enregistrement)
                        EnregistrerSous();
                    else
                    {
                        try
                        {
                            // Utiliser une méthode pour Sauvegarder...
                            RichTextBox ortf = new RichTextBox();

                            ortf.Rtf = infoRichTextBox.Rtf;

                            ortf.SelectionStart = 0;
                            ortf.SelectionLength = 0;
                            ortf.SelectedText = infoRichTextBox.Text + Environment.NewLine;

                            ortf.SaveFile(this.Text);

                            // Pas de changement
                            Modification = false;
                            infoRichTextBox.Modified = false;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(g.tMessagesErreursStr[(int)ce.CEErreurSauvegarde], "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show(g.tMessagesErreursStr[(int)ce.CEErreurModification], "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(g.tMessagesErreursStr[(int)ce.CEErreurEnregistrement], "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        #endregion

        #region Enregistrer Sous
        public void EnregistrerSous()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            try
            {
                sfd.Filter = "Fichier RTF (*.rtf)|*.rtf";
                sfd.DefaultExt = ".rtf";
                sfd.AddExtension = true;

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    // Utiliser une méthode pour Sauvegarder...
                    if (System.IO.Path.GetExtension(sfd.FileName).ToLower() != ".rtf")
                    {
                        MessageBox.Show(g.tMessagesErreursStr[(int)ce.CEErreurExtensionFichier], "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    //Ici, juste le contenu du RichTextBox est sauvegardé!
                    string filePath = sfd.FileName;
                    this.Text = filePath;

                    SaveToRichTextBox(filePath);

                    // Enregistré et pas de changement
                    Enregistrement = true;
                    Modification = false;
                    infoRichTextBox.Modified = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(g.tMessagesErreursStr[(int)ce.CEErreurEnregistrementSous], "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region SaveFile
        private void SaveToRichTextBox(string filePath)
        {
            // Créer un RichTextBox temporaire
            RichTextBox tempRichTextBox = new RichTextBox();

            // Charger le RTF existant
            tempRichTextBox.Rtf = infoRichTextBox.Rtf;

            tempRichTextBox.SelectionStart = 0;
            tempRichTextBox.SelectionLength = 0;

            tempRichTextBox.SelectedText = nomTextBox.Text + Environment.NewLine;
            tempRichTextBox.SelectedText = prenomTextBox.Text + Environment.NewLine;
            tempRichTextBox.SelectedText = telephoneMaskedTextBox.Text + Environment.NewLine;

            // Enregistrer dans un fichier si un chemin est fourni
            tempRichTextBox.SaveFile(filePath);

            infoRichTextBox.Modified = false;
        }
        #endregion

        #region SelectionChanged
        private void infoRichTextBox_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Employes client = (Employes)this.ActiveMdiChild;

                GestionEntrepriseForm parent = (GestionEntrepriseForm)this.MdiParent;

                if (parent != null)
                {
                    // Vérifiez si les boutons ne sont pas null
                    if (parent.boldToolStripButton != null && parent.italicToolStripButton != null)
                    {
                        // Activer ou désactiver les boutons Gras, Italique, Souligné
                        parent.boldToolStripButton.Checked = infoRichTextBox.SelectionFont?.Bold ?? false;
                        parent.italicToolStripButton.Checked = infoRichTextBox.SelectionFont?.Italic ?? false;
                        parent.underlineToolStripButton.Checked = infoRichTextBox.SelectionFont?.Underline ?? false;
                    }
                }

                //Police
                if (infoRichTextBox.SelectionFont != null)
                {
                    parent.policesToolStripComboBox.Text = infoRichTextBox.SelectionFont.FontFamily.Name;
                    parent.taillesToolStripComboBox.Text = infoRichTextBox.SelectionFont.Size.ToString();
                }

                // Vérifier le contenu du presse - papiers
                if (Clipboard.ContainsText() || Clipboard.ContainsImage()) parent.collerToolStripMenuItem.Enabled = true;
                else parent.collerToolStripMenuItem.Enabled = false;

                // Activer ou désactiver les boutons Copier et Couper
                parent.couperToolStripMenuItem.Enabled = infoRichTextBox.SelectedText.Length > 0;
                parent.copierToolStripMenuItem.Enabled = infoRichTextBox.SelectedText.Length > 0;
                parent.couperToolStripButton.Enabled = parent.couperToolStripMenuItem.Enabled;
                parent.copierToolStripButton.Enabled = parent.copierToolStripMenuItem.Enabled;

                //Vérifier l'alignement
                switch (infoRichTextBox.SelectionAlignment)
                {
                    case HorizontalAlignment.Left:
                        parent.alignLeftToolStripButton.Checked = true;
                        parent.alignCenterToolStripButton.Checked = false;
                        parent.alignRightToolStripButton.Checked = false;
                        break;
                    case HorizontalAlignment.Center:
                        parent.alignCenterToolStripButton.Checked = true;
                        parent.alignLeftToolStripButton.Checked = false;
                        parent.alignRightToolStripButton.Checked = false;
                        break;
                    case HorizontalAlignment.Right:
                        parent.alignRightToolStripButton.Checked = true;
                        parent.alignCenterToolStripButton.Checked = false;
                        parent.alignLeftToolStripButton.Checked = false;
                        break;
                }
            }
            catch (Exception)
            {
                MessageBox.Show(g.tMessagesErreursStr[(int)ce.CEErreurSelection], "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Activated
        private void Employes_Activated(object sender, EventArgs e)
        {
            infoRichTextBox_SelectionChanged(sender, e);
        }
        #endregion

        #region ChangerAttributs
        public void ChangerAttributsPolice(FontStyle style)
        {
            GestionEntrepriseForm parent = (GestionEntrepriseForm)this.MdiParent;

            try
            {
                Employes client = (Employes)this.ActiveMdiChild;

                if (infoRichTextBox.SelectionFont != null && infoRichTextBox.SelectionFont.FontFamily.IsStyleAvailable(style))
                {
                    Font currentFont = infoRichTextBox.SelectionFont;

                    parent.fontFamily = currentFont.FontFamily.Name;
                    parent.fontSize = currentFont.Size;
                    parent.fontStyle = currentFont.Style ^ style;

                    infoRichTextBox.SelectionFont = new Font(parent.fontFamily, parent.fontSize, parent.fontStyle);
                }
            }
            catch (Exception)
            {
                MessageBox.Show(g.tMessagesErreursStr[(int)ce.CEErreurPolice], "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion


    }
}
