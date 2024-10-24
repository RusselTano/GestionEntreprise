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
            this.suivantButton.Location = new System.Drawing.Point(586, 32);
            this.suivantButton.Margin = new System.Windows.Forms.Padding(4);
            this.suivantButton.Name = "suivantButton";
            this.suivantButton.Size = new System.Drawing.Size(202, 64);
            this.suivantButton.TabIndex = 0;
            this.suivantButton.Text = "&Suivant";
            this.suivantButton.UseVisualStyleBackColor = true;
            this.suivantButton.Click += new System.EventHandler(this.suivantButton_Click);
            // 
            // annulerButton
            // 
            this.annulerButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.annulerButton.Location = new System.Drawing.Point(586, 105);
            this.annulerButton.Margin = new System.Windows.Forms.Padding(4);
            this.annulerButton.Name = "annulerButton";
            this.annulerButton.Size = new System.Drawing.Size(202, 64);
            this.annulerButton.TabIndex = 1;
            this.annulerButton.Text = "Annuler";
            this.annulerButton.UseVisualStyleBackColor = true;
            this.annulerButton.Click += new System.EventHandler(this.annulerButton_Click);
            // 
            // RechercherLabel
            // 
            this.RechercherLabel.AutoSize = true;
            this.RechercherLabel.Location = new System.Drawing.Point(23, 52);
            this.RechercherLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.RechercherLabel.Name = "RechercherLabel";
            this.RechercherLabel.Size = new System.Drawing.Size(112, 25);
            this.RechercherLabel.TabIndex = 2;
            this.RechercherLabel.Text = "&Rechercher";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rechercherTextBox);
            this.groupBox1.Controls.Add(this.RechercherLabel);
            this.groupBox1.Location = new System.Drawing.Point(18, 32);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(544, 138);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // rechercherTextBox
            // 
            this.rechercherTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rechercherTextBox.Location = new System.Drawing.Point(154, 50);
            this.rechercherTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.rechercherTextBox.Multiline = true;
            this.rechercherTextBox.Name = "rechercherTextBox";
            this.rechercherTextBox.Size = new System.Drawing.Size(298, 41);
            this.rechercherTextBox.TabIndex = 0;
            // 
            // RechercherForm
            // 
            this.AcceptButton = this.suivantButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.annulerButton;
            this.ClientSize = new System.Drawing.Size(828, 212);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.annulerButton);
            this.Controls.Add(this.suivantButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RechercherForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rechercher";
            this.Load += new System.EventHandler(this.RechercherForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button suivantButton;
        private System.Windows.Forms.Button annulerButton;
        private System.Windows.Forms.Label RechercherLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.TextBox rechercherTextBox;
    }
}