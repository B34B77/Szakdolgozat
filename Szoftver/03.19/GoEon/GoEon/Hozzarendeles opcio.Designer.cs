namespace GoEon
{
    partial class Hozzarendeles_opcio
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
            this.checkedListBox = new System.Windows.Forms.CheckedListBox();
            this.label = new System.Windows.Forms.Label();
            this.NextButton = new System.Windows.Forms.Button();
            this.statikus_radioButton = new System.Windows.Forms.RadioButton();
            this.dinamikus_radioButton = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // checkedListBox
            // 
            this.checkedListBox.FormattingEnabled = true;
            this.checkedListBox.Location = new System.Drawing.Point(115, 46);
            this.checkedListBox.Name = "checkedListBox";
            this.checkedListBox.Size = new System.Drawing.Size(266, 94);
            this.checkedListBox.TabIndex = 0;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(13, 13);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(384, 13);
            this.label.TabIndex = 1;
            this.label.Text = "Válasssza ki az opciók közül mi alapján történjen az automatikus hozzárendelés:";
            // 
            // NextButton
            // 
            this.NextButton.Location = new System.Drawing.Point(131, 246);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(230, 30);
            this.NextButton.TabIndex = 2;
            this.NextButton.Text = "Tovább az automatikus hozzárendeléshez";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // statikus_radioButton
            // 
            this.statikus_radioButton.AutoSize = true;
            this.statikus_radioButton.Location = new System.Drawing.Point(131, 162);
            this.statikus_radioButton.Name = "statikus_radioButton";
            this.statikus_radioButton.Size = new System.Drawing.Size(233, 17);
            this.statikus_radioButton.TabIndex = 3;
            this.statikus_radioButton.TabStop = true;
            this.statikus_radioButton.Text = "Statikus korlát (2 feladat/nap csapatonként)";
            this.statikus_radioButton.UseVisualStyleBackColor = true;
            // 
            // dinamikus_radioButton
            // 
            this.dinamikus_radioButton.AutoSize = true;
            this.dinamikus_radioButton.Location = new System.Drawing.Point(131, 194);
            this.dinamikus_radioButton.Name = "dinamikus_radioButton";
            this.dinamikus_radioButton.Size = new System.Drawing.Size(103, 17);
            this.dinamikus_radioButton.TabIndex = 4;
            this.dinamikus_radioButton.TabStop = true;
            this.dinamikus_radioButton.Text = "Dinamikus korlát";
            this.dinamikus_radioButton.UseVisualStyleBackColor = true;
            // 
            // Hozzarendeles_opcio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 288);
            this.Controls.Add(this.dinamikus_radioButton);
            this.Controls.Add(this.statikus_radioButton);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.label);
            this.Controls.Add(this.checkedListBox);
            this.Name = "Hozzarendeles_opcio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hozzárendelés opciók kiválasztása";
            this.Load += new System.EventHandler(this.Hozzarendeles_opcio_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBox;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.RadioButton statikus_radioButton;
        private System.Windows.Forms.RadioButton dinamikus_radioButton;
    }
}