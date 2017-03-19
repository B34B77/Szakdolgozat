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
    public partial class Hozzarendeles_opcio : Form
    {
        public Hozzarendeles_opcio()
        {
            InitializeComponent();
        }

        private void Hozzarendeles_opcio_Load(object sender, EventArgs e)
        {
            checkedListBox.Items.Add("Prioritás szerinti sorba rendezés");
            checkedListBox.Items.Add("Határidő szerinti sorbarendezés");
            
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            Automatikus_hozzarendeles_kezeles uj_form = new Automatikus_hozzarendeles_kezeles();
            uj_form.Show();
            this.Close();
        }
    }
}
