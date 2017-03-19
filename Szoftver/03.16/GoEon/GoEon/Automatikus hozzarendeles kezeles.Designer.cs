namespace GoEon
{
    partial class Automatikus_hozzarendeles_kezeles
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.label = new System.Windows.Forms.Label();
            this.hozzarendeles_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 51);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(640, 525);
            this.dataGridView.TabIndex = 0;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(13, 35);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(294, 13);
            this.label.TabIndex = 1;
            this.label.Text = "Válassza ki, hogy megfelelő-e az automatikus hozzárendelés:";
            // 
            // hozzarendeles_button
            // 
            this.hozzarendeles_button.Location = new System.Drawing.Point(271, 615);
            this.hozzarendeles_button.Name = "hozzarendeles_button";
            this.hozzarendeles_button.Size = new System.Drawing.Size(115, 30);
            this.hozzarendeles_button.TabIndex = 2;
            this.hozzarendeles_button.Text = "Hozzárendelés";
            this.hozzarendeles_button.UseVisualStyleBackColor = true;
            this.hozzarendeles_button.Click += new System.EventHandler(this.hozzarendeles_button_Click);
            // 
            // Automatikus_hozzarendeles_kezeles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 657);
            this.Controls.Add(this.hozzarendeles_button);
            this.Controls.Add(this.label);
            this.Controls.Add(this.dataGridView);
            this.Name = "Automatikus_hozzarendeles_kezeles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Automatikus hozzárendelés kezelés";
            this.Load += new System.EventHandler(this.Automatikus_hozzarendeles_kezeles_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Button hozzarendeles_button;
    }
}