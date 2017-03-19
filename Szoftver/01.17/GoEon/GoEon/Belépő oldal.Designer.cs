namespace GoEon
{
    partial class Belépő_oldal
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
            this.mai_hatarido_listBox = new System.Windows.Forms.ListBox();
            this.hataridos_feladatok_group = new System.Windows.Forms.GroupBox();
            this.tovabb_Button = new System.Windows.Forms.Button();
            this.csapat_hozzarendeles_Button = new System.Windows.Forms.Button();
            this.hataridos_feladatok_group.SuspendLayout();
            this.SuspendLayout();
            // 
            // mai_hatarido_listBox
            // 
            this.mai_hatarido_listBox.FormattingEnabled = true;
            this.mai_hatarido_listBox.Location = new System.Drawing.Point(19, 19);
            this.mai_hatarido_listBox.Name = "mai_hatarido_listBox";
            this.mai_hatarido_listBox.Size = new System.Drawing.Size(456, 472);
            this.mai_hatarido_listBox.TabIndex = 0;
            // 
            // hataridos_feladatok_group
            // 
            this.hataridos_feladatok_group.Controls.Add(this.mai_hatarido_listBox);
            this.hataridos_feladatok_group.Location = new System.Drawing.Point(692, 60);
            this.hataridos_feladatok_group.Name = "hataridos_feladatok_group";
            this.hataridos_feladatok_group.Size = new System.Drawing.Size(494, 509);
            this.hataridos_feladatok_group.TabIndex = 1;
            this.hataridos_feladatok_group.TabStop = false;
            this.hataridos_feladatok_group.Text = "A mai határidővel rendelkező feladatok";
            // 
            // tovabb_Button
            // 
            this.tovabb_Button.Location = new System.Drawing.Point(535, 620);
            this.tovabb_Button.Name = "tovabb_Button";
            this.tovabb_Button.Size = new System.Drawing.Size(128, 40);
            this.tovabb_Button.TabIndex = 2;
            this.tovabb_Button.Text = "Tovább a főoldalra";
            this.tovabb_Button.UseVisualStyleBackColor = true;
            this.tovabb_Button.Click += new System.EventHandler(this.tovabb_Button_Click);
            // 
            // csapat_hozzarendeles_Button
            // 
            this.csapat_hozzarendeles_Button.Location = new System.Drawing.Point(873, 575);
            this.csapat_hozzarendeles_Button.Name = "csapat_hozzarendeles_Button";
            this.csapat_hozzarendeles_Button.Size = new System.Drawing.Size(152, 29);
            this.csapat_hozzarendeles_Button.TabIndex = 3;
            this.csapat_hozzarendeles_Button.Text = "Csapat hozzárendelése";
            this.csapat_hozzarendeles_Button.UseVisualStyleBackColor = true;
            this.csapat_hozzarendeles_Button.Click += new System.EventHandler(this.csapat_hozzarendeles_Button_Click);
            // 
            // Belépő_oldal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.csapat_hozzarendeles_Button);
            this.Controls.Add(this.tovabb_Button);
            this.Controls.Add(this.hataridos_feladatok_group);
            this.Name = "Belépő_oldal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Belépő_oldal";
            this.Load += new System.EventHandler(this.Belépő_oldal_Load);
            this.hataridos_feladatok_group.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox mai_hatarido_listBox;
        private System.Windows.Forms.GroupBox hataridos_feladatok_group;
        private System.Windows.Forms.Button tovabb_Button;
        private System.Windows.Forms.Button csapat_hozzarendeles_Button;
    }
}