namespace GoEon
{
    partial class Feladat_részletek
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
            this.feladatok_group = new System.Windows.Forms.GroupBox();
            this.feladatok_listBox = new System.Windows.Forms.ListBox();
            this.adatok_group = new System.Windows.Forms.GroupBox();
            this.szukseges_kepesites_listBox = new System.Windows.Forms.ListBox();
            this.szukseges_eszkozok_listBox = new System.Windows.Forms.ListBox();
            this.adatok_listBox = new System.Windows.Forms.ListBox();
            this.vissza_button = new System.Windows.Forms.Button();
            this.feladatok_group.SuspendLayout();
            this.adatok_group.SuspendLayout();
            this.SuspendLayout();
            // 
            // feladatok_group
            // 
            this.feladatok_group.Controls.Add(this.feladatok_listBox);
            this.feladatok_group.Location = new System.Drawing.Point(30, 57);
            this.feladatok_group.Name = "feladatok_group";
            this.feladatok_group.Size = new System.Drawing.Size(424, 486);
            this.feladatok_group.TabIndex = 0;
            this.feladatok_group.TabStop = false;
            this.feladatok_group.Text = "Elvégzendő feladatok listája";
            // 
            // feladatok_listBox
            // 
            this.feladatok_listBox.FormattingEnabled = true;
            this.feladatok_listBox.Location = new System.Drawing.Point(6, 21);
            this.feladatok_listBox.Name = "feladatok_listBox";
            this.feladatok_listBox.Size = new System.Drawing.Size(409, 446);
            this.feladatok_listBox.TabIndex = 0;
            this.feladatok_listBox.SelectedIndexChanged += new System.EventHandler(this.feladatok_listBox_SelectedIndexChanged);
            // 
            // adatok_group
            // 
            this.adatok_group.Controls.Add(this.szukseges_kepesites_listBox);
            this.adatok_group.Controls.Add(this.szukseges_eszkozok_listBox);
            this.adatok_group.Controls.Add(this.adatok_listBox);
            this.adatok_group.Location = new System.Drawing.Point(536, 57);
            this.adatok_group.Name = "adatok_group";
            this.adatok_group.Size = new System.Drawing.Size(695, 486);
            this.adatok_group.TabIndex = 1;
            this.adatok_group.TabStop = false;
            this.adatok_group.Text = "Adatok";
            // 
            // szukseges_kepesites_listBox
            // 
            this.szukseges_kepesites_listBox.FormattingEnabled = true;
            this.szukseges_kepesites_listBox.Location = new System.Drawing.Point(367, 249);
            this.szukseges_kepesites_listBox.Name = "szukseges_kepesites_listBox";
            this.szukseges_kepesites_listBox.Size = new System.Drawing.Size(306, 212);
            this.szukseges_kepesites_listBox.TabIndex = 2;
            // 
            // szukseges_eszkozok_listBox
            // 
            this.szukseges_eszkozok_listBox.FormattingEnabled = true;
            this.szukseges_eszkozok_listBox.Location = new System.Drawing.Point(367, 21);
            this.szukseges_eszkozok_listBox.Name = "szukseges_eszkozok_listBox";
            this.szukseges_eszkozok_listBox.Size = new System.Drawing.Size(306, 186);
            this.szukseges_eszkozok_listBox.TabIndex = 1;
            // 
            // adatok_listBox
            // 
            this.adatok_listBox.FormattingEnabled = true;
            this.adatok_listBox.HorizontalScrollbar = true;
            this.adatok_listBox.Location = new System.Drawing.Point(16, 21);
            this.adatok_listBox.Name = "adatok_listBox";
            this.adatok_listBox.ScrollAlwaysVisible = true;
            this.adatok_listBox.Size = new System.Drawing.Size(312, 446);
            this.adatok_listBox.TabIndex = 0;
            // 
            // vissza_button
            // 
            this.vissza_button.Location = new System.Drawing.Point(30, 628);
            this.vissza_button.Name = "vissza_button";
            this.vissza_button.Size = new System.Drawing.Size(75, 30);
            this.vissza_button.TabIndex = 2;
            this.vissza_button.Text = "Vissza";
            this.vissza_button.UseVisualStyleBackColor = true;
            this.vissza_button.Click += new System.EventHandler(this.vissza_button_Click);
            // 
            // Feladat_részletek
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.vissza_button);
            this.Controls.Add(this.adatok_group);
            this.Controls.Add(this.feladatok_group);
            this.Name = "Feladat_részletek";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Feladatok";
            this.Load += new System.EventHandler(this.Feladat_részletek_Load);
            this.feladatok_group.ResumeLayout(false);
            this.adatok_group.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox feladatok_group;
        private System.Windows.Forms.ListBox feladatok_listBox;
        private System.Windows.Forms.GroupBox adatok_group;
        private System.Windows.Forms.Button vissza_button;
        private System.Windows.Forms.ListBox szukseges_kepesites_listBox;
        private System.Windows.Forms.ListBox szukseges_eszkozok_listBox;
        private System.Windows.Forms.ListBox adatok_listBox;
    }
}