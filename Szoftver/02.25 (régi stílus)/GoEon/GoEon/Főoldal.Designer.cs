namespace GoEon
{
    partial class Fooldal
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
            this.csapatok_lista = new System.Windows.Forms.ListBox();
            this.vissza = new System.Windows.Forms.Button();
            this.csapat_hozzarendeles_Button = new System.Windows.Forms.Button();
            this.feladat_felvetel = new System.Windows.Forms.Button();
            this.elvegzendo_feladatok_lista = new System.Windows.Forms.ListBox();
            this.elvegzendo_group = new System.Windows.Forms.GroupBox();
            this.csapatok_group = new System.Windows.Forms.GroupBox();
            this.surgos_feladatok_group = new System.Windows.Forms.GroupBox();
            this.surgos_feladatok_lista = new System.Windows.Forms.ListBox();
            this.reszletek_normal_Button = new System.Windows.Forms.Button();
            this.resztelek_surgos_Button = new System.Windows.Forms.Button();
            this.calendar = new System.Windows.Forms.ListView();
            this.month_label = new System.Windows.Forms.Label();
            this.back_button = new System.Windows.Forms.Button();
            this.foward_button = new System.Windows.Forms.Button();
            this.calendar_desc_panel_green = new System.Windows.Forms.Panel();
            this.calendar_desc_panel_orange = new System.Windows.Forms.Panel();
            this.calendar_desc_label_green = new System.Windows.Forms.Label();
            this.calendar_desc_label_orange = new System.Windows.Forms.Label();
            this.csapat_reszlet_button = new System.Windows.Forms.Button();
            this.cim_label = new System.Windows.Forms.Label();
            this.automatikus_hozzarendeles_button = new System.Windows.Forms.Button();
            this.elvegzendo_group.SuspendLayout();
            this.csapatok_group.SuspendLayout();
            this.surgos_feladatok_group.SuspendLayout();
            this.SuspendLayout();
            // 
            // csapatok_lista
            // 
            this.csapatok_lista.FormattingEnabled = true;
            this.csapatok_lista.Location = new System.Drawing.Point(6, 27);
            this.csapatok_lista.Name = "csapatok_lista";
            this.csapatok_lista.Size = new System.Drawing.Size(370, 173);
            this.csapatok_lista.TabIndex = 3;
            // 
            // vissza
            // 
            this.vissza.AutoSize = true;
            this.vissza.Location = new System.Drawing.Point(12, 637);
            this.vissza.Name = "vissza";
            this.vissza.Size = new System.Drawing.Size(78, 32);
            this.vissza.TabIndex = 4;
            this.vissza.Text = "Vissza";
            this.vissza.UseVisualStyleBackColor = true;
            this.vissza.Click += new System.EventHandler(this.vissza_Click);
            // 
            // csapat_hozzarendeles_Button
            // 
            this.csapat_hozzarendeles_Button.Location = new System.Drawing.Point(1114, 637);
            this.csapat_hozzarendeles_Button.Name = "csapat_hozzarendeles_Button";
            this.csapat_hozzarendeles_Button.Size = new System.Drawing.Size(144, 32);
            this.csapat_hozzarendeles_Button.TabIndex = 5;
            this.csapat_hozzarendeles_Button.Text = "Csapat hozzárendelése";
            this.csapat_hozzarendeles_Button.UseVisualStyleBackColor = true;
            this.csapat_hozzarendeles_Button.Click += new System.EventHandler(this.csapat_hozzarendeles_Button_Click);
            // 
            // feladat_felvetel
            // 
            this.feladat_felvetel.AutoSize = true;
            this.feladat_felvetel.Location = new System.Drawing.Point(563, 637);
            this.feladat_felvetel.Name = "feladat_felvetel";
            this.feladat_felvetel.Size = new System.Drawing.Size(140, 32);
            this.feladat_felvetel.TabIndex = 6;
            this.feladat_felvetel.Text = "Új feladat felvétele";
            this.feladat_felvetel.UseVisualStyleBackColor = true;
            this.feladat_felvetel.Click += new System.EventHandler(this.feladat_felvetel_Click);
            // 
            // elvegzendo_feladatok_lista
            // 
            this.elvegzendo_feladatok_lista.FormattingEnabled = true;
            this.elvegzendo_feladatok_lista.Location = new System.Drawing.Point(6, 28);
            this.elvegzendo_feladatok_lista.Name = "elvegzendo_feladatok_lista";
            this.elvegzendo_feladatok_lista.Size = new System.Drawing.Size(335, 368);
            this.elvegzendo_feladatok_lista.TabIndex = 0;
            this.elvegzendo_feladatok_lista.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // elvegzendo_group
            // 
            this.elvegzendo_group.Controls.Add(this.elvegzendo_feladatok_lista);
            this.elvegzendo_group.Location = new System.Drawing.Point(12, 160);
            this.elvegzendo_group.Name = "elvegzendo_group";
            this.elvegzendo_group.Size = new System.Drawing.Size(347, 408);
            this.elvegzendo_group.TabIndex = 7;
            this.elvegzendo_group.TabStop = false;
            this.elvegzendo_group.Text = "Elvégzednő feladatok listája";
            this.elvegzendo_group.Enter += new System.EventHandler(this.groupBox1_Enter_1);
            // 
            // csapatok_group
            // 
            this.csapatok_group.Controls.Add(this.csapatok_lista);
            this.csapatok_group.Location = new System.Drawing.Point(435, 356);
            this.csapatok_group.Name = "csapatok_group";
            this.csapatok_group.Size = new System.Drawing.Size(382, 212);
            this.csapatok_group.TabIndex = 8;
            this.csapatok_group.TabStop = false;
            this.csapatok_group.Text = "Csapatok listája";
            // 
            // surgos_feladatok_group
            // 
            this.surgos_feladatok_group.Controls.Add(this.surgos_feladatok_lista);
            this.surgos_feladatok_group.Location = new System.Drawing.Point(883, 160);
            this.surgos_feladatok_group.Name = "surgos_feladatok_group";
            this.surgos_feladatok_group.Size = new System.Drawing.Size(369, 408);
            this.surgos_feladatok_group.TabIndex = 10;
            this.surgos_feladatok_group.TabStop = false;
            this.surgos_feladatok_group.Text = "Sürgős feladatok listája";
            // 
            // surgos_feladatok_lista
            // 
            this.surgos_feladatok_lista.FormattingEnabled = true;
            this.surgos_feladatok_lista.Location = new System.Drawing.Point(6, 34);
            this.surgos_feladatok_lista.Name = "surgos_feladatok_lista";
            this.surgos_feladatok_lista.Size = new System.Drawing.Size(357, 368);
            this.surgos_feladatok_lista.TabIndex = 0;
            // 
            // reszletek_normal_Button
            // 
            this.reszletek_normal_Button.Location = new System.Drawing.Point(140, 574);
            this.reszletek_normal_Button.Name = "reszletek_normal_Button";
            this.reszletek_normal_Button.Size = new System.Drawing.Size(75, 30);
            this.reszletek_normal_Button.TabIndex = 11;
            this.reszletek_normal_Button.Text = "Részletek";
            this.reszletek_normal_Button.UseVisualStyleBackColor = true;
            this.reszletek_normal_Button.Click += new System.EventHandler(this.reszletek_normal_Button_Click);
            // 
            // resztelek_surgos_Button
            // 
            this.resztelek_surgos_Button.Location = new System.Drawing.Point(1036, 574);
            this.resztelek_surgos_Button.Name = "resztelek_surgos_Button";
            this.resztelek_surgos_Button.Size = new System.Drawing.Size(78, 30);
            this.resztelek_surgos_Button.TabIndex = 12;
            this.resztelek_surgos_Button.Text = "Részletek";
            this.resztelek_surgos_Button.UseVisualStyleBackColor = true;
            this.resztelek_surgos_Button.Click += new System.EventHandler(this.resztelek_surgos_Button_Click);
            // 
            // calendar
            // 
            this.calendar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.calendar.ForeColor = System.Drawing.Color.Black;
            this.calendar.Location = new System.Drawing.Point(435, 74);
            this.calendar.MultiSelect = false;
            this.calendar.Name = "calendar";
            this.calendar.Size = new System.Drawing.Size(376, 217);
            this.calendar.TabIndex = 13;
            this.calendar.UseCompatibleStateImageBehavior = false;
            this.calendar.SelectedIndexChanged += new System.EventHandler(this.calendar_SelectedIndexChanged);
            // 
            // month_label
            // 
            this.month_label.AutoSize = true;
            this.month_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.month_label.Location = new System.Drawing.Point(587, 47);
            this.month_label.Name = "month_label";
            this.month_label.Size = new System.Drawing.Size(87, 24);
            this.month_label.TabIndex = 14;
            this.month_label.Text = "Hónapok";
            // 
            // back_button
            // 
            this.back_button.Location = new System.Drawing.Point(441, 45);
            this.back_button.Name = "back_button";
            this.back_button.Size = new System.Drawing.Size(75, 23);
            this.back_button.TabIndex = 15;
            this.back_button.Text = "<<";
            this.back_button.UseVisualStyleBackColor = true;
            this.back_button.Click += new System.EventHandler(this.back_button_Click);
            // 
            // foward_button
            // 
            this.foward_button.Location = new System.Drawing.Point(727, 45);
            this.foward_button.Name = "foward_button";
            this.foward_button.Size = new System.Drawing.Size(75, 23);
            this.foward_button.TabIndex = 16;
            this.foward_button.Text = ">>";
            this.foward_button.UseVisualStyleBackColor = true;
            this.foward_button.Click += new System.EventHandler(this.foward_button_Click);
            // 
            // calendar_desc_panel_green
            // 
            this.calendar_desc_panel_green.Location = new System.Drawing.Point(538, 297);
            this.calendar_desc_panel_green.Name = "calendar_desc_panel_green";
            this.calendar_desc_panel_green.Size = new System.Drawing.Size(15, 15);
            this.calendar_desc_panel_green.TabIndex = 18;
            // 
            // calendar_desc_panel_orange
            // 
            this.calendar_desc_panel_orange.AutoScroll = true;
            this.calendar_desc_panel_orange.Location = new System.Drawing.Point(538, 318);
            this.calendar_desc_panel_orange.Name = "calendar_desc_panel_orange";
            this.calendar_desc_panel_orange.Size = new System.Drawing.Size(15, 15);
            this.calendar_desc_panel_orange.TabIndex = 19;
            // 
            // calendar_desc_label_green
            // 
            this.calendar_desc_label_green.AutoSize = true;
            this.calendar_desc_label_green.Location = new System.Drawing.Point(560, 298);
            this.calendar_desc_label_green.Name = "calendar_desc_label_green";
            this.calendar_desc_label_green.Size = new System.Drawing.Size(102, 13);
            this.calendar_desc_label_green.TabIndex = 20;
            this.calendar_desc_label_green.Text = "Normál feladat (1db)";
            // 
            // calendar_desc_label_orange
            // 
            this.calendar_desc_label_orange.AutoSize = true;
            this.calendar_desc_label_orange.Location = new System.Drawing.Point(559, 320);
            this.calendar_desc_label_orange.Name = "calendar_desc_label_orange";
            this.calendar_desc_label_orange.Size = new System.Drawing.Size(102, 13);
            this.calendar_desc_label_orange.TabIndex = 21;
            this.calendar_desc_label_orange.Text = "Sürgős feladat (1db)";
            // 
            // csapat_reszlet_button
            // 
            this.csapat_reszlet_button.Location = new System.Drawing.Point(596, 574);
            this.csapat_reszlet_button.Name = "csapat_reszlet_button";
            this.csapat_reszlet_button.Size = new System.Drawing.Size(78, 30);
            this.csapat_reszlet_button.TabIndex = 23;
            this.csapat_reszlet_button.Text = "Részletek";
            this.csapat_reszlet_button.UseVisualStyleBackColor = true;
            this.csapat_reszlet_button.Click += new System.EventHandler(this.csapat_reszlet_button_Click);
            // 
            // cim_label
            // 
            this.cim_label.AutoSize = true;
            this.cim_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cim_label.Location = new System.Drawing.Point(593, 9);
            this.cim_label.Name = "cim_label";
            this.cim_label.Size = new System.Drawing.Size(61, 16);
            this.cim_label.TabIndex = 24;
            this.cim_label.Text = "Főoldal";
            // 
            // automatikus_hozzarendeles_button
            // 
            this.automatikus_hozzarendeles_button.Location = new System.Drawing.Point(940, 637);
            this.automatikus_hozzarendeles_button.Name = "automatikus_hozzarendeles_button";
            this.automatikus_hozzarendeles_button.Size = new System.Drawing.Size(144, 32);
            this.automatikus_hozzarendeles_button.TabIndex = 25;
            this.automatikus_hozzarendeles_button.Text = "Automatikus hozzárendelés";
            this.automatikus_hozzarendeles_button.UseVisualStyleBackColor = true;
            // 
            // Fooldal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.automatikus_hozzarendeles_button);
            this.Controls.Add(this.cim_label);
            this.Controls.Add(this.csapat_reszlet_button);
            this.Controls.Add(this.calendar_desc_label_orange);
            this.Controls.Add(this.calendar_desc_label_green);
            this.Controls.Add(this.calendar_desc_panel_orange);
            this.Controls.Add(this.calendar_desc_panel_green);
            this.Controls.Add(this.foward_button);
            this.Controls.Add(this.back_button);
            this.Controls.Add(this.month_label);
            this.Controls.Add(this.calendar);
            this.Controls.Add(this.resztelek_surgos_Button);
            this.Controls.Add(this.reszletek_normal_Button);
            this.Controls.Add(this.surgos_feladatok_group);
            this.Controls.Add(this.csapatok_group);
            this.Controls.Add(this.elvegzendo_group);
            this.Controls.Add(this.feladat_felvetel);
            this.Controls.Add(this.csapat_hozzarendeles_Button);
            this.Controls.Add(this.vissza);
            this.Name = "Fooldal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Főoldal";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.elvegzendo_group.ResumeLayout(false);
            this.csapatok_group.ResumeLayout(false);
            this.surgos_feladatok_group.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox csapatok_lista;
        private System.Windows.Forms.Button vissza;
        private System.Windows.Forms.Button csapat_hozzarendeles_Button;
        private System.Windows.Forms.Button feladat_felvetel;
        private System.Windows.Forms.ListBox elvegzendo_feladatok_lista;
        private System.Windows.Forms.GroupBox elvegzendo_group;
        private System.Windows.Forms.GroupBox csapatok_group;
        private System.Windows.Forms.GroupBox surgos_feladatok_group;
        private System.Windows.Forms.ListBox surgos_feladatok_lista;
        private System.Windows.Forms.Button reszletek_normal_Button;
        private System.Windows.Forms.Button resztelek_surgos_Button;
        private System.Windows.Forms.ListView calendar;
        private System.Windows.Forms.Label month_label;
        private System.Windows.Forms.Button back_button;
        private System.Windows.Forms.Button foward_button;
        private System.Windows.Forms.Panel calendar_desc_panel_green;
        private System.Windows.Forms.Panel calendar_desc_panel_orange;
        private System.Windows.Forms.Label calendar_desc_label_green;
        private System.Windows.Forms.Label calendar_desc_label_orange;
        private System.Windows.Forms.Button csapat_reszlet_button;
        private System.Windows.Forms.Label cim_label;
        private System.Windows.Forms.Button automatikus_hozzarendeles_button;
    }
}

