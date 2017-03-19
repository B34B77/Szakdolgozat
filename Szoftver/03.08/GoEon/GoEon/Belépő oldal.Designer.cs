namespace GoEon
{
    partial class Belépő_oldal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Belépő_oldal));
            this.mai_hatarido_listBox = new System.Windows.Forms.ListBox();
            this.hataridos_feladatok_group = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.listázásiBeállításokToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maiHatáridővelRendelkezőFeladatokToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.normálFeladatokToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sürgősFeladatokToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.összesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tovabb_Button = new System.Windows.Forms.Button();
            this.WebBrowser = new Gecko.GeckoWebBrowser();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.hataridos_feladatok_group.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // mai_hatarido_listBox
            // 
            this.mai_hatarido_listBox.FormattingEnabled = true;
            this.mai_hatarido_listBox.Location = new System.Drawing.Point(6, 70);
            this.mai_hatarido_listBox.Name = "mai_hatarido_listBox";
            this.mai_hatarido_listBox.Size = new System.Drawing.Size(348, 381);
            this.mai_hatarido_listBox.TabIndex = 0;
            this.mai_hatarido_listBox.SelectedIndexChanged += new System.EventHandler(this.mai_hatarido_listBox_SelectedIndexChanged);
            // 
            // hataridos_feladatok_group
            // 
            this.hataridos_feladatok_group.Controls.Add(this.mai_hatarido_listBox);
            this.hataridos_feladatok_group.Controls.Add(this.menuStrip1);
            this.hataridos_feladatok_group.Location = new System.Drawing.Point(892, 97);
            this.hataridos_feladatok_group.Name = "hataridos_feladatok_group";
            this.hataridos_feladatok_group.Size = new System.Drawing.Size(360, 457);
            this.hataridos_feladatok_group.TabIndex = 1;
            this.hataridos_feladatok_group.TabStop = false;
            this.hataridos_feladatok_group.Text = "A mai határidővel rendelkező feladatok";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listázásiBeállításokToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(3, 16);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(354, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // listázásiBeállításokToolStripMenuItem
            // 
            this.listázásiBeállításokToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.maiHatáridővelRendelkezőFeladatokToolStripMenuItem,
            this.normálFeladatokToolStripMenuItem,
            this.sürgősFeladatokToolStripMenuItem,
            this.összesToolStripMenuItem});
            this.listázásiBeállításokToolStripMenuItem.Name = "listázásiBeállításokToolStripMenuItem";
            this.listázásiBeállításokToolStripMenuItem.Size = new System.Drawing.Size(121, 20);
            this.listázásiBeállításokToolStripMenuItem.Text = "Listázási beállítások";
            // 
            // maiHatáridővelRendelkezőFeladatokToolStripMenuItem
            // 
            this.maiHatáridővelRendelkezőFeladatokToolStripMenuItem.Name = "maiHatáridővelRendelkezőFeladatokToolStripMenuItem";
            this.maiHatáridővelRendelkezőFeladatokToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
            this.maiHatáridővelRendelkezőFeladatokToolStripMenuItem.Text = "Mai határidővel rendelkező feladatok";
            this.maiHatáridővelRendelkezőFeladatokToolStripMenuItem.Click += new System.EventHandler(this.maiHatáridővelRendelkezőFeladatokToolStripMenuItem_Click);
            // 
            // normálFeladatokToolStripMenuItem
            // 
            this.normálFeladatokToolStripMenuItem.Name = "normálFeladatokToolStripMenuItem";
            this.normálFeladatokToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
            this.normálFeladatokToolStripMenuItem.Text = "Normál feladatok";
            this.normálFeladatokToolStripMenuItem.Click += new System.EventHandler(this.normálFeladatokToolStripMenuItem_Click);
            // 
            // sürgősFeladatokToolStripMenuItem
            // 
            this.sürgősFeladatokToolStripMenuItem.Name = "sürgősFeladatokToolStripMenuItem";
            this.sürgősFeladatokToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
            this.sürgősFeladatokToolStripMenuItem.Text = "Sürgős feladatok";
            this.sürgősFeladatokToolStripMenuItem.Click += new System.EventHandler(this.sürgősFeladatokToolStripMenuItem_Click);
            // 
            // összesToolStripMenuItem
            // 
            this.összesToolStripMenuItem.Name = "összesToolStripMenuItem";
            this.összesToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
            this.összesToolStripMenuItem.Text = "Összes";
            this.összesToolStripMenuItem.Click += new System.EventHandler(this.összesToolStripMenuItem_Click);
            // 
            // tovabb_Button
            // 
            this.tovabb_Button.Location = new System.Drawing.Point(546, 629);
            this.tovabb_Button.Name = "tovabb_Button";
            this.tovabb_Button.Size = new System.Drawing.Size(128, 40);
            this.tovabb_Button.TabIndex = 2;
            this.tovabb_Button.Text = "Tovább a főoldalra";
            this.tovabb_Button.UseVisualStyleBackColor = true;
            this.tovabb_Button.Click += new System.EventHandler(this.tovabb_Button_Click);
            // 
            // WebBrowser
            // 
            this.WebBrowser.Location = new System.Drawing.Point(3, 12);
            this.WebBrowser.Name = "WebBrowser";
            this.WebBrowser.Size = new System.Drawing.Size(885, 610);
            this.WebBrowser.TabIndex = 4;
            this.WebBrowser.UseHttpActivityObserver = false;
            // 
            // pictureBox
            // 
            this.pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox.Image")));
            this.pictureBox.Location = new System.Drawing.Point(3, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(883, 593);
            this.pictureBox.TabIndex = 5;
            this.pictureBox.TabStop = false;
            // 
            // Belépő_oldal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.WebBrowser);
            this.Controls.Add(this.tovabb_Button);
            this.Controls.Add(this.hataridos_feladatok_group);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Belépő_oldal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Belépő oldal";
            this.Load += new System.EventHandler(this.Belépő_oldal_Load);
            this.hataridos_feladatok_group.ResumeLayout(false);
            this.hataridos_feladatok_group.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox mai_hatarido_listBox;
        private System.Windows.Forms.GroupBox hataridos_feladatok_group;
        private System.Windows.Forms.Button tovabb_Button;
        private Gecko.GeckoWebBrowser WebBrowser;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem listázásiBeállításokToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maiHatáridővelRendelkezőFeladatokToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem normálFeladatokToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sürgősFeladatokToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem összesToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox;
    }
}