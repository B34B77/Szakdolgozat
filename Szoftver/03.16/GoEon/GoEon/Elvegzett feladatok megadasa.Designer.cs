namespace GoEon
{
    partial class Elvegzett_feladatok_megadasa
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
            this.mentes_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 66);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(640, 525);
            this.dataGridView.TabIndex = 1;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(13, 47);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(209, 13);
            this.label.TabIndex = 2;
            this.label.Text = "Válassza ki mely feladatok lettek teljesítve:";
            // 
            // mentes_button
            // 
            this.mentes_button.Location = new System.Drawing.Point(295, 615);
            this.mentes_button.Name = "mentes_button";
            this.mentes_button.Size = new System.Drawing.Size(75, 30);
            this.mentes_button.TabIndex = 3;
            this.mentes_button.Text = "Mentés";
            this.mentes_button.UseVisualStyleBackColor = true;
            this.mentes_button.Click += new System.EventHandler(this.mentes_button_Click);
            // 
            // Elvegzett_feladatok_megadasa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 657);
            this.Controls.Add(this.mentes_button);
            this.Controls.Add(this.label);
            this.Controls.Add(this.dataGridView);
            this.Name = "Elvegzett_feladatok_megadasa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Elvegzett_feladatok_megadasa";
            this.Load += new System.EventHandler(this.Elvegzett_feladatok_megadasa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Button mentes_button;
    }
}