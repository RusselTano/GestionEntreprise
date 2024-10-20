namespace GestionEntreprise
{
    partial class RechercherForm
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
            this.suivantButton = new System.Windows.Forms.Button();
            this.annulerButton = new System.Windows.Forms.Button();
            this.RechercherLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rechercherTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // suivantButton
            // 
            this.suivantButton.Location = new System.Drawing.Point(426, 21);
            this.suivantButton.Name = "suivantButton";
            this.suivantButton.Size = new System.Drawing.Size(147, 43);
            this.suivantButton.TabIndex = 0;
            this.suivantButton.Text = "&Suivant";
            this.suivantButton.UseVisualStyleBackColor = true;
            // 
            // annulerButton
            // 
            this.annulerButton.Location = new System.Drawing.Point(426, 70);
            this.annulerButton.Name = "annulerButton";
            this.annulerButton.Size = new System.Drawing.Size(147, 43);
            this.annulerButton.TabIndex = 1;
            this.annulerButton.Text = "Annuler";
            this.annulerButton.UseVisualStyleBackColor = true;
            // 
            // RechercherLabel
            // 
            this.RechercherLabel.AutoSize = true;
            this.RechercherLabel.Location = new System.Drawing.Point(17, 35);
            this.RechercherLabel.Name = "RechercherLabel";
            this.RechercherLabel.Size = new System.Drawing.Size(77, 16);
            this.RechercherLabel.TabIndex = 2;
            this.RechercherLabel.Text = "&Rechercher";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rechercherTextBox);
            this.groupBox1.Controls.Add(this.RechercherLabel);
            this.groupBox1.Location = new System.Drawing.Point(13, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(396, 92);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // rechercherTextBox
            // 
            this.rechercherTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rechercherTextBox.Location = new System.Drawing.Point(112, 33);
            this.rechercherTextBox.Multiline = true;
            this.rechercherTextBox.Name = "rechercherTextBox";
            this.rechercherTextBox.Size = new System.Drawing.Size(217, 28);
            this.rechercherTextBox.TabIndex = 0;
            // 
            // RechercherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 141);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.annulerButton);
            this.Controls.Add(this.suivantButton);
            this.Name = "RechercherForm";
            this.Text = "Rechercher";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button suivantButton;
        private System.Windows.Forms.Button annulerButton;
        private System.Windows.Forms.Label RechercherLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox rechercherTextBox;
    }
}