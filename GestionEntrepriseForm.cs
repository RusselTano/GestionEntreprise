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
using System.Drawing.Text;

namespace GestionEntreprise
{
    public partial class GestionEntrepriseForm : Form
    {
        #region variables
        private int compteurEnfant = 1;
        private OpenFileDialog ofd;
        public float fontSize = 8f;
        public string fontFamily = GestionEntrepriseForm.DefaultFont.Name;
        public FontStyle fontStyle = FontStyle.Regular;
        #endregion

        #region Initialisation
        public GestionEntrepriseForm()
        {
            InitializeComponent();
        }
        private void GestionEntrepriseForm_Load(object sender, EventArgs e)
        {
            //Mode insertion  et refrappe
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
            AssocierImages();
            languageToolStripStatusLabel.Text = CultureInfo.CurrentCulture.NativeName;

            // Peupler les ToolStripComboBox.
            policesToolStripComboBox.SelectedIndexChanged -= policesToolStripComboBox_SelectedIndexChanged;
            AfficherPolicesInstallees();
            policesToolStripComboBox.SelectedIndexChanged += policesToolStripComboBox_SelectedIndexChanged;
        }
        #endregion

        #region Associer image
        private void AssocierImages()
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

        #region Methode partages

        #region Nouveau formulaire enfants
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
                MessageBox.Show(ex.ToString(), "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region  Changer le style
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

        #region MDI Layout
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

        #region Changer la position
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
                else if(sender==rechercherToolStripMenuItem) 
                { Rechercher(); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(g.tMessagesErreursStr[(int)ce.CEErreurEdition], "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Parent MDI
        private void GestionEntrepriseForm_MdiChildActivate(object sender, EventArgs e)
        {

            if (this.ActiveMdiChild == null)
            {
                DesactiverOperationsMenusBarreOutils();
                creerOuOuvrirEmployeeToolStripStatusLabel.Text = "creer ou ouvrir un Employee";

                
                    RechercherForm oRecherche = new RechercherForm();
                    oRecherche.Owner = this;
                    if (oRecherche != null)
                    {
                        oRecherche.Close();
                    }
                
            }
            else
            {
                ActiverOperationsMenusBarreOutils();
                Employes client = (Employes)this.ActiveMdiChild;

                if (client.ModeInsertion) creerOuOuvrirEmployeeToolStripStatusLabel.Text = client.Text;
                else creerOuOuvrirEmployeeToolStripStatusLabel.Text = "creer ou ouvrir un Employee";

                creerOuOuvrirEmployeeToolStripStatusLabel.Text = client.Text;
            }
        }
        #endregion

        #region  Changement du style
        private void StylePolice_Click(object sender, EventArgs e)
        {
            try
            {
                Employes client = (Employes)this.ActiveMdiChild;

                // Appeler Enregistrer ou EnregistrerSous selon le sender (à définir selon votre logique)
                if (sender == boldToolStripButton) client.ChangerAttributsPolice(FontStyle.Bold);
                else if (sender == italicToolStripButton) client.ChangerAttributsPolice(FontStyle.Italic);
                else if (sender == underlineToolStripButton) client.ChangerAttributsPolice(FontStyle.Underline);
            }
            catch (Exception ex)
            {
                MessageBox.Show(g.tMessagesErreursStr[(int)ce.CEErreurStylePolice], "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region  Desactiver
        private void DesactiverOperationsMenusBarreOutils()
        {
            foreach (ToolStripItem oMainToolStripItem in gestionEntrepriseMenuStrip.Items)
            {
                if (oMainToolStripItem is ToolStripMenuItem)
                {
                    ToolStripMenuItem mainItem = (ToolStripMenuItem)oMainToolStripItem;
                    foreach (ToolStripItem oCourantToolStripItem in mainItem.DropDownItems)
                    {
                        if (oCourantToolStripItem is ToolStripMenuItem) oCourantToolStripItem.Enabled = false;
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

<<<<<<< HEAD
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

            if (e.Control && e.KeyCode == Keys.F)
            {
                Rechercher();
            }
        }
        #endregion

=======
>>>>>>> a0606035fc85250dc7a2664869b6130d3c8ed764
        #region Activer
        private void ActiverOperationsMenusBarreOutils()
        {
            foreach (ToolStripItem oMainToolStripItem in gestionEntrepriseMenuStrip.Items)
            {
                if (oMainToolStripItem is ToolStripMenuItem)
                {
                    ToolStripMenuItem mainItem = (ToolStripMenuItem)oMainToolStripItem;
                    foreach (ToolStripItem oCourantToolStripItem in mainItem.DropDownItems)
                    {
                        if (oCourantToolStripItem is ToolStripMenuItem) oCourantToolStripItem.Enabled = true;
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

        #region Typographie
        private void policesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Employes client = (Employes)this.ActiveMdiChild;
                gestionEntrepriseFontDialog.Font = client.infoRichTextBox.SelectionFont;
                gestionEntrepriseFontDialog.MaxSize = 16;
                gestionEntrepriseFontDialog.MinSize = 8;

                if (gestionEntrepriseFontDialog.ShowDialog() == DialogResult.OK)
                    client.infoRichTextBox.SelectionFont = gestionEntrepriseFontDialog.Font;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void policesToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Employes client = (Employes)this.ActiveMdiChild;
                if (client.infoRichTextBox != null)
                {
                    fontFamily = policesToolStripComboBox.SelectedItem.ToString();
                    client.infoRichTextBox.SelectionFont = new Font(fontFamily, fontSize, fontStyle);
                    client.infoRichTextBox.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void taillesToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Employes client = (Employes)this.ActiveMdiChild;

            fontSize = float.Parse(taillesToolStripComboBox.Text);
            client.infoRichTextBox.SelectionFont = new Font(fontFamily, fontSize, fontStyle);
            client.infoRichTextBox.Focus();
        }
        private void AfficherPolicesInstallees()
        {
            try
            {
                InstalledFontCollection oInstalledFonts = new InstalledFontCollection();

                foreach (FontFamily oFontFamily in oInstalledFonts.Families)
                {
                    policesToolStripComboBox.Items.Add(oFontFamily.Name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

<<<<<<< HEAD
        #region Rechercher
       

        #endregion

        public void Rechercher()
        {
            try
            {
                Employes client = (Employes)this.ActiveMdiChild;
                if (this.ActiveMdiChild != null)
                {
                    // Création d'une nouvelle instance de RechercherForm
                    RechercherForm oRecherche = new RechercherForm();
                    oRecherche.Owner = this;

                    // Pré-remplir avec le texte sélectionné dans le RichTextBox
                    RichTextBox oRichTextBox = this.ActiveMdiChild.Controls[7] as RichTextBox;
                    oRecherche.Mot= (this.ActiveMdiChild.Controls[7] as RichTextBox).SelectedText;

                   oRecherche.rechercherTextBox.SelectedText=oRichTextBox.SelectedText;


                    // Afficher la fenêtre de recherche
                    oRecherche.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'ouverture de la fenêtre de recherche : " + ex.Message);
            }
        }

=======
        #region Rechercher police
        private void policesToolStripComboBox_TextChanged(object sender, EventArgs e)
        {
            if (policesToolStripComboBox.Focused)
            {
                policesListBox.Visible = true;
                policesListBox.Items.Clear();
                string text = policesToolStripComboBox.Text.ToLower();

                InstalledFontCollection oInstalledFonts = new InstalledFontCollection();

                foreach (FontFamily oFontFamily in oInstalledFonts.Families)
                {
                    if (oFontFamily.Name.ToLower().StartsWith(text))
                    {
                        policesListBox.Items.Add(oFontFamily.Name);
                    }
                }
            }
        }
        private void policesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedFont = policesListBox.SelectedItem.ToString();
            policesToolStripComboBox.Text = selectedFont;
            policesListBox.Visible = false;
        }
        #endregion
>>>>>>> a0606035fc85250dc7a2664869b6130d3c8ed764
    }
}
