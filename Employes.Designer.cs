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
            this.nomLabel.Location = new System.Drawing.Point(13, 25);
            this.nomLabel.Name = "nomLabel";
            this.nomLabel.Size = new System.Drawing.Size(39, 16);
            this.nomLabel.TabIndex = 0;
            this.nomLabel.Text = "Nom:";
            // 
            // prenomLabel
            // 
            this.prenomLabel.AutoSize = true;
            this.prenomLabel.Location = new System.Drawing.Point(13, 64);
            this.prenomLabel.Name = "prenomLabel";
            this.prenomLabel.Size = new System.Drawing.Size(57, 16);
            this.prenomLabel.TabIndex = 1;
            this.prenomLabel.Text = "Prénom:";
            // 
            // telephoneLabel
            // 
            this.telephoneLabel.AutoSize = true;
            this.telephoneLabel.Location = new System.Drawing.Point(12, 109);
            this.telephoneLabel.Name = "telephoneLabel";
            this.telephoneLabel.Size = new System.Drawing.Size(76, 16);
            this.telephoneLabel.TabIndex = 2;
            this.telephoneLabel.Text = "Téléphone:";
            // 
            // nomTextBox
            // 
            this.nomTextBox.Location = new System.Drawing.Point(128, 25);
            this.nomTextBox.Name = "nomTextBox";
            this.nomTextBox.Size = new System.Drawing.Size(310, 22);
            this.nomTextBox.TabIndex = 3;
            this.nomTextBox.TextChanged += new System.EventHandler(this.clientTextBox_TextChanged);
            // 
            // prenomTextBox
            // 
            this.prenomTextBox.Location = new System.Drawing.Point(128, 64);
            this.prenomTextBox.Name = "prenomTextBox";
            this.prenomTextBox.Size = new System.Drawing.Size(310, 22);
            this.prenomTextBox.TabIndex = 4;
            this.prenomTextBox.TextChanged += new System.EventHandler(this.clientTextBox_TextChanged);
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Location = new System.Drawing.Point(21, 142);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(31, 16);
            this.infoLabel.TabIndex = 5;
            this.infoLabel.Text = "Info:";
            // 
            // infoRichTextBox
            // 
            this.infoRichTextBox.Location = new System.Drawing.Point(149, 142);
            this.infoRichTextBox.Name = "infoRichTextBox";
            this.infoRichTextBox.Size = new System.Drawing.Size(267, 143);
            this.infoRichTextBox.TabIndex = 1;
            this.infoRichTextBox.Text = "";
            this.infoRichTextBox.SelectionChanged += new System.EventHandler(this.infoRichTextBox_SelectionChanged);
            // 
            // telephoneMaskedTextBox
            // 
            this.telephoneMaskedTextBox.Location = new System.Drawing.Point(128, 110);
            this.telephoneMaskedTextBox.Mask = "(999) 000-0000";
            this.telephoneMaskedTextBox.Name = "telephoneMaskedTextBox";
            this.telephoneMaskedTextBox.Size = new System.Drawing.Size(310, 22);
            this.telephoneMaskedTextBox.TabIndex = 8;
            // 
            // Employes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 309);
            this.Controls.Add(this.telephoneMaskedTextBox);
            this.Controls.Add(this.infoRichTextBox);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.prenomTextBox);
            this.Controls.Add(this.nomTextBox);
            this.Controls.Add(this.telephoneLabel);
            this.Controls.Add(this.prenomLabel);
            this.Controls.Add(this.nomLabel);
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