using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pro_Screw_Market
{
    public partial class MainMenueScreen : Form
    {
        public MainMenueScreen()
        {
            InitializeComponent();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            Produkte productScreen = new Produkte(); 
            productScreen.Show();
            this.Hide();
        }
    }
}
