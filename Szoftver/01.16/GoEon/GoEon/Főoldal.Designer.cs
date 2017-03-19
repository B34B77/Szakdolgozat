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
            this.elvegzendo_group.Location = new System.Drawing.Point(12, 53);
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
            this.csapatok_group.Location = new System.Drawing.Point(434, 249);
            this.csapatok_group.Name = "csapatok_group";
            this.csapatok_group.Size = new System.Drawing.Size(382, 212);
            this.csapatok_group.TabIndex = 8;
            this.csapatok_group.TabStop = false;
            this.csapatok_group.Text = "Csapatok listája";
            // 
            // surgos_feladatok_group
            // 
            this.surgos_feladatok_group.Controls.Add(this.surgos_feladatok_lista);
            this.surgos_feladatok_group.Location = new System.Drawing.Point(889, 53);
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
            this.reszletek_normal_Button.Location = new System.Drawing.Point(140, 467);
            this.reszletek_normal_Button.Name = "reszletek_normal_Button";
            this.reszletek_normal_Button.Size = new System.Drawing.Size(75, 30);
            this.reszletek_normal_Button.TabIndex = 11;
            this.reszletek_normal_Button.Text = "Részletek";
            this.reszletek_normal_Button.UseVisualStyleBackColor = true;
            this.reszletek_normal_Button.Click += new System.EventHandler(this.reszletek_normal_Button_Click);
            // 
            // resztelek_surgos_Button
            // 
            this.resztelek_surgos_Button.Location = new System.Drawing.Point(1036, 467);
            this.resztelek_surgos_Button.Name = "resztelek_surgos_Button";
            this.resztelek_surgos_Button.Size = new System.Drawing.Size(78, 30);
            this.resztelek_surgos_Button.TabIndex = 12;
            this.resztelek_surgos_Button.Text = "Részletek";
            this.resztelek_surgos_Button.UseVisualStyleBackColor = true;
            this.resztelek_surgos_Button.Click += new System.EventHandler(this.resztelek_surgos_Button_Click);
            // 
            // Fooldal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
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
    }
}

