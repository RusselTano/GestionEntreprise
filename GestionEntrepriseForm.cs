/*
    Programmeur:    Andreas,Cedric,Dylane,Manuela
    Date:           octobre 2024
  
    Solution:       GestionEntreprise.sln
    Projet:         GestionEntreprise.csproj
    Classe:         GestionEntrepriseForm.cs  
  
    But:			creer une interface MDI        
  
    Traitement:	    Implementer le code
   			
    Sorties:		imprimer des controles
 */
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using g = GestionEntreprise.GestionEntrepriseClassGenerale;
using ce = GestionEntreprise.GestionEntrepriseClassGenerale.Erreurs;
using System.Globalization;

namespace GestionEntreprise
{
    public partial class GestionEntrepriseForm : Form
    {
        #region variable
        private int compteurEnfant = 1;
        private OpenFileDialog ofd;
        #endregion

        #region initialisation
        public GestionEntrepriseForm()
        {
            InitializeComponent();
        }
        private void GestionEntrepriseForm_Load(object sender, EventArgs e)
        {
            if (Control.IsKeyLocked(Keys.CapsLock)) semiVisibleToolStripStatusLabel.Text = "MAJ";
            else semiVisibleToolStripStatusLabel.Text = "";
            DesactiverOperationsMenusBarreOutils();
            visibleToolStripStatusLabel.Text = "INS";
            g.InitMessagesErreurs();
            //appel de la methode EnlevezCrochet
            g.EnleverCrochetSousMenus(gestionnaireToolStripMenuItem);
            this.gestionEntrepriseMenuStrip.MdiWindowListItem = this.fenetreToolStripMenuItem;
            ofd = new OpenFileDialog();
            ofd.Filter = "Fichier RTF (*.rtf)|*.rtf";
            ofd.DefaultExt = "rtf";
            ofd.AddExtension = true;
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;
            associerImages();
            languageToolStripStatusLabel.Text = CultureInfo.CurrentCulture.NativeName;
        }
        #endregion

        #region associer image

        private void associerImages()
        {
            nouveauToolStripMenuItem.Image = nouveauToolStripButton.Image;
            ouvrirToolStripMenuItem.Image = ouvrirToolStripButton.Image;
            enregistrerSousToolStripMenuItem.Image = enregistrerToolStripButton.Image;
            couperToolStripMenuItem.Image = couperToolStripButton.Image;
            copierToolStripMenuItem.Image = copierToolStripButton.Image;
            collerToolStripMenuItem.Image = collerToolStripButton.Image;
            aideSurListesEmployeesToolStripMenuItem.Image = aideToolStripButton.Image;
        }


        #endregion

        #region methode partages

