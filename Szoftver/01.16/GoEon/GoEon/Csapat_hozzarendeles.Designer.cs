namespace GoEon
{
    partial class Csapat_hozzarendeles
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.listázásibeállításokToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.összesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.normálPriorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sügősFeladatokToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maiHatáridővelRendelkezőFeladatokToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.csapatok_group = new System.Windows.Forms.GroupBox();
            this.csapatok_listBox = new System.Windows.Forms.ListBox();
            this.TaskControll = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.csapat_reszletel_Button = new System.Windows.Forms.Button();
            this.feladat_reszletek_Button = new System.Windows.Forms.Button();
            this.vissza_Button = new System.Windows.Forms.Button();
            this.osszeallitas_group = new System.Windows.Forms.GroupBox();
            this.feladatok_label = new System.Windows.Forms.Label();
            this.csapat_label = new System.Windows.Forms.Label();
            this.hozzaad_button = new System.Windows.Forms.Button();
            this.feladatok_comboBox = new System.Windows.Forms.ComboBox();
            this.csapat_comboBox = new System.Windows.Forms.ComboBox();
            this.feladatok_group.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.csapatok_group.SuspendLayout();
            this.TaskControll.SuspendLayout();
            this.osszeallitas_group.SuspendLayout();
            this.SuspendLayout();
            // 
            // feladatok_group
            // 
            this.feladatok_group.Controls.Add(this.feladatok_listBox);
            this.feladatok_group.Controls.Add(this.menuStrip1);
            this.feladatok_group.Location = new System.Drawing.Point(34, 25);
            this.feladatok_group.Name = "feladatok_group";
            this.feladatok_group.Size = new System.Drawing.Size(366, 492);
            this.feladatok_group.TabIndex = 0;
            this.feladatok_group.TabStop = false;
            this.feladatok_group.Text = "Elvégzendő feladatok listája";
            // 
            // feladatok_listBox
            // 
            this.feladatok_listBox.FormattingEnabled = true;
            this.feladatok_listBox.Location = new System.Drawing.Point(17, 63);
            this.feladatok_listBox.Name = "feladatok_listBox";
            this.feladatok_listBox.Size = new System.Drawing.Size(334, 407);
            this.feladatok_listBox.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listázásibeállításokToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(3, 16);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(360, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // listázásibeállításokToolStripMenuItem
            // 
            this.listázásibeállításokToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.összesToolStripMenuItem,
            this.normálPriorToolStripMenuItem,
            this.sügősFeladatokToolStripMenuItem,
            this.maiHatáridővelRendelkezőFeladatokToolStripMenuItem});
            this.listázásibeállításokToolStripMenuItem.Name = "listázásibeállításokToolStripMenuItem";
            this.listázásibeállításokToolStripMenuItem.Size = new System.Drawing.Size(121, 20);
            this.listázásibeállításokToolStripMenuItem.Text = "Listázási beállítások";
            // 
            // összesToolStripMenuItem
            // 
            this.összesToolStripMenuItem.Name = "összesToolStripMenuItem";
            this.összesToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
            this.összesToolStripMenuItem.Text = "Összes";
            this.összesToolStripMenuItem.Click += new System.EventHandler(this.összesToolStripMenuItem_Click);
            // 
            // normálPriorToolStripMenuItem
            // 
            this.normálPriorToolStripMenuItem.Name = "normálPriorToolStripMenuItem";
            this.normálPriorToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
            this.normálPriorToolStripMenuItem.Text = "Normál feladatok";
            this.normálPriorToolStripMenuItem.Click += new System.EventHandler(this.normálPriorToolStripMenuItem_Click);
            // 
            // sügősFeladatokToolStripMenuItem
            // 
            this.sügősFeladatokToolStripMenuItem.Name = "sügősFeladatokToolStripMenuItem";
            this.sügősFeladatokToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
            this.sügősFeladatokToolStripMenuItem.Text = "Sügős feladatok";
            this.sügősFeladatokToolStripMenuItem.Click += new System.EventHandler(this.sügősFeladatokToolStripMenuItem_Click);
            // 
            // maiHatáridővelRendelkezőFeladatokToolStripMenuItem
            // 
            this.maiHatáridővelRendelkezőFeladatokToolStripMenuItem.Name = "maiHatáridővelRendelkezőFeladatokToolStripMenuItem";
            this.maiHatáridővelRendelkezőFeladatokToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
            this.maiHatáridővelRendelkezőFeladatokToolStripMenuItem.Text = "Mai határidővel rendelkező feladatok";
            this.maiHatáridővelRendelkezőFeladatokToolStripMenuItem.Click += new System.EventHandler(this.maiHatáridővelRendelkezőFeladatokToolStripMenuItem_Click);
            // 
            // csapatok_group
            // 
            this.csapatok_group.Controls.Add(this.csapatok_listBox);
            this.csapatok_group.Location = new System.Drawing.Point(430, 25);
            this.csapatok_group.Name = "csapatok_group";
            this.csapatok_group.Size = new System.Drawing.Size(352, 259);
            this.csapatok_group.TabIndex = 1;
            this.csapatok_group.TabStop = false;
            this.csapatok_group.Text = "Csapatok listája";
            // 
            // csapatok_listBox
            // 
            this.csapatok_listBox.FormattingEnabled = true;
            this.csapatok_listBox.Location = new System.Drawing.Point(6, 19);
            this.csapatok_listBox.Name = "csapatok_listBox";
            this.csapatok_listBox.Size = new System.Drawing.Size(340, 225);
            this.csapatok_listBox.TabIndex = 0;
            // 
            // TaskControll
            // 
            this.TaskControll.Controls.Add(this.tabPage1);
            this.TaskControll.Controls.Add(this.tabPage2);
            this.TaskControll.Location = new System.Drawing.Point(542, 348);
            this.TaskControll.Name = "TaskControll";
            this.TaskControll.SelectedIndex = 0;
            this.TaskControll.Size = new System.Drawing.Size(697, 301);
            this.TaskControll.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(689, 275);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(689, 275);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // csapat_reszletel_Button
            // 
            this.csapat_reszletel_Button.Location = new System.Drawing.Point(561, 290);
            this.csapat_reszletel_Button.Name = "csapat_reszletel_Button";
            this.csapat_reszletel_Button.Size = new System.Drawing.Size(75, 30);
            this.csapat_reszletel_Button.TabIndex = 3;
            this.csapat_reszletel_Button.Text = "Részletek";
            this.csapat_reszletel_Button.UseVisualStyleBackColor = true;
            this.csapat_reszletel_Button.Click += new System.EventHandler(this.csapat_reszletel_Button_Click);
            // 
            // feladat_reszletek_Button
            // 
            this.feladat_reszletek_Button.Location = new System.Drawing.Point(173, 535);
            this.feladat_reszletek_Button.Name = "feladat_reszletek_Button";
            this.feladat_reszletek_Button.Size = new System.Drawing.Size(75, 30);
            this.feladat_reszletek_Button.TabIndex = 4;
            this.feladat_reszletek_Button.Text = "Részletek";
            this.feladat_reszletek_Button.UseVisualStyleBackColor = true;
            this.feladat_reszletek_Button.Click += new System.EventHandler(this.feladat_reszletek_Button_Click);
            // 
            // vissza_Button
            // 
            this.vissza_Button.Location = new System.Drawing.Point(12, 639);
            this.vissza_Button.Name = "vissza_Button";
            this.vissza_Button.Size = new System.Drawing.Size(75, 30);
            this.vissza_Button.TabIndex = 5;
            this.vissza_Button.Text = "Vissza";
            this.vissza_Button.UseVisualStyleBackColor = true;
            this.vissza_Button.Click += new System.EventHandler(this.vissza_Button_Click);
            // 
            // osszeallitas_group
            // 
            this.osszeallitas_group.Controls.Add(this.feladatok_label);
            this.osszeallitas_group.Controls.Add(this.csapat_label);
            this.osszeallitas_group.Controls.Add(this.hozzaad_button);
            this.osszeallitas_group.Controls.Add(this.feladatok_comboBox);
            this.osszeallitas_group.Controls.Add(this.csapat_comboBox);
            this.osszeallitas_group.Location = new System.Drawing.Point(845, 25);
            this.osszeallitas_group.Name = "osszeallitas_group";
            this.osszeallitas_group.Size = new System.Drawing.Size(390, 259);
            this.osszeallitas_group.TabIndex = 6;
            this.osszeallitas_group.TabStop = false;
            this.osszeallitas_group.Text = "Összeállítás";
            // 
            // feladatok_label
            // 
            this.feladatok_label.AutoSize = true;
            this.feladatok_label.Location = new System.Drawing.Point(31, 150);
            this.feladatok_label.Name = "feladatok_label";
            this.feladatok_label.Size = new System.Drawing.Size(103, 13);
            this.feladatok_label.TabIndex = 4;
            this.feladatok_label.Text = "Feladat kiválasztása";
            // 
            // csapat_label
            // 
            this.csapat_label.AutoSize = true;
            this.csapat_label.Location = new System.Drawing.Point(31, 51);
            this.csapat_label.Name = "csapat_label";
            this.csapat_label.Size = new System.Drawing.Size(101, 13);
            this.csapat_label.TabIndex = 3;
            this.csapat_label.Text = "Csapat kiválasztása";
            // 
            // hozzaad_button
            // 
            this.hozzaad_button.Location = new System.Drawing.Point(283, 111);
            this.hozzaad_button.Name = "hozzaad_button";
            this.hozzaad_button.Size = new System.Drawing.Size(75, 30);
            this.hozzaad_button.TabIndex = 2;
            this.hozzaad_button.Text = "Hozzáadás";
            this.hozzaad_button.UseVisualStyleBackColor = true;
            // 
            // feladatok_comboBox
            // 
            this.feladatok_comboBox.FormattingEnabled = true;
            this.feladatok_comboBox.Location = new System.Drawing.Point(31, 166);
            this.feladatok_comboBox.Name = "feladatok_comboBox";
            this.feladatok_comboBox.Size = new System.Drawing.Size(225, 21);
            this.feladatok_comboBox.TabIndex = 1;
            // 
            // csapat_comboBox
            // 
            this.csapat_comboBox.FormattingEnabled = true;
            this.csapat_comboBox.Location = new System.Drawing.Point(31, 70);
            this.csapat_comboBox.Name = "csapat_comboBox";
            this.csapat_comboBox.Size = new System.Drawing.Size(225, 21);
            this.csapat_comboBox.TabIndex = 0;
            // 
            // Csapat_hozzarendeles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.osszeallitas_group);
            this.Controls.Add(this.vissza_Button);
            this.Controls.Add(this.feladat_reszletek_Button);
            this.Controls.Add(this.csapat_reszletel_Button);
            this.Controls.Add(this.TaskControll);
            this.Controls.Add(this.csapatok_group);
            this.Controls.Add(this.feladatok_group);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Csapat_hozzarendeles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Csapat_hozzarendeles";
            this.Load += new System.EventHandler(this.Csapat_hozzarendeles_Load);
            this.feladatok_group.ResumeLayout(false);
            this.feladatok_group.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.csapatok_group.ResumeLayout(false);
            this.TaskControll.ResumeLayout(false);
            this.osszeallitas_group.ResumeLayout(false);
            this.osszeallitas_group.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox feladatok_group;
        private System.Windows.Forms.ListBox feladatok_listBox;
        private System.Windows.Forms.GroupBox csapatok_group;
        private System.Windows.Forms.ListBox csapatok_listBox;
        private System.Windows.Forms.TabControl TaskControll;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button csapat_reszletel_Button;
        private System.Windows.Forms.Button feladat_reszletek_Button;
        private System.Windows.Forms.Button vissza_Button;
        private System.Windows.Forms.GroupBox osszeallitas_group;
        private System.Windows.Forms.Label feladatok_label;
        private System.Windows.Forms.Label csapat_label;
        private System.Windows.Forms.Button hozzaad_button;
        private System.Windows.Forms.ComboBox feladatok_comboBox;
        private System.Windows.Forms.ComboBox csapat_comboBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem listázásibeállításokToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem összesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem normálPriorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sügősFeladatokToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maiHatáridővelRendelkezőFeladatokToolStripMenuItem;
    }
}