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
            this.csapat_reszletel_Button = new System.Windows.Forms.Button();
            this.feladat_reszletek_Button = new System.Windows.Forms.Button();
            this.vissza_Button = new System.Windows.Forms.Button();
            this.osszeallitas_group = new System.Windows.Forms.GroupBox();
            this.datePicker_label = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.hozzaad_button = new System.Windows.Forms.Button();
            this.tasks_listBox = new System.Windows.Forms.ListBox();
            this.team_task_listBox = new System.Windows.Forms.ListBox();
            this.megjelenites_Button = new System.Windows.Forms.Button();
            this.information_listBox = new System.Windows.Forms.ListBox();
            this.task_delete_button = new System.Windows.Forms.Button();
            this.Hozzarendeles_groupBox = new System.Windows.Forms.GroupBox();
            this.date_comboBox = new System.Windows.Forms.ComboBox();
            this.information_label = new System.Windows.Forms.Label();
            this.team_label = new System.Windows.Forms.Label();
            this.team_task_label = new System.Windows.Forms.Label();
            this.team_listBox = new System.Windows.Forms.ListBox();
            this.veglegesites_button = new System.Windows.Forms.Button();
            this.feladatok_group.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.csapatok_group.SuspendLayout();
            this.osszeallitas_group.SuspendLayout();
            this.Hozzarendeles_groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // feladatok_group
            // 
            this.feladatok_group.Controls.Add(this.feladatok_listBox);
            this.feladatok_group.Controls.Add(this.menuStrip1);
            this.feladatok_group.Location = new System.Drawing.Point(30, 12);
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
            this.feladatok_listBox.SelectedIndexChanged += new System.EventHandler(this.feladatok_listBox_SelectedIndexChanged);
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
            this.csapatok_group.Location = new System.Drawing.Point(423, 12);
            this.csapatok_group.Name = "csapatok_group";
            this.csapatok_group.Size = new System.Drawing.Size(352, 238);
            this.csapatok_group.TabIndex = 1;
            this.csapatok_group.TabStop = false;
            this.csapatok_group.Text = "Csapatok listája";
            // 
            // csapatok_listBox
            // 
            this.csapatok_listBox.FormattingEnabled = true;
            this.csapatok_listBox.Location = new System.Drawing.Point(6, 19);
            this.csapatok_listBox.Name = "csapatok_listBox";
            this.csapatok_listBox.Size = new System.Drawing.Size(340, 212);
            this.csapatok_listBox.TabIndex = 0;
            // 
            // csapat_reszletel_Button
            // 
            this.csapat_reszletel_Button.Location = new System.Drawing.Point(554, 256);
            this.csapat_reszletel_Button.Name = "csapat_reszletel_Button";
            this.csapat_reszletel_Button.Size = new System.Drawing.Size(75, 30);
            this.csapat_reszletel_Button.TabIndex = 3;
            this.csapat_reszletel_Button.Text = "Részletek";
            this.csapat_reszletel_Button.UseVisualStyleBackColor = true;
            this.csapat_reszletel_Button.Click += new System.EventHandler(this.csapat_reszletel_Button_Click);
            // 
            // feladat_reszletek_Button
            // 
            this.feladat_reszletek_Button.Location = new System.Drawing.Point(173, 510);
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
            this.osszeallitas_group.Controls.Add(this.datePicker_label);
            this.osszeallitas_group.Controls.Add(this.dateTimePicker);
            this.osszeallitas_group.Controls.Add(this.hozzaad_button);
            this.osszeallitas_group.Controls.Add(this.tasks_listBox);
            this.osszeallitas_group.Location = new System.Drawing.Point(800, 12);
            this.osszeallitas_group.Name = "osszeallitas_group";
            this.osszeallitas_group.Size = new System.Drawing.Size(431, 274);
            this.osszeallitas_group.TabIndex = 6;
            this.osszeallitas_group.TabStop = false;
            this.osszeallitas_group.Text = "Összeállítás";
            // 
            // datePicker_label
            // 
            this.datePicker_label.AutoSize = true;
            this.datePicker_label.Location = new System.Drawing.Point(215, 116);
            this.datePicker_label.Name = "datePicker_label";
            this.datePicker_label.Size = new System.Drawing.Size(158, 13);
            this.datePicker_label.TabIndex = 3;
            this.datePicker_label.Text = "Válassza ki a teljesítés dátumát:";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(215, 135);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(210, 20);
            this.dateTimePicker.TabIndex = 2;
            this.dateTimePicker.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
            // 
            // hozzaad_button
            // 
            this.hozzaad_button.Location = new System.Drawing.Point(283, 201);
            this.hozzaad_button.Name = "hozzaad_button";
            this.hozzaad_button.Size = new System.Drawing.Size(75, 30);
            this.hozzaad_button.TabIndex = 1;
            this.hozzaad_button.Text = "Hozzáadás";
            this.hozzaad_button.UseVisualStyleBackColor = true;
            this.hozzaad_button.Click += new System.EventHandler(this.hozzaad_button_Click);
            // 
            // tasks_listBox
            // 
            this.tasks_listBox.FormattingEnabled = true;
            this.tasks_listBox.Location = new System.Drawing.Point(6, 23);
            this.tasks_listBox.Name = "tasks_listBox";
            this.tasks_listBox.Size = new System.Drawing.Size(191, 225);
            this.tasks_listBox.TabIndex = 0;
            this.tasks_listBox.SelectedIndexChanged += new System.EventHandler(this.tasks_listBox_SelectedIndexChanged);
            // 
            // team_task_listBox
            // 
            this.team_task_listBox.AllowDrop = true;
            this.team_task_listBox.FormattingEnabled = true;
            this.team_task_listBox.Location = new System.Drawing.Point(261, 67);
            this.team_task_listBox.Name = "team_task_listBox";
            this.team_task_listBox.Size = new System.Drawing.Size(195, 212);
            this.team_task_listBox.TabIndex = 8;
            this.team_task_listBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.team_task_listBox_DragDrop);
            this.team_task_listBox.DragOver += new System.Windows.Forms.DragEventHandler(this.team_task_listBox_DragOver);
            this.team_task_listBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.team_task_listBox_MouseDown);
            // 
            // megjelenites_Button
            // 
            this.megjelenites_Button.Location = new System.Drawing.Point(528, 282);
            this.megjelenites_Button.Name = "megjelenites_Button";
            this.megjelenites_Button.Size = new System.Drawing.Size(176, 30);
            this.megjelenites_Button.TabIndex = 9;
            this.megjelenites_Button.Text = "Megjelenítés a térképen";
            this.megjelenites_Button.UseVisualStyleBackColor = true;
            this.megjelenites_Button.Click += new System.EventHandler(this.megjelenites_Button_Click);
            // 
            // information_listBox
            // 
            this.information_listBox.FormattingEnabled = true;
            this.information_listBox.Location = new System.Drawing.Point(489, 67);
            this.information_listBox.Name = "information_listBox";
            this.information_listBox.Size = new System.Drawing.Size(240, 212);
            this.information_listBox.TabIndex = 10;
            // 
            // task_delete_button
            // 
            this.task_delete_button.Location = new System.Drawing.Point(280, 282);
            this.task_delete_button.Name = "task_delete_button";
            this.task_delete_button.Size = new System.Drawing.Size(164, 30);
            this.task_delete_button.TabIndex = 11;
            this.task_delete_button.Text = "Kiválasztott feladat törlése";
            this.task_delete_button.UseVisualStyleBackColor = true;
            this.task_delete_button.Click += new System.EventHandler(this.task_delete_button_Click);
            // 
            // Hozzarendeles_groupBox
            // 
            this.Hozzarendeles_groupBox.Controls.Add(this.date_comboBox);
            this.Hozzarendeles_groupBox.Controls.Add(this.task_delete_button);
            this.Hozzarendeles_groupBox.Controls.Add(this.information_label);
            this.Hozzarendeles_groupBox.Controls.Add(this.megjelenites_Button);
            this.Hozzarendeles_groupBox.Controls.Add(this.information_listBox);
            this.Hozzarendeles_groupBox.Controls.Add(this.team_label);
            this.Hozzarendeles_groupBox.Controls.Add(this.team_task_label);
            this.Hozzarendeles_groupBox.Controls.Add(this.team_task_listBox);
            this.Hozzarendeles_groupBox.Controls.Add(this.team_listBox);
            this.Hozzarendeles_groupBox.Location = new System.Drawing.Point(473, 306);
            this.Hozzarendeles_groupBox.Name = "Hozzarendeles_groupBox";
            this.Hozzarendeles_groupBox.Size = new System.Drawing.Size(779, 318);
            this.Hozzarendeles_groupBox.TabIndex = 15;
            this.Hozzarendeles_groupBox.TabStop = false;
            this.Hozzarendeles_groupBox.Text = "Hozzárendelések";
            // 
            // date_comboBox
            // 
            this.date_comboBox.FormattingEnabled = true;
            this.date_comboBox.Location = new System.Drawing.Point(290, 19);
            this.date_comboBox.Name = "date_comboBox";
            this.date_comboBox.Size = new System.Drawing.Size(143, 21);
            this.date_comboBox.TabIndex = 15;
            this.date_comboBox.Text = "Válassza ki a dátumot";
            this.date_comboBox.SelectedIndexChanged += new System.EventHandler(this.date_comboBox_SelectedIndexChanged);
            // 
            // information_label
            // 
            this.information_label.AutoSize = true;
            this.information_label.Location = new System.Drawing.Point(486, 51);
            this.information_label.Name = "information_label";
            this.information_label.Size = new System.Drawing.Size(65, 13);
            this.information_label.TabIndex = 14;
            this.information_label.Text = "Információk:";
            // 
            // team_label
            // 
            this.team_label.AutoSize = true;
            this.team_label.Location = new System.Drawing.Point(13, 51);
            this.team_label.Name = "team_label";
            this.team_label.Size = new System.Drawing.Size(55, 13);
            this.team_label.TabIndex = 12;
            this.team_label.Text = "Csapatok:";
            // 
            // team_task_label
            // 
            this.team_task_label.AutoSize = true;
            this.team_task_label.Location = new System.Drawing.Point(258, 51);
            this.team_task_label.Name = "team_task_label";
            this.team_task_label.Size = new System.Drawing.Size(142, 13);
            this.team_task_label.TabIndex = 13;
            this.team_task_label.Text = "Csapathoz rendelt feladatok:";
            // 
            // team_listBox
            // 
            this.team_listBox.FormattingEnabled = true;
            this.team_listBox.Location = new System.Drawing.Point(16, 67);
            this.team_listBox.Name = "team_listBox";
            this.team_listBox.Size = new System.Drawing.Size(198, 212);
            this.team_listBox.TabIndex = 7;
            this.team_listBox.SelectedIndexChanged += new System.EventHandler(this.team_listBox_SelectedIndexChanged);
            // 
            // veglegesites_button
            // 
            this.veglegesites_button.Location = new System.Drawing.Point(1151, 643);
            this.veglegesites_button.Name = "veglegesites_button";
            this.veglegesites_button.Size = new System.Drawing.Size(101, 29);
            this.veglegesites_button.TabIndex = 16;
            this.veglegesites_button.Text = "Véglegesítés";
            this.veglegesites_button.UseVisualStyleBackColor = true;
            this.veglegesites_button.Click += new System.EventHandler(this.veglegesites_button_Click);
            // 
            // Csapat_hozzarendeles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.veglegesites_button);
            this.Controls.Add(this.osszeallitas_group);
            this.Controls.Add(this.vissza_Button);
            this.Controls.Add(this.feladat_reszletek_Button);
            this.Controls.Add(this.csapat_reszletel_Button);
            this.Controls.Add(this.csapatok_group);
            this.Controls.Add(this.feladatok_group);
            this.Controls.Add(this.Hozzarendeles_groupBox);
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
            this.osszeallitas_group.ResumeLayout(false);
            this.osszeallitas_group.PerformLayout();
            this.Hozzarendeles_groupBox.ResumeLayout(false);
            this.Hozzarendeles_groupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox feladatok_group;
        private System.Windows.Forms.ListBox feladatok_listBox;
        private System.Windows.Forms.GroupBox csapatok_group;
        private System.Windows.Forms.ListBox csapatok_listBox;
        private System.Windows.Forms.Button csapat_reszletel_Button;
        private System.Windows.Forms.Button feladat_reszletek_Button;
        private System.Windows.Forms.Button vissza_Button;
        private System.Windows.Forms.GroupBox osszeallitas_group;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem listázásibeállításokToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem összesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem normálPriorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sügősFeladatokToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maiHatáridővelRendelkezőFeladatokToolStripMenuItem;
        private System.Windows.Forms.ListBox team_task_listBox;
        private System.Windows.Forms.Button megjelenites_Button;
        private System.Windows.Forms.ListBox information_listBox;
        private System.Windows.Forms.Button task_delete_button;
        private System.Windows.Forms.GroupBox Hozzarendeles_groupBox;
        private System.Windows.Forms.ListBox tasks_listBox;
        private System.Windows.Forms.Button hozzaad_button;
        private System.Windows.Forms.ComboBox date_comboBox;
        private System.Windows.Forms.Label information_label;
        private System.Windows.Forms.Label team_label;
        private System.Windows.Forms.Label team_task_label;
        private System.Windows.Forms.ListBox team_listBox;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Label datePicker_label;
        private System.Windows.Forms.Button veglegesites_button;
    }
}