        #region nouveau formulaire enfants
        private void FichierNouveauDocument_Click(object sender, EventArgs e)
        {
            try
            {
                // Logique pour créer un nouveau document
                ActiverOperationsMenusBarreOutils();
                Employes enfant = new Employes();
                enfant.ModeInsertion = true;
                enfant.MdiParent = this;
                enfant.Text = "Client " + compteurEnfant++;
                enfant.Show();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(g.tMessagesErreursStr[(int)ce.CEErreurIndeterminee], "EXception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(ex.ToString(), "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region  changer le style
        private void StyleToolStripMenuItems_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;

            // Enlever les crochets (coches) des sous-menus
            g.EnleverCrochetSousMenus(barreDoutilsToolStripMenuItem);

            menuItem.Checked = true;

            // Trouver l'index de l'élément sélectionné dans les sous-menus du parent
            int renderModeIndex = barreDoutilsToolStripMenuItem.DropDownItems.IndexOf(menuItem) + 1;

            // Appliquer le RenderMode correspondant
            this.gestionEntrepriseMenuStrip.RenderMode = (ToolStripRenderMode)renderModeIndex;
        }
        #endregion

        #region layout
        private void FenetreMDILayout_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;

            // Enlever les crochets de tous les sous-menus de Fenêtre
            g.EnleverCrochetSousMenus(fenetreToolStripMenuItem);

            // Cocher le choix de l'utilisateur
            menuItem.Checked = true;

            // Changer la disposition des fenêtres en une seule ligne
            this.LayoutMdi((MdiLayout)(fenetreToolStripMenuItem.DropDownItems.IndexOf(menuItem)));
        }
        #endregion

        #region changer la position
        // Méthode partagée pour gérer l'ajout de contrôle dans les panneaux
        private void QuatrePaneaux_ControlAdded(object sender, ControlEventArgs e)
        {
            // Vérifier si le contrôle ajouté provient du menu ou de la barre d'outils
            if (e.Control is MenuStrip menu)
            {
                // Vérifier quel panneau reçoit le menu
                if (sender is ToolStripPanel toolStripPanel)
                {
                    // Modifier les propriétés du menu selon le panneau
                    if (toolStripPanel == this.gestionEntrepriseTopToolStripPanel || toolStripPanel == this.gestionEntrepriseBottomToolStripPanel)
                    {
                        // Modifications pour les panneaux haut et bas
                        menu.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
                        menu.TextDirection = ToolStripTextDirection.Horizontal;
                    }
                    else if (toolStripPanel == this.gestionEntrepriseLeftToolStripPanel || toolStripPanel == this.gestionEntrepriseRigthToolStripPanel)
                    {
                        // Modifications pour les panneaux gauche et droit
                        menu.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
                        menu.TextDirection = ToolStripTextDirection.Vertical90;
                    }
                }
            }
            else if (e.Control is ToolStrip toolStrip)
            {
                // Vérifier quel panneau reçoit la barre d'outils
                if (sender is ToolStripPanel toolStripPanel)
                {
                    if (toolStripPanel == this.gestionEntrepriseTopToolStripPanel || toolStripPanel == this.gestionEntrepriseBottomToolStripPanel)
                    {
                        // Modifications pour les panneaux haut et bas
                        foreach (ToolStripItem item in toolStrip.Items)
                        {
                            if (item is ToolStripComboBox comboBox)
                            {
                                comboBox.Visible = true; // Rendre visible les ComboBox
                            }
                        }
                    }
                    else if (toolStripPanel == this.gestionEntrepriseLeftToolStripPanel || toolStripPanel == this.gestionEntrepriseRigthToolStripPanel)
                    {
                        // Modifications pour les panneaux gauche et droit
                        foreach (ToolStripItem item in toolStrip.Items)
                        {
                            if (item is ToolStripComboBox comboBox)
                            {
                                comboBox.Visible = false; // Rendre invisible les ComboBox
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region Ouvrir client
        private void ouvrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Employes client = (Employes)this.ActiveMdiChild;
            client.ModeInsertion = true;
            try
            {
                // Logique pour ouvrir un document existant
                ActiverOperationsMenusBarreOutils();

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    if (System.IO.Path.GetExtension(ofd.FileName).ToLower() != ".rtf")
                    {
                        MessageBox.Show(g.tMessagesErreursStr[(int)ce.CEErreurExtensionDifferente], "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        Employes oEnfant = new Employes();
                        oEnfant.MdiParent = this;
                        oEnfant.Text = ofd.FileName;

                        oEnfant.infoRichTextBox.LoadFile(ofd.FileName);

                        RichTextBox ortf = new RichTextBox();

                        ortf.LoadFile(ofd.FileName);

                        oEnfant.nomTextBox.Text = ortf.Lines[0];
                        oEnfant.prenomTextBox.Text = ortf.Lines[1];
                        oEnfant.telephoneMaskedTextBox.Text = ortf.Lines[2];

                        ortf.SelectionStart = 0;
                        ortf.SelectionLength = ortf.Lines[0].Length + ortf.Lines[1].Length + ortf.Lines[2].Length + 3; // ne pas oublier changement de ligne
                        ortf.SelectedText = String.Empty;

                        oEnfant.infoRichTextBox.Rtf = ortf.Rtf;

                        oEnfant.Enregistrement = true;
                        oEnfant.infoRichTextBox.Modified = false;
                        oEnfant.Modification = false;

                        oEnfant.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show(g.tMessagesErreursStr[(int)ce.CEErreurOuverture], "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Enregistrer ou Enregistrer sous
        private void enregistrerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ActiveMdiChild != null) // Vérifier si un client est actif
                {
                    Employes client = (Employes)this.ActiveMdiChild;
                    creerOuOuvrirEmployeeToolStripStatusLabel.Text = this.Text;

                    // Appeler Enregistrer ou EnregistrerSous selon le sender (à définir selon votre logique)
                    if (sender == enregistrerSousToolStripMenuItem) client.EnregistrerSous();
                    else client.Enregistrer();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(g.tMessagesErreursStr[(int)ce.CEErreurEnregistrement], "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Fermer l'application
        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Fermer un enfant
        private void fermerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Méthode 1:

            if (this.ActiveMdiChild != null)
                this.ActiveMdiChild.Close();

            // Méthode 2:

            if (this.ActiveControl != null)
            {
                Employes oEnfant = (Employes)this.ActiveControl;
                oEnfant.Close();
            }

            // Méthode 3:

            if (this.MdiChildren.Count() != 0)
            {
                this.ActiveMdiChild.Close();
            }
        }
        #endregion

        #endregion

        #region Edition
        private void Edition_Click(object sender, EventArgs e)
        {
            try
            {
                Employes client = (Employes)this.ActiveMdiChild;

                if (sender == couperToolStripMenuItem || sender == couperToolStripButton)
                {
                    client.infoRichTextBox.Cut();
                }
                else if (sender == copierToolStripMenuItem || sender == copierToolStripButton)
                {
                    client.infoRichTextBox.Copy();
                }
                else if (sender == collerToolStripMenuItem || sender == collerToolStripButton)
                {
                    client.infoRichTextBox.Paste();
                }
                else if (sender == effacerToolStripMenuItem)
                {
                    client.infoRichTextBox.Clear();
                }
                else if (sender == selectionnerToolStripMenuItem)
                {
                    client.infoRichTextBox.SelectAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(g.tMessagesErreursStr[(int)ce.CEErreurEdition], "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region parent MDI
        private void GestionEntrepriseForm_MdiChildActivate(object sender, EventArgs e)
        {

            if (this.ActiveMdiChild == null)
            {
                DesactiverOperationsMenusBarreOutils();
                creerOuOuvrirEmployeeToolStripStatusLabel.Text = "creer ou ouvrir un Employee";
            }
            else
            {
                ActiverOperationsMenusBarreOutils();
                Employes client = (Employes)this.ActiveMdiChild;

                if (client.ModeInsertion)
                {
                    creerOuOuvrirEmployeeToolStripStatusLabel.Text = client.Text;
                }
                else
                {
                    creerOuOuvrirEmployeeToolStripStatusLabel.Text = "creer ou ouvrir un Employee";
                }
                creerOuOuvrirEmployeeToolStripStatusLabel.Text = client.Text;
            }
        }
        #endregion

        #region  changer police
        private void StylePolice_Click(object sender, EventArgs e)
        {
            try
            {
                Employes client = (Employes)this.ActiveMdiChild;

                // Appeler Enregistrer ou EnregistrerSous selon le sender (à définir selon votre logique)
                if (sender == boldToolStripButton)
                {
                    client.ChangerAttributsPolice(FontStyle.Bold);

                }
                else if (sender == italicToolStripButton)
                {
                    client.ChangerAttributsPolice(FontStyle.Italic);
                }
                else if (sender == underlineToolStripButton)
                {
                    client.ChangerAttributsPolice(FontStyle.Underline);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(g.tMessagesErreursStr[(int)ce.CEErreurStylePolice], "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion

        #region  desactiver
        private void DesactiverOperationsMenusBarreOutils()
        {
            foreach (ToolStripItem oMainToolStripItem in gestionEntrepriseMenuStrip.Items)
            {
                if (oMainToolStripItem is ToolStripMenuItem)
                {
                    ToolStripMenuItem mainItem = (ToolStripMenuItem)oMainToolStripItem;
                    foreach (ToolStripItem oCourantToolStripItem in mainItem.DropDownItems)
                    {
                        if (oCourantToolStripItem is ToolStripMenuItem)
                        {
                            oCourantToolStripItem.Enabled = false;
                        }
                    }
                }
            }


            foreach (ToolStripItem boutonToolStripItem in gestionEntrepiseToolStrip.Items)
            {
                boutonToolStripItem.Enabled = false;
            }

            // Activer certains éléments nécessaires
            nouveauToolStripMenuItem.Enabled = true;
            nouveauToolStripButton.Enabled = true;
            ouvrirToolStripMenuItem.Enabled = true;
            ouvrirToolStripButton.Enabled = true;
            quitterToolStripMenuItem.Enabled = true;
            aideSurListesEmployeesToolStripMenuItem.Enabled = true;
            aideToolStripButton.Enabled = true;
        }

        #endregion

        #region KeyDown CapsLock && Insert
        private void GestionEntrepriseForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.IsKeyLocked(Keys.CapsLock)) semiVisibleToolStripStatusLabel.Text = "MAJ";
            else semiVisibleToolStripStatusLabel.Text = "";

            if (e.KeyCode == Keys.Insert)
            {
                if (visibleToolStripStatusLabel.Text == "INS")
                {
                    visibleToolStripStatusLabel.Text = "RFP";
                    Employes client = (Employes)this.ActiveMdiChild;
                    client.ModeInsertion = false;
                }
                else visibleToolStripStatusLabel.Text = "";
            }
        }
        #endregion

        #region activer
        private void ActiverOperationsMenusBarreOutils()
        {
            foreach (ToolStripItem oMainToolStripItem in gestionEntrepriseMenuStrip.Items)
            {
                if (oMainToolStripItem is ToolStripMenuItem)
                {
                    ToolStripMenuItem mainItem = (ToolStripMenuItem)oMainToolStripItem;
                    foreach (ToolStripItem oCourantToolStripItem in mainItem.DropDownItems)
                    {
                        if (oCourantToolStripItem is ToolStripMenuItem)
                        {
                            oCourantToolStripItem.Enabled = true;
                        }
                    }
                }
            }
            foreach (ToolStripItem boutonToolStripItem in gestionEntrepiseToolStrip.Items)
            {
                boutonToolStripItem.Enabled = true;
            }
            // Désactiver certains éléments en fonction du contenu du presse-papiers
            collerToolStripMenuItem.Enabled = Clipboard.ContainsText() || Clipboard.ContainsImage();
            copierToolStripButton.Enabled = false;
            copierToolStripMenuItem.Enabled = false;
            couperToolStripButton.Enabled = false;
            couperToolStripMenuItem.Enabled = false;
        }
        #endregion

        #region Alignement
        private void Alignement_Click(object sender, EventArgs e)
        {
            try
            {
                var activeChild = this.ActiveMdiChild;
                if (activeChild == null) return;

                RichTextBox richTextBox = (RichTextBox)activeChild.Controls["infoRichTextBox"];

                if (sender == alignLeftToolStripButton)
                {
                    richTextBox.SelectionAlignment = HorizontalAlignment.Left;
                    alignCenterToolStripButton.Checked = false;
                    alignRightToolStripButton.Checked = false;
                }
                else if (sender == alignCenterToolStripButton)
                {
                    richTextBox.SelectionAlignment = HorizontalAlignment.Center;
                    alignRightToolStripButton.Checked = false;
                    alignLeftToolStripButton.Checked = false;
                }
                else if (sender == alignRightToolStripButton)
                {
                    richTextBox.SelectionAlignment = HorizontalAlignment.Right;
                    alignCenterToolStripButton.Checked = false;
                    alignLeftToolStripButton.Checked = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(g.tMessagesErreursStr[(int)ce.CEErreurAlignement], "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
