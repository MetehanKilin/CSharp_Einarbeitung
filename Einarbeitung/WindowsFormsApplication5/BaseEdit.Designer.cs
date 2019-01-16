namespace WindowsFormsApplication5
{
    partial class BaseEdit
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
            this.speichernButton = new System.Windows.Forms.Button();
            this.verwerfenButton = new System.Windows.Forms.Button();
            this.abbrechenButton = new System.Windows.Forms.Button();
            this.editLabel = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // speichernButton
            // 
            this.speichernButton.Location = new System.Drawing.Point(36, 255);
            this.speichernButton.Name = "speichernButton";
            this.speichernButton.Size = new System.Drawing.Size(75, 23);
            this.speichernButton.TabIndex = 0;
            this.speichernButton.Text = "speichern";
            this.speichernButton.UseVisualStyleBackColor = true;
            this.speichernButton.Click += new System.EventHandler(this.speichernButton_Click);
            // 
            // verwerfenButton
            // 
            this.verwerfenButton.Location = new System.Drawing.Point(143, 255);
            this.verwerfenButton.Name = "verwerfenButton";
            this.verwerfenButton.Size = new System.Drawing.Size(75, 23);
            this.verwerfenButton.TabIndex = 1;
            this.verwerfenButton.Text = "verwerfen";
            this.verwerfenButton.UseVisualStyleBackColor = true;
            this.verwerfenButton.Click += new System.EventHandler(this.verwerfenButton_Click);
            // 
            // abbrechenButton
            // 
            this.abbrechenButton.Location = new System.Drawing.Point(243, 255);
            this.abbrechenButton.Name = "abbrechenButton";
            this.abbrechenButton.Size = new System.Drawing.Size(75, 23);
            this.abbrechenButton.TabIndex = 2;
            this.abbrechenButton.Text = "Abbrechen";
            this.abbrechenButton.UseVisualStyleBackColor = true;
            this.abbrechenButton.Click += new System.EventHandler(this.abbrechenButton_Click);
            // 
            // editLabel
            // 
            this.editLabel.AutoSize = true;
            this.editLabel.Location = new System.Drawing.Point(60, 31);
            this.editLabel.Name = "editLabel";
            this.editLabel.Size = new System.Drawing.Size(50, 13);
            this.editLabel.TabIndex = 3;
            this.editLabel.Text = "editLabel";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(63, 88);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "neuer Wert";
            // 
            // BaseEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.editLabel);
            this.Controls.Add(this.abbrechenButton);
            this.Controls.Add(this.verwerfenButton);
            this.Controls.Add(this.speichernButton);
            this.Name = "BaseEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button speichernButton;
        private System.Windows.Forms.Button verwerfenButton;
        private System.Windows.Forms.Button abbrechenButton;
        public System.Windows.Forms.Label editLabel;
        public System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.Label label1;
    }
}