﻿namespace GoEon
{
    partial class Terkep
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
            this.WebBrowser = new Gecko.GeckoWebBrowser();
            this.SuspendLayout();
            // 
            // WebBrowser
            // 
            this.WebBrowser.Location = new System.Drawing.Point(3, 2);
            this.WebBrowser.Name = "WebBrowser";
            this.WebBrowser.Size = new System.Drawing.Size(1258, 676);
            this.WebBrowser.TabIndex = 0;
            this.WebBrowser.UseHttpActivityObserver = false;
            // 
            // Terkep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.WebBrowser);
            this.Name = "Terkep";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Terkep";
            this.Load += new System.EventHandler(this.Terkep_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Gecko.GeckoWebBrowser WebBrowser;
    }
}