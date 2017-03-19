namespace GoEon
{
    partial class Hozzadas
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
            this.team_listBox = new System.Windows.Forms.ListBox();
            this.hozzaadas_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // team_listBox
            // 
            this.team_listBox.FormattingEnabled = true;
            this.team_listBox.Location = new System.Drawing.Point(55, 12);
            this.team_listBox.Name = "team_listBox";
            this.team_listBox.Size = new System.Drawing.Size(261, 238);
            this.team_listBox.TabIndex = 0;
            // 
            // hozzaadas_button
            // 
            this.hozzaadas_button.Location = new System.Drawing.Point(131, 269);
            this.hozzaadas_button.Name = "hozzaadas_button";
            this.hozzaadas_button.Size = new System.Drawing.Size(99, 30);
            this.hozzaadas_button.TabIndex = 1;
            this.hozzaadas_button.Text = "Hozzáadás";
            this.hozzaadas_button.UseVisualStyleBackColor = true;
            this.hozzaadas_button.Click += new System.EventHandler(this.hozzaadas_button_Click);
            // 
            // Hozzadas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 311);
            this.Controls.Add(this.hozzaadas_button);
            this.Controls.Add(this.team_listBox);
            this.Name = "Hozzadas";
            this.Text = "Hozzadás";
            this.Load += new System.EventHandler(this.Hozzadas_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox team_listBox;
        private System.Windows.Forms.Button hozzaadas_button;
    }
}