namespace GoEon
{
    partial class Csapat_reszlet
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
            this.csapatok_groupBox = new System.Windows.Forms.GroupBox();
            this.csapatok_listBox = new System.Windows.Forms.ListBox();
            this.adatok_groupBox = new System.Windows.Forms.GroupBox();
            this.hozzarendelt_feladatok_button = new System.Windows.Forms.Button();
            this.equipments_label = new System.Windows.Forms.Label();
            this.vehicles_label = new System.Windows.Forms.Label();
            this.persons_label = new System.Windows.Forms.Label();
            this.equipment_listBox = new System.Windows.Forms.ListBox();
            this.vehicle_listBox = new System.Windows.Forms.ListBox();
            this.person_listBox = new System.Windows.Forms.ListBox();
            this.vissza_button = new System.Windows.Forms.Button();
            this.cim_label = new System.Windows.Forms.Label();
            this.csapatok_groupBox.SuspendLayout();
            this.adatok_groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // csapatok_groupBox
            // 
            this.csapatok_groupBox.Controls.Add(this.csapatok_listBox);
            this.csapatok_groupBox.Location = new System.Drawing.Point(28, 53);
            this.csapatok_groupBox.Name = "csapatok_groupBox";
            this.csapatok_groupBox.Size = new System.Drawing.Size(282, 466);
            this.csapatok_groupBox.TabIndex = 0;
            this.csapatok_groupBox.TabStop = false;
            this.csapatok_groupBox.Text = "Csapatok listája";
            // 
            // csapatok_listBox
            // 
            this.csapatok_listBox.FormattingEnabled = true;
            this.csapatok_listBox.Location = new System.Drawing.Point(7, 29);
            this.csapatok_listBox.Name = "csapatok_listBox";
            this.csapatok_listBox.Size = new System.Drawing.Size(269, 433);
            this.csapatok_listBox.TabIndex = 0;
            this.csapatok_listBox.SelectedIndexChanged += new System.EventHandler(this.csapatok_listBox_SelectedIndexChanged);
            // 
            // adatok_groupBox
            // 
            this.adatok_groupBox.Controls.Add(this.hozzarendelt_feladatok_button);
            this.adatok_groupBox.Controls.Add(this.equipments_label);
            this.adatok_groupBox.Controls.Add(this.vehicles_label);
            this.adatok_groupBox.Controls.Add(this.persons_label);
            this.adatok_groupBox.Controls.Add(this.equipment_listBox);
            this.adatok_groupBox.Controls.Add(this.vehicle_listBox);
            this.adatok_groupBox.Controls.Add(this.person_listBox);
            this.adatok_groupBox.Location = new System.Drawing.Point(344, 53);
            this.adatok_groupBox.Name = "adatok_groupBox";
            this.adatok_groupBox.Size = new System.Drawing.Size(879, 501);
            this.adatok_groupBox.TabIndex = 1;
            this.adatok_groupBox.TabStop = false;
            this.adatok_groupBox.Text = "Adatok";
            // 
            // hozzarendelt_feladatok_button
            // 
            this.hozzarendelt_feladatok_button.Location = new System.Drawing.Point(364, 465);
            this.hozzarendelt_feladatok_button.Name = "hozzarendelt_feladatok_button";
            this.hozzarendelt_feladatok_button.Size = new System.Drawing.Size(163, 30);
            this.hozzarendelt_feladatok_button.TabIndex = 3;
            this.hozzarendelt_feladatok_button.Text = "Csapathoz rendelt feladatok";
            this.hozzarendelt_feladatok_button.UseVisualStyleBackColor = true;
            this.hozzarendelt_feladatok_button.Click += new System.EventHandler(this.hozzarendelt_feladatok_button_Click);
            // 
            // equipments_label
            // 
            this.equipments_label.AutoSize = true;
            this.equipments_label.Location = new System.Drawing.Point(604, 20);
            this.equipments_label.Name = "equipments_label";
            this.equipments_label.Size = new System.Drawing.Size(143, 13);
            this.equipments_label.TabIndex = 5;
            this.equipments_label.Text = "Csapathoz tartozó eszközök:";
            // 
            // vehicles_label
            // 
            this.vehicles_label.AutoSize = true;
            this.vehicles_label.Location = new System.Drawing.Point(319, 20);
            this.vehicles_label.Name = "vehicles_label";
            this.vehicles_label.Size = new System.Drawing.Size(141, 13);
            this.vehicles_label.TabIndex = 4;
            this.vehicles_label.Text = "Csapathoz tartozó járművek:";
            // 
            // persons_label
            // 
            this.persons_label.AutoSize = true;
            this.persons_label.Location = new System.Drawing.Point(16, 20);
            this.persons_label.Name = "persons_label";
            this.persons_label.Size = new System.Drawing.Size(147, 13);
            this.persons_label.TabIndex = 3;
            this.persons_label.Text = "Csapathoz tartozó személyek:";
            // 
            // equipment_listBox
            // 
            this.equipment_listBox.FormattingEnabled = true;
            this.equipment_listBox.HorizontalScrollbar = true;
            this.equipment_listBox.Location = new System.Drawing.Point(607, 42);
            this.equipment_listBox.Name = "equipment_listBox";
            this.equipment_listBox.ScrollAlwaysVisible = true;
            this.equipment_listBox.Size = new System.Drawing.Size(238, 407);
            this.equipment_listBox.TabIndex = 2;
            // 
            // vehicle_listBox
            // 
            this.vehicle_listBox.FormattingEnabled = true;
            this.vehicle_listBox.HorizontalScrollbar = true;
            this.vehicle_listBox.Location = new System.Drawing.Point(322, 42);
            this.vehicle_listBox.Name = "vehicle_listBox";
            this.vehicle_listBox.ScrollAlwaysVisible = true;
            this.vehicle_listBox.Size = new System.Drawing.Size(253, 407);
            this.vehicle_listBox.TabIndex = 1;
            // 
            // person_listBox
            // 
            this.person_listBox.FormattingEnabled = true;
            this.person_listBox.HorizontalScrollbar = true;
            this.person_listBox.Location = new System.Drawing.Point(16, 42);
            this.person_listBox.Name = "person_listBox";
            this.person_listBox.ScrollAlwaysVisible = true;
            this.person_listBox.Size = new System.Drawing.Size(277, 407);
            this.person_listBox.TabIndex = 0;
            // 
            // vissza_button
            // 
            this.vissza_button.Location = new System.Drawing.Point(12, 639);
            this.vissza_button.Name = "vissza_button";
            this.vissza_button.Size = new System.Drawing.Size(75, 30);
            this.vissza_button.TabIndex = 2;
            this.vissza_button.Text = "Vissza";
            this.vissza_button.UseVisualStyleBackColor = true;
            this.vissza_button.Click += new System.EventHandler(this.vissza_button_Click);
            // 
            // cim_label
            // 
            this.cim_label.AutoSize = true;
            this.cim_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cim_label.Location = new System.Drawing.Point(609, 9);
            this.cim_label.Name = "cim_label";
            this.cim_label.Size = new System.Drawing.Size(157, 16);
            this.cim_label.TabIndex = 3;
            this.cim_label.Text = "Csapatok részletezve";
            // 
            // Csapat_reszlet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.cim_label);
            this.Controls.Add(this.vissza_button);
            this.Controls.Add(this.adatok_groupBox);
            this.Controls.Add(this.csapatok_groupBox);
            this.Name = "Csapat_reszlet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Csapat_reszlet";
            this.Load += new System.EventHandler(this.Csapat_reszlet_Load);
            this.csapatok_groupBox.ResumeLayout(false);
            this.adatok_groupBox.ResumeLayout(false);
            this.adatok_groupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox csapatok_groupBox;
        private System.Windows.Forms.ListBox csapatok_listBox;
        private System.Windows.Forms.GroupBox adatok_groupBox;
        private System.Windows.Forms.Button vissza_button;
        private System.Windows.Forms.ListBox person_listBox;
        private System.Windows.Forms.ListBox equipment_listBox;
        private System.Windows.Forms.ListBox vehicle_listBox;
        private System.Windows.Forms.Label equipments_label;
        private System.Windows.Forms.Label vehicles_label;
        private System.Windows.Forms.Label persons_label;
        private System.Windows.Forms.Button hozzarendelt_feladatok_button;
        private System.Windows.Forms.Label cim_label;
    }
}