using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoEon
{
    public partial class Riport : Form
    {
        string text;
        public Riport(string text)
        {
            this.text = text;
            InitializeComponent();
        }

        private void ok_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Riport_Load(object sender, EventArgs e)
        {
            textBox.Text = text;
        }

        private void export_button_Click(object sender, EventArgs e)
        {
            string date = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day;
            saveFileDialog.Filter = "Text file|*.txt";
            saveFileDialog.Title = "Riport mentése";
            saveFileDialog.FileName = "Riport_" + date + ".txt";

            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, "Hozzárendelések:\r\n\r\n" + textBox.Text);
            }
            
        }
    }
}
