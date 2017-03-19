using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoEon
{
    public partial class Terkep : Form
    {
        string url;
        public Terkep(string url)
        {
            InitializeComponent();
            this.url = url;
            Gecko.Xpcom.Initialize(@"..\xulrunner");
        }

        private void Terkep_Load(object sender, EventArgs e)
        {
            WebBrowser.Navigate(url);
        }
    }
}
