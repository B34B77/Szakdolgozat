namespace GoEon
{
    partial class Hozzarendeles_kezeles
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
            this.Hozzarendeles_groupBox = new System.Windows.Forms.GroupBox();
            this.date_comboBox = new System.Windows.Forms.ComboBox();
            this.task_delete_button = new System.Windows.Forms.Button();
            this.information_label = new System.Windows.Forms.Label();
            this.megjelenites_Button = new System.Windows.Forms.Button();
            this.information_listBox = new System.Windows.Forms.ListBox();
            this.team_label = new System.Windows.Forms.Label();
            this.team_task_label = new System.Windows.Forms.Label();
            this.team_task_listBox = new System.Windows.Forms.ListBox();
            this.team_listBox = new System.Windows.Forms.ListBox();
            this.vissza_button = new System.Windows.Forms.Button();
            this.mentes_button = new System.Windows.Forms.Button();
            this.riport_button = new System.Windows.Forms.Button();
            this.Hozzarendeles_groupBox.SuspendLayout();
            this.SuspendLayout();
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
            this.Hozzarendeles_groupBox.Location = new System.Drawing.Point(39, 38);
            this.Hozzarendeles_groupBox.Name = "Hozzarendeles_groupBox";
            this.Hozzarendeles_groupBox.Size = new System.Drawing.Size(833, 372);
            this.Hozzarendeles_groupBox.TabIndex = 24;
            this.Hozzarendeles_groupBox.TabStop = false;
            this.Hozzarendeles_groupBox.Text = "Hozzárendelések";
            // 
            // date_comboBox
            // 
            this.date_comboBox.FormattingEnabled = true;
            this.date_comboBox.Location = new System.Drawing.Point(330, 19);
            this.date_comboBox.Name = "date_comboBox";
            this.date_comboBox.Size = new System.Drawing.Size(143, 21);
            this.date_comboBox.Sorted = true;
            this.date_comboBox.TabIndex = 15;
            this.date_comboBox.Text = "Válassza ki a dátumot";
            this.date_comboBox.SelectedIndexChanged += new System.EventHandler(this.date_comboBox_SelectedIndexChanged);
            // 
            // task_delete_button
            // 
            this.task_delete_button.Location = new System.Drawing.Point(309, 322);
            this.task_delete_button.Name = "task_delete_button";
            this.task_delete_button.Size = new System.Drawing.Size(164, 30);
            this.task_delete_button.TabIndex = 11;
            this.task_delete_button.Text = "Kiválasztott feladat törlése";
            this.task_delete_button.UseVisualStyleBackColor = true;
            this.task_delete_button.Click += new System.EventHandler(this.task_delete_button_Click);
            // 
            // information_label
            // 
            this.information_label.AutoSize = true;
            this.information_label.Location = new System.Drawing.Point(554, 45);
            this.information_label.Name = "information_label";
            this.information_label.Size = new System.Drawing.Size(100, 13);
            this.information_label.TabIndex = 14;
            this.information_label.Text = "Csapat információk:";
            // 
            // megjelenites_Button
            // 
            this.megjelenites_Button.Location = new System.Drawing.Point(597, 322);
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
            this.information_listBox.HorizontalScrollbar = true;
            this.information_listBox.Location = new System.Drawing.Point(557, 61);
            this.information_listBox.Name = "information_listBox";
            this.information_listBox.Size = new System.Drawing.Size(257, 251);
            this.information_listBox.TabIndex = 10;
            // 
            // team_label
            // 
            this.team_label.AutoSize = true;
            this.team_label.Location = new System.Drawing.Point(13, 62);
            this.team_label.Name = "team_label";
            this.team_label.Size = new System.Drawing.Size(55, 13);
            this.team_label.TabIndex = 12;
            this.team_label.Text = "Csapatok:";
            // 
            // team_task_label
            // 
            this.team_task_label.AutoSize = true;
            this.team_task_label.Location = new System.Drawing.Point(287, 62);
            this.team_task_label.Name = "team_task_label";
            this.team_task_label.Size = new System.Drawing.Size(142, 13);
            this.team_task_label.TabIndex = 13;
            this.team_task_label.Text = "Csapathoz rendelt feladatok:";
            // 
            // team_task_listBox
            // 
            this.team_task_listBox.AllowDrop = true;
            this.team_task_listBox.FormattingEnabled = true;
            this.team_task_listBox.Location = new System.Drawing.Point(290, 78);
            this.team_task_listBox.Name = "team_task_listBox";
            this.team_task_listBox.Size = new System.Drawing.Size(217, 225);
            this.team_task_listBox.TabIndex = 8;
            this.team_task_listBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.team_task_listBox_DragDrop);
            this.team_task_listBox.DragOver += new System.Windows.Forms.DragEventHandler(this.team_task_listBox_DragOver);
            this.team_task_listBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.team_task_listBox_MouseDown);
            // 
            // team_listBox
            // 
            this.team_listBox.FormattingEnabled = true;
            this.team_listBox.Location = new System.Drawing.Point(16, 78);
            this.team_listBox.Name = "team_listBox";
            this.team_listBox.Size = new System.Drawing.Size(205, 225);
            this.team_listBox.TabIndex = 7;
            this.team_listBox.SelectedIndexChanged += new System.EventHandler(this.team_listBox_SelectedIndexChanged);
            // 
            // vissza_button
            // 
            this.vissza_button.Location = new System.Drawing.Point(12, 479);
            this.vissza_button.Name = "vissza_button";
            this.vissza_button.Size = new System.Drawing.Size(75, 30);
            this.vissza_button.TabIndex = 25;
            this.vissza_button.Text = "Vissza";
            this.vissza_button.UseVisualStyleBackColor = true;
            this.vissza_button.Click += new System.EventHandler(this.vissza_button_Click);
            // 
            // mentes_button
            // 
            this.mentes_button.Location = new System.Drawing.Point(877, 479);
            this.mentes_button.Name = "mentes_button";
            this.mentes_button.Size = new System.Drawing.Size(75, 30);
            this.mentes_button.TabIndex = 26;
            this.mentes_button.Text = "Mentés";
            this.mentes_button.UseVisualStyleBackColor = true;
            this.mentes_button.Click += new System.EventHandler(this.mentes_button_Click);
            // 
            // riport_button
            // 
            this.riport_button.Location = new System.Drawing.Point(412, 479);
            this.riport_button.Name = "riport_button";
            this.riport_button.Size = new System.Drawing.Size(75, 30);
            this.riport_button.TabIndex = 27;
            this.riport_button.Text = "Riport";
            this.riport_button.UseVisualStyleBackColor = true;
            this.riport_button.Click += new System.EventHandler(this.riport_button_Click);
            // 
            // Hozzarendeles_kezeles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 521);
            this.Controls.Add(this.riport_button);
            this.Controls.Add(this.mentes_button);
            this.Controls.Add(this.vissza_button);
            this.Controls.Add(this.Hozzarendeles_groupBox);
            this.Name = "Hozzarendeles_kezeles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hozzarendeles_kezeles";
            this.Load += new System.EventHandler(this.Hozzarendeles_kezeles_Load);
            this.Hozzarendeles_groupBox.ResumeLayout(false);
            this.Hozzarendeles_groupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Hozzarendeles_groupBox;
        private System.Windows.Forms.ComboBox date_comboBox;
        private System.Windows.Forms.Button task_delete_button;
        private System.Windows.Forms.Label information_label;
        private System.Windows.Forms.Button megjelenites_Button;
        private System.Windows.Forms.ListBox information_listBox;
        private System.Windows.Forms.Label team_label;
        private System.Windows.Forms.Label team_task_label;
        private System.Windows.Forms.ListBox team_task_listBox;
        private System.Windows.Forms.ListBox team_listBox;
        private System.Windows.Forms.Button vissza_button;
        private System.Windows.Forms.Button mentes_button;
        private System.Windows.Forms.Button riport_button;
    }
}