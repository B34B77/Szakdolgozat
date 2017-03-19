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
            this.adatok_groupBox = new System.Windows.Forms.GroupBox();
            this.csapatok_listBox = new System.Windows.Forms.ListBox();
            this.vissza_button = new System.Windows.Forms.Button();
            this.person_listBox = new System.Windows.Forms.ListBox();
            this.vehicle_listBox = new System.Windows.Forms.ListBox();
            this.equipment_listBox = new System.Windows.Forms.ListBox();
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
            // adatok_groupBox
            // 
            this.adatok_groupBox.Controls.Add(this.equipment_listBox);
            this.adatok_groupBox.Controls.Add(this.vehicle_listBox);
            this.adatok_groupBox.Controls.Add(this.person_listBox);
            this.adatok_groupBox.Location = new System.Drawing.Point(344, 53);
            this.adatok_groupBox.Name = "adatok_groupBox";
            this.adatok_groupBox.Size = new System.Drawing.Size(875, 466);
            this.adatok_groupBox.TabIndex = 1;
            this.adatok_groupBox.TabStop = false;
            this.adatok_groupBox.Text = "Adatok";
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
            // person_listBox
            // 
            this.person_listBox.FormattingEnabled = true;
            this.person_listBox.HorizontalScrollbar = true;
            this.person_listBox.Location = new System.Drawing.Point(16, 29);
            this.person_listBox.Name = "person_listBox";
            this.person_listBox.ScrollAlwaysVisible = true;
            this.person_listBox.Size = new System.Drawing.Size(276, 420);
            this.person_listBox.TabIndex = 0;
            // 
            // vehicle_listBox
            // 
            this.vehicle_listBox.FormattingEnabled = true;
            this.vehicle_listBox.HorizontalScrollbar = true;
            this.vehicle_listBox.Location = new System.Drawing.Point(322, 29);
            this.vehicle_listBox.Name = "vehicle_listBox";
            this.vehicle_listBox.ScrollAlwaysVisible = true;
            this.vehicle_listBox.Size = new System.Drawing.Size(255, 420);
            this.vehicle_listBox.TabIndex = 1;
            // 
            // equipment_listBox
            // 
            this.equipment_listBox.FormattingEnabled = true;
            this.equipment_listBox.HorizontalScrollbar = true;
            this.equipment_listBox.Location = new System.Drawing.Point(607, 29);
            this.equipment_listBox.Name = "equipment_listBox";
            this.equipment_listBox.ScrollAlwaysVisible = true;
            this.equipment_listBox.Size = new System.Drawing.Size(241, 420);
            this.equipment_listBox.TabIndex = 2;
            // 
            // Csapat_reszlet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.vissza_button);
            this.Controls.Add(this.adatok_groupBox);
            this.Controls.Add(this.csapatok_groupBox);
            this.Name = "Csapat_reszlet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Csapat_reszlet";
            this.Load += new System.EventHandler(this.Csapat_reszlet_Load);
            this.csapatok_groupBox.ResumeLayout(false);
            this.adatok_groupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox csapatok_groupBox;
        private System.Windows.Forms.ListBox csapatok_listBox;
        private System.Windows.Forms.GroupBox adatok_groupBox;
        private System.Windows.Forms.Button vissza_button;
        private System.Windows.Forms.ListBox person_listBox;
        private System.Windows.Forms.ListBox equipment_listBox;
        private System.Windows.Forms.ListBox vehicle_listBox;
    }
}