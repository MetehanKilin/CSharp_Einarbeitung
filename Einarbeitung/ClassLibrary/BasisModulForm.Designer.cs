namespace ClassLibrary
{
    partial class BasisModulForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.speichern = new System.Windows.Forms.Button();
            this.verwerfen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // speichern
            // 
            this.speichern.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.speichern.Enabled = false;
            this.speichern.Location = new System.Drawing.Point(31, 212);
            this.speichern.Name = "speichern";
            this.speichern.Size = new System.Drawing.Size(75, 23);
            this.speichern.TabIndex = 1;
            this.speichern.Text = "speichern";
            this.speichern.UseVisualStyleBackColor = true;
            this.speichern.Click += new System.EventHandler(this.speichern_Click);
            // 
            // verwerfen
            // 
            this.verwerfen.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.verwerfen.Enabled = false;
            this.verwerfen.Location = new System.Drawing.Point(149, 212);
            this.verwerfen.Name = "verwerfen";
            this.verwerfen.Size = new System.Drawing.Size(75, 23);
            this.verwerfen.TabIndex = 2;
            this.verwerfen.Text = "verwerfen";
            this.verwerfen.UseVisualStyleBackColor = true;
            this.verwerfen.Click += new System.EventHandler(this.verwerfen_Click);
            // 
            // BasisModulForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.verwerfen);
            this.Controls.Add(this.speichern);
            this.Controls.Add(this.label1);
            this.Name = "BasisModulForm";
            this.Text = "ModulForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BasisModulForm_FormClosing);
            this.Load += new System.EventHandler(this.BasisModulForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Label label1;
        protected System.Windows.Forms.Button speichern;
        protected System.Windows.Forms.Button verwerfen;
    }
}