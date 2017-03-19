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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Csapat_hozzarendeles));
            this.feladatok_group = new System.Windows.Forms.GroupBox();
            this.feladat_reszletek_Button = new System.Windows.Forms.Button();
            this.feladatok_listBox = new System.Windows.Forms.ListBox();
            this.vissza_Button = new System.Windows.Forms.Button();
            this.osszeallitas_group = new System.Windows.Forms.GroupBox();
            this.csapatok_label = new System.Windows.Forms.Label();
            this.feladatok_label = new System.Windows.Forms.Label();
            this.datePicker_label = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.hozzaad_button = new System.Windows.Forms.Button();
            this.tasks_listBox = new System.Windows.Forms.ListBox();
            this.team_listBox = new System.Windows.Forms.ListBox();
            this.veglegesites_button = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.Label();
            this.csapat_reszlet_button = new System.Windows.Forms.Button();
            this.csapat_groupBox = new System.Windows.Forms.GroupBox();
            this.manager_button = new System.Windows.Forms.Button();
            this.riport_button = new System.Windows.Forms.Button();
            this.feladatok_group.SuspendLayout();
            this.osszeallitas_group.SuspendLayout();
            this.csapat_groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // feladatok_group
            // 
            this.feladatok_group.Controls.Add(this.feladat_reszletek_Button);
            this.feladatok_group.Controls.Add(this.feladatok_listBox);
            this.feladatok_group.Location = new System.Drawing.Point(905, 12);
            this.feladatok_group.Name = "feladatok_group";
            this.feladatok_group.Size = new System.Drawing.Size(347, 382);
            this.feladatok_group.TabIndex = 0;
            this.feladatok_group.TabStop = false;
            this.feladatok_group.Text = "A kiválasztott feladat részletei:";
            // 
            // feladat_reszletek_Button
            // 
            this.feladat_reszletek_Button.Location = new System.Drawing.Point(139, 343);
            this.feladat_reszletek_Button.Name = "feladat_reszletek_Button";
            this.feladat_reszletek_Button.Size = new System.Drawing.Size(75, 30);
            this.feladat_reszletek_Button.TabIndex = 21;
            this.feladat_reszletek_Button.Text = "Részletek";
            this.feladat_reszletek_Button.UseVisualStyleBackColor = true;
            this.feladat_reszletek_Button.Click += new System.EventHandler(this.feladat_reszletek_Button_Click);
            // 
            // feladatok_listBox
            // 
            this.feladatok_listBox.FormattingEnabled = true;
            this.feladatok_listBox.HorizontalScrollbar = true;
            this.feladatok_listBox.Location = new System.Drawing.Point(6, 34);
            this.feladatok_listBox.Name = "feladatok_listBox";
            this.feladatok_listBox.Size = new System.Drawing.Size(334, 303);
            this.feladatok_listBox.TabIndex = 0;
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
            this.osszeallitas_group.Controls.Add(this.csapatok_label);
            this.osszeallitas_group.Controls.Add(this.feladatok_label);
            this.osszeallitas_group.Controls.Add(this.datePicker_label);
            this.osszeallitas_group.Controls.Add(this.dateTimePicker);
            this.osszeallitas_group.Controls.Add(this.hozzaad_button);
            this.osszeallitas_group.Controls.Add(this.tasks_listBox);
            this.osszeallitas_group.Controls.Add(this.team_listBox);
            this.osszeallitas_group.Location = new System.Drawing.Point(12, 151);
            this.osszeallitas_group.Name = "osszeallitas_group";
            this.osszeallitas_group.Size = new System.Drawing.Size(700, 352);
            this.osszeallitas_group.TabIndex = 6;
            this.osszeallitas_group.TabStop = false;
            this.osszeallitas_group.Text = "Összeállítás";
            // 
            // csapatok_label
            // 
            this.csapatok_label.AutoSize = true;
            this.csapatok_label.Location = new System.Drawing.Point(482, 36);
            this.csapatok_label.Name = "csapatok_label";
            this.csapatok_label.Size = new System.Drawing.Size(116, 13);
            this.csapatok_label.TabIndex = 9;
            this.csapatok_label.Text = "Válassza ki a csapatot:";
            // 
            // feladatok_label
            // 
            this.feladatok_label.AutoSize = true;
            this.feladatok_label.Location = new System.Drawing.Point(7, 36);
            this.feladatok_label.Name = "feladatok_label";
            this.feladatok_label.Size = new System.Drawing.Size(160, 13);
            this.feladatok_label.TabIndex = 8;
            this.feladatok_label.Text = "Válassza ki a feladatot a listából:";
            // 
            // datePicker_label
            // 
            this.datePicker_label.AutoSize = true;
            this.datePicker_label.Location = new System.Drawing.Point(236, 116);
            this.datePicker_label.Name = "datePicker_label";
            this.datePicker_label.Size = new System.Drawing.Size(171, 13);
            this.datePicker_label.TabIndex = 3;
            this.datePicker_label.Text = "Válassza ki a végrehajtás dátumát:";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(239, 132);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(210, 20);
            this.dateTimePicker.TabIndex = 2;
            this.dateTimePicker.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
            // 
            // hozzaad_button
            // 
            this.hozzaad_button.Location = new System.Drawing.Point(482, 286);
            this.hozzaad_button.Name = "hozzaad_button";
            this.hozzaad_button.Size = new System.Drawing.Size(198, 46);
            this.hozzaad_button.TabIndex = 1;
            this.hozzaad_button.Text = "Hozzárendelés a csapathoz";
            this.hozzaad_button.UseVisualStyleBackColor = true;
            this.hozzaad_button.Click += new System.EventHandler(this.hozzaad_button_Click);
            // 
            // tasks_listBox
            // 
            this.tasks_listBox.FormattingEnabled = true;
            this.tasks_listBox.Location = new System.Drawing.Point(6, 55);
            this.tasks_listBox.Name = "tasks_listBox";
            this.tasks_listBox.Size = new System.Drawing.Size(208, 277);
            this.tasks_listBox.TabIndex = 0;
            this.tasks_listBox.SelectedIndexChanged += new System.EventHandler(this.tasks_listBox_SelectedIndexChanged);
            // 
            // team_listBox
            // 
            this.team_listBox.FormattingEnabled = true;
            this.team_listBox.Location = new System.Drawing.Point(482, 55);
            this.team_listBox.Name = "team_listBox";
            this.team_listBox.Size = new System.Drawing.Size(198, 225);
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
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label.Location = new System.Drawing.Point(207, 121);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(254, 16);
            this.label.TabIndex = 17;
            this.label.Text = "Feladat hozzárendelés a csapathoz";
            // 
            // csapat_reszlet_button
            // 
            this.csapat_reszlet_button.Location = new System.Drawing.Point(67, 62);
            this.csapat_reszlet_button.Name = "csapat_reszlet_button";
            this.csapat_reszlet_button.Size = new System.Drawing.Size(203, 35);
            this.csapat_reszlet_button.TabIndex = 18;
            this.csapat_reszlet_button.Text = "A csapatok tulajdonságainak megtekintése";
            this.csapat_reszlet_button.UseVisualStyleBackColor = true;
            this.csapat_reszlet_button.Click += new System.EventHandler(this.csapat_reszlet_button_Click);
            // 
            // csapat_groupBox
            // 
            this.csapat_groupBox.Controls.Add(this.csapat_reszlet_button);
            this.csapat_groupBox.Location = new System.Drawing.Point(911, 428);
            this.csapat_groupBox.Name = "csapat_groupBox";
            this.csapat_groupBox.Size = new System.Drawing.Size(334, 141);
            this.csapat_groupBox.TabIndex = 19;
            this.csapat_groupBox.TabStop = false;
            this.csapat_groupBox.Text = "Csapatok tulajdonságai";
            // 
            // manager_button
            // 
            this.manager_button.Location = new System.Drawing.Point(526, 639);
            this.manager_button.Name = "manager_button";
            this.manager_button.Size = new System.Drawing.Size(186, 30);
            this.manager_button.TabIndex = 20;
            this.manager_button.Text = "Hozzárendelések megjelenítése";
            this.manager_button.UseVisualStyleBackColor = true;
            this.manager_button.Click += new System.EventHandler(this.manager_button_Click);
            // 
            // riport_button
            // 
            this.riport_button.Location = new System.Drawing.Point(327, 509);
            this.riport_button.Name = "riport_button";
            this.riport_button.Size = new System.Drawing.Size(75, 30);
            this.riport_button.TabIndex = 21;
            this.riport_button.Text = "Riport";
            this.riport_button.UseVisualStyleBackColor = true;
            this.riport_button.Click += new System.EventHandler(this.riport_button_Click);
            // 
            // Csapat_hozzarendeles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.riport_button);
            this.Controls.Add(this.manager_button);
            this.Controls.Add(this.csapat_groupBox);
            this.Controls.Add(this.label);
            this.Controls.Add(this.veglegesites_button);
            this.Controls.Add(this.osszeallitas_group);
            this.Controls.Add(this.vissza_Button);
            this.Controls.Add(this.feladatok_group);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Csapat_hozzarendeles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Csapat_hozzarendeles";
            this.Load += new System.EventHandler(this.Csapat_hozzarendeles_Load);
            this.feladatok_group.ResumeLayout(false);
            this.osszeallitas_group.ResumeLayout(false);
            this.osszeallitas_group.PerformLayout();
            this.csapat_groupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox feladatok_group;
        private System.Windows.Forms.ListBox feladatok_listBox;
        private System.Windows.Forms.Button vissza_Button;
        private System.Windows.Forms.GroupBox osszeallitas_group;
        private System.Windows.Forms.ListBox tasks_listBox;
        private System.Windows.Forms.Button hozzaad_button;
        private System.Windows.Forms.ListBox team_listBox;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Label datePicker_label;
        private System.Windows.Forms.Button veglegesites_button;
        private System.Windows.Forms.Button feladat_reszletek_Button;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Button csapat_reszlet_button;
        private System.Windows.Forms.GroupBox csapat_groupBox;
        private System.Windows.Forms.Label csapatok_label;
        private System.Windows.Forms.Label feladatok_label;
        private System.Windows.Forms.Button manager_button;
        private System.Windows.Forms.Button riport_button;
    }
}