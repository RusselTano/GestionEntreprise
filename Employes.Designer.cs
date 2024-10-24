namespace GestionEntreprise
{
    partial class Employes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.nomLabel = new System.Windows.Forms.Label();
            this.prenomLabel = new System.Windows.Forms.Label();
            this.telephoneLabel = new System.Windows.Forms.Label();
            this.nomTextBox = new System.Windows.Forms.TextBox();
            this.prenomTextBox = new System.Windows.Forms.TextBox();
            this.infoLabel = new System.Windows.Forms.Label();
            this.infoRichTextBox = new System.Windows.Forms.RichTextBox();
            this.telephoneMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // nomLabel
            // 
            this.nomLabel.AutoSize = true;
            this.nomLabel.Location = new System.Drawing.Point(18, 38);
            this.nomLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nomLabel.Name = "nomLabel";
            this.nomLabel.Size = new System.Drawing.Size(59, 25);
            this.nomLabel.TabIndex = 2;
            this.nomLabel.Text = "Nom:";
            // 
            // prenomLabel
            // 
            this.prenomLabel.AutoSize = true;
            this.prenomLabel.Location = new System.Drawing.Point(18, 96);
            this.prenomLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.prenomLabel.Name = "prenomLabel";
            this.prenomLabel.Size = new System.Drawing.Size(86, 25);
            this.prenomLabel.TabIndex = 1;
            this.prenomLabel.Text = "Prénom:";
            // 
            // telephoneLabel
            // 
            this.telephoneLabel.AutoSize = true;
            this.telephoneLabel.Location = new System.Drawing.Point(16, 164);
            this.telephoneLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.telephoneLabel.Name = "telephoneLabel";
            this.telephoneLabel.Size = new System.Drawing.Size(112, 25);
            this.telephoneLabel.TabIndex = 2;
            this.telephoneLabel.Text = "Téléphone:";
            // 
            // nomTextBox
            // 
            this.nomTextBox.Location = new System.Drawing.Point(176, 38);
            this.nomTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nomTextBox.Name = "nomTextBox";
            this.nomTextBox.Size = new System.Drawing.Size(425, 29);
            this.nomTextBox.TabIndex = 3;
            this.nomTextBox.TextChanged += new System.EventHandler(this.clientTextBox_TextChanged);
            // 
            // prenomTextBox
            // 
            this.prenomTextBox.Location = new System.Drawing.Point(176, 96);
            this.prenomTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.prenomTextBox.Name = "prenomTextBox";
            this.prenomTextBox.Size = new System.Drawing.Size(425, 29);
            this.prenomTextBox.TabIndex = 4;
            this.prenomTextBox.TextChanged += new System.EventHandler(this.clientTextBox_TextChanged);
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Location = new System.Drawing.Point(29, 213);
            this.infoLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(50, 25);
            this.infoLabel.TabIndex = 5;
            this.infoLabel.Text = "Info:";
            // 
            // infoRichTextBox
            // 
            this.infoRichTextBox.HideSelection = false;
            this.infoRichTextBox.Location = new System.Drawing.Point(205, 213);
            this.infoRichTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.infoRichTextBox.Name = "infoRichTextBox";
            this.infoRichTextBox.Size = new System.Drawing.Size(366, 212);
            this.infoRichTextBox.TabIndex = 7;
            this.infoRichTextBox.Text = "";
            this.infoRichTextBox.SelectionChanged += new System.EventHandler(this.infoRichTextBox_SelectionChanged);
            // 
            // telephoneMaskedTextBox
            // 
            this.telephoneMaskedTextBox.Location = new System.Drawing.Point(176, 165);
            this.telephoneMaskedTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.telephoneMaskedTextBox.Mask = "(999) 000-0000";
            this.telephoneMaskedTextBox.Name = "telephoneMaskedTextBox";
            this.telephoneMaskedTextBox.Size = new System.Drawing.Size(425, 29);
            this.telephoneMaskedTextBox.TabIndex = 6;
            // 
            // Employes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 464);
            this.Controls.Add(this.telephoneMaskedTextBox);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.prenomTextBox);
            this.Controls.Add(this.nomTextBox);
            this.Controls.Add(this.telephoneLabel);
            this.Controls.Add(this.prenomLabel);
            this.Controls.Add(this.nomLabel);
            this.Controls.Add(this.infoRichTextBox);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Employes";
            this.Text = "Employes";
            this.Activated += new System.EventHandler(this.Employes_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Employes_FormClosing);
            this.Load += new System.EventHandler(this.Employes_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nomLabel;
        private System.Windows.Forms.Label prenomLabel;
        private System.Windows.Forms.Label telephoneLabel;
        private System.Windows.Forms.Label infoLabel;
        public System.Windows.Forms.TextBox nomTextBox;
        public System.Windows.Forms.TextBox prenomTextBox;
        public System.Windows.Forms.MaskedTextBox telephoneMaskedTextBox;
        internal System.Windows.Forms.RichTextBox infoRichTextBox;
    }
